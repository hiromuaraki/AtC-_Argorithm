using System;
namespace P.アルゴ式.上級.ビット全探索
{
	public class S
	{
		public S()
		{
		}

		// 集合から整数値へ変換
		public void Q1()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], k = line[1];
			int sum = 0;
			for (var i = 0; i < k; i++)
			{
				sum += 1 << s[i];
			}
			Console.WriteLine(sum);
		}

		// 全体集合
		public void Q2()
		{
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine((1 << n) - 1);
		}

		// 要素数
		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], x = line[1];
			int sum = 0;
			for (var i = 0; i < n; i++)
			{
				sum = (x & (1 << i)) != 1 ? 1 : 0;
			}
			Console.WriteLine(sum);
		}

		// 挿入・削除・検索
		public void Q4()
		{
			var line = Console.ReadLine().Split().ToArray();
			int n = int.Parse(line[0]);
			long x = long.Parse(line[1]);
			int q = int.Parse(Console.ReadLine());
			while (q-- > 0)
			{
				var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int type = query[0], v = query[1];
				if (type == 0)
				{
					x |= (1L << v);
				}
				else if (type == 1)
				{
					x &= ~(1L << v);
				}
				else
				{
					Console.WriteLine((x >> v & 1) == 1 ? "Yes" : "No");
				}
			}
		}

		// 共通部分と和集合
		public void Q5()
		{
			var line = Console.ReadLine().Split().ToArray();
			int n = int.Parse(line[0]);
			long x = long.Parse(line[1]), y = long.Parse(line[2]);
			Console.WriteLine($"{x & y} {x | y}");
		}

		// 差集合
		public void Q6()
		{
			var line = Console.ReadLine().Split().ToArray();
			int n = int.Parse(Console.ReadLine());
			long x = long.Parse(line[1]), y = long.Parse(line[2]);
			Console.WriteLine(x - (x & y));
		}

		// 部分列総和
		public void Q7()
		{
			var line = Console.ReadLine().Split().ToArray();
			int n = int.Parse(line[0]);
			long x = long.Parse(line[1]);
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			long sum = 0;
			for (var i = 0; i < n; i++)
			{
				if ((x & 1L << i) != 0) sum += a[i];
			}
			Console.WriteLine(sum);
		}

		// 部分和：bit全探索 選ぶ/選ばない＝全列挙
		public void Q8()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], v = line[1];
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			for (var S = 0; S < 1 << n; S++)
			{
				long sum = 0;
				for (var j = 0; j < n; j++)
				{
					if ((S & (1 << j)) != 0)
					{
						sum += a[j];
					}
				}
				if (sum == v)
				{
					Console.WriteLine("Yes");
					return;
				}
			}
			Console.WriteLine("No");
		}

		// 動的計画法（DP）探索の圧縮
		public void Q8_2()
		{
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line[0], v = line[1];
			var list = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = new int[n];
			// i番目までの要素を使い和jを作れるかを管理するためのテーブル
			// dp[n,v] = 要素n個まで使い和vを作れるかを求める
			bool[,] dp = new bool[n + 1, v + 1];
			for (var i = 0; i < n; i++) a[i] = list[i];
			dp[0, 0] = true; // 和0は必ず作れる
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j <= v; j++)
				{
					// a[i]を使わない
					if (dp[i, j])
					{
						dp[i + 1, j] = true; 
					}
					// j >= a[i]の場合のみa[i]を使う
					if (j >= a[i] && dp[i, j - a[i]])
					{
						dp[i + 1, j] = true;
					}
				}
			}
			Console.WriteLine(dp[n, v] ? "Yes" : "No");
        }

		public void Q9()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var w = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line[0], m = line[1];
			long ans = 0;
			for (var S = 0; S < (1 << n); S++)
			{
				long sum = 0;
				long cost = 0;
				for (var i = 0; i < n; i++)
				{
					if ((S & (1 << i)) != 0)
					{
						sum += w[i];
						cost += v[i];
					}
				}
				if (sum <= m)
				{
					ans = Math.Max(ans, cost);
				}
			}
			Console.WriteLine(ans);
		}

		public void Q10()
		{
			int n = int.Parse(Console.ReadLine());
			var w = Console.ReadLine().Split();
			int ans = int.MaxValue;
			for (var S = 0; S < (1 << n); S++)
			{
				var t = new HashSet<string>();
				for (var i = 0; i < n; i++)
				{
					if ((S & (1 << i)) != 0)
					{
						t.Add(w[i]);
					}
				}
				var tt = new HashSet<char>(string.Join("", t));
				if (tt.Count == 26)
				{
					ans = Math.Min(ans, t.Count);
				}
			}
			Console.WriteLine(ans);
		}
	}
}

