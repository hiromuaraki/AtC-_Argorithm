namespace P.アルゴ式.中級.メモ化再帰
{
	public class Memo
	{
		private static Dictionary<int, int> memo = new Dictionary<int, int>();
		static int N, L, R;
		static long LL, RR, count;

        public Memo()
		{
		}

		// メモ化なし
		public int Rec(int[] counter, int n)
		{
			counter[n]++;
			if (n == 1 || n == 2) return 1; // ベースケース
			return Rec(counter, n - 2) + Rec(counter, n - 1);
		}

		// メモ化あり
		public int Func(int[] counter, int n)
        {
            counter[n]++;
			if (memo.ContainsKey(n)) return memo[n];
            if (n == 1 || n == 2) return 1;
            memo[n] = Func(counter, n - 2) + Func(counter, n - 1);
			return memo[n];
        }

        public long Func(long[] memo, int x)
        {
            if (memo[x] != -1) return memo[x];
            memo[x] = Func(memo, x - 1) + Func(memo, x - 2);
            return memo[x];
        }

		public bool Func(long i, long j, long[] a)
		{
			if (i == 0) return j == 0;
			bool flag = false;
			if (j >= a[i - 1] && Func(i - 1, j - a[i - 1], a)) flag = true;
			if (Func(i - 1, j, a)) flag = true;

			return flag;
		}

		public int Func(int i, int j, int[] a, int[,] memo)
		{
			if (memo[i, j] != -1) return memo[i, j];
			if (i == 0)
			{
                memo[i, j] = j == 0 ? 1 : 0;
            }
			else
			{
				memo[i, j] = 0;
				if (j >= a[i - 1] && Func(i - 1, j - a[i - 1], a, memo) == 1)
				{
					memo[i, j] = 1;
				}
				if (Func(i - 1, j, a, memo) == 1)
				{
					memo[i, j] = 1;
				}
			}
			return memo[i, j];
		}

		public long Gcd(long x, long y)
		{
			if (y == 0) return x;
			return Gcd(y, x % y);
		}

		public void Dfs(int l,List<int> path)
		{
			if (path.Count == N)
			{
				Console.WriteLine(string.Join(" ", path));
				return;
            }
			for (var i = l; i <= R; i++)
			{
				path.Add(i);
				Dfs(i, path);
				path.RemoveAt(path.Count - 1);
			}
		}

        public int CombinationCnt(int l, List<int> path)
        {
            if (path.Count == N)
            {
                return 1;
            }
			int res = 0;
            for (var i = l; i <= R; i++)
            {
                path.Add(i);
                res += CombinationCnt(i + 1, path);
                path.RemoveAt(path.Count - 1);
            }
			return res;
        }

		public void Dfs(long num, long last)
		{
			if (num > RR) return;
			if (num >= LL)
			{
				count += num;
			}
			for (var d = last; d < 10; d++)
			{
				Dfs(num * 10 + d, d);
			}
			return;
		}

        public void Q1()
		{
			var counter = new int[11];
            //Rec(counter, 10);
            Func(counter, 10);
            for (var i = 1; i <= 10; i++)
			{
				Console.WriteLine(counter[i]);
			}
		}


		public void Q2()
		{
			int n = int.Parse(Console.ReadLine());
			// オーバーフロー対策でlong型
			var fib = new long[n + 1];
			for (var i = 0; i <= n; i++) fib[i] = -1;
			fib[0] = 0; fib[1] = 1;
			Console.WriteLine(Func(fib, n));
		}

		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			var a = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
			long n = line[0], x = line[1];
			Console.WriteLine(Func(n, x, a) ? "Yes" : "No");
		}

		public void Q4()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			int n = line[0], x = line[1];
			var memo = new int[n + 1, x + 1];
			for (var i = 0; i <= n; i++)
			{
				for (var j = 0; j <= x; j++)
				{
					memo[i, j] = -1;
				}
			}
			Console.WriteLine(Func(n, x, a, memo) == 1 ? "Yes" : "No");
		}

		// 動的計画法ver
		public void Q5()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			int n = line[0], x = line[1];
			var dp = new bool[x + 1];
			dp[0] = true;
			for (var i = 0; i < n; i++)
			{
				for (var j = x; j >= 0; j--)
				{
					if (j - a[i] >= 0 && dp[j - a[i]])
					{
						dp[j] = true;
					}
					if (dp[x])
					{
						Console.WriteLine("Yes");
						return;
					}
				}
			}
			Console.WriteLine("No");
		}

		public void Q6()
		{
			long MOD = 1_000_000;
			int n = int.Parse(Console.ReadLine());
			var dp = new long[Math.Max(3, n + 1)];
			dp[0] = dp[1] = dp[2] = 1;
			for (var i = 3; i <= n; i++)
			{
				dp[i] = (dp[i - 1] + dp[i - 2] + dp[i - 3]) % MOD;
			}
			Console.WriteLine(dp[n]);
		}

		public void Q7()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long n = line[0], m = line[1];
			Console.WriteLine(Gcd(n, m));
		}

		public void Q8()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0];
			L = line[1];
			R = line[2];
			Dfs(L,new List<int>());
		}

		public void Q9()
		{
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            N = line[0];
            L = line[1];
            R = line[2];
            Console.WriteLine(CombinationCnt(L, new List<int>()));
        }

		public void Q10()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			LL = line[0];
			RR = line[1];
			for (var i = 1; i < 10; i++)
			{
				Dfs(i, i);
			}
			Console.WriteLine(count);
		}
	}
}

