using System;
namespace P.Argorithm
{
	public class Argorithm
	{
		private Dictionary<long, long> memo = new Dictionary<long, long>();

		public Argorithm()
		{
		}

		// リストを横一列に列挙
		public void Print<T>(List<T> list)
		{
			foreach (var v in list)
			{
				Console.Write($"{v} ");
			}
		}

		// 最大公約数（gcd）を求める
		public int Gcd(int x, int y)
		{
			if (y == 0) return x;
			return Gcd(y, x % y);
		}

		// 最小公倍数を求める
		public int Lcm(int x, int y)
		{
			return (x * y) / Gcd(x , y);
		}

		// 素数判定：O（√N）
		public bool IsPrime(int n)
		{
			for (var i = 2; i * i <= n; i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		// O(√N）Overflow対策 int64に対応
		public bool IsPPrime(long n)
		{
			for (var i = 2; i < Math.Sqrt(n); i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;

		}

		// N以下の素数を列挙
		public List<int> Prime(int n)
		{
			var prime = new List<int>();
			for (var i = 2; i <= n; i++)
			{
				if (IsPrime(i))
				{
					prime.Add(i);
				}
			}
			return prime;
		}

        // 約数列挙
        public List<long> Divisor(long n)
		{
			var divisor = new List<long>();
			long cnt = (long)Math.Sqrt(n);
			for (var i = 1; i <= cnt; i++)
			{
				if (n % i == 0)
				{
					divisor.Add(i);
					if (n / i != i)
					{
						divisor.Add(n / i);
					}
				}
			}
			divisor.Sort();
			return divisor;
		}


        // 素因数分解
        public List<long> Factorization(long n)
        {
            var result = new List<long>();
			var cnt = (int)Math.Sqrt(n);
			for (var i = 2; i <= cnt; i++)
			{
				while (n % i == 0)
				{
					n /= i;
					result.Add(i);
				}
			}
			if (n >= 2) { result.Add(n); }
            return result;
        }

        // 部分文字列の個数をカウント
        public int SubStringCount(int n)
		{
			return n * (n + 1) / 2;
		}

        // N以下の中でx,yで割れる倍数の個数
        public int Domrugan(int n, int x, int y)
		{
            // x = n以下の中にaの倍数 n / x
            // y = n以下の中にbの倍数 n / y
            // z = x,yの共通の倍数が重複している：最小公倍数
            // 補足：最小公倍数＝(a * b) // a,bの最大公約数
            // N以下の中でx,yで割れる倍数の個数＝ x + y - z
            int na = n / x;
            int nb = n / y;
            int distinct_count = n / Lcm(x, y);

            return na + nb - distinct_count;
        }

		// 等差数列
		public int Arithmetic(int n)
		{
			return n * (n + 1) / 2;
		}

		// N!
		public int Func(int n)
		{
			int funcN = 1;
			for (var i = 1; i <= n; i++) funcN *= i;
			return funcN;
		}

		// 2点間の距離（ユークリッド距離）
		public double EuclideanDist((int x, int y) a, (int x, int y) b)
		{
			// ValueTuple型（.ToTuple不要）
			var(x1, y1) = a;
			var(x2, y2) = b;
			return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        // 2点間の距離（ユークリッド距離）絶対値あり
        public double EuclideanAbsDist((int x, int y) a, (int x, int y) b)
        {
            // ValueTuple型（.ToTuple不要）
            var (x1, y1) = a;
            var (x2, y2) = b;
			int x = Math.Abs(x1 - x2);
			int y = Math.Abs(y1 - y2);
            return Math.Sqrt(x*x + y*y);
        }

        // リストのスライス
        public List<T> Slice<T>(List<T> list, int index, int count)
        {
            return list.GetRange(index, count);
        }


        // 整数桁の総和（桁が一桁になるまで総和を分解）
		// 例）963 > 18 > 9
        public int DigitsSum(long n)
		{
			var digits = n.ToString().ToCharArray();
			var digit = new List<int>();
			foreach (var c in digits) digit.Add(int.Parse(c.ToString()));

			int sum = digit.Sum();
			// 桁が2桁以上なら分解する
			if (sum >= 10)
			{
				return DigitsSum(sum);
			}
			return sum;
		}

		// 切り上げ処理（相手のHPを0まで削り切る）
		public int RoundN(int a, int b)
		{
			return (a + b - 1) / b;
		}

		// 10進数→2進数に変換
		public string BinaryNumber(int n)
		{
			var result = "";
			while (n > 0)
			{
				result = n % 2 + result;
				n /= 2;
			}
			return result;
		}


		// ok/ng境界のチェック
		public bool IsOk(long aMid, long x)
		{
			return aMid >= x;
		}


        // 常にokが探索結果
		// 二分探索（単調性あり）
        // x >= ai以上の要素の個数を返す関数 pythonのbisect_left
        public int BisectLeft(long x, long[]a)
        {
            int ok = -1; // OK（条件を満たす）
            int ng = a.Length;  // NG（条件を満たさない）

            while (Math.Abs(ng - ok) > 1)
            {
                int mid = (ok + ng) / 2;
                if (IsOk(x, a[mid]))
                    ok = mid;
                else
                    ng = mid;
            }
            return ok + 1;
        }

        // 常にokが探索結果
        // 二分探索で最小のOK（インデックス）を探す
        public int BinarySearchMin(int left, int right, int n)
        {
            int ok = right; // OK（条件を満たす）
            int ng = left;  // NG（条件を満たさない）

            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (IsOk(mid, n))
                    ok = mid;
                else
                    ng = mid;
            }
            return ok;
        }


        // 二分探索（単調性がある場合）
        // 常にokが探索結果
        // 二分探索で最大のOK（インデックス）を探す
        public int BinarySearchMax(int left, int right, int n)
        {
            int ok = left;  // OK
            int ng = right; // NG

            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (IsOk(mid, n))
                    ok = mid;
                else
                    ng = mid;
            }
            return ok;
        }

        // n頂点／m本の辺
        // グラフ：隣接リストの作成（無向グラフ）
        public List<int>[] AdjGraph(int n, int m, List<(int ,int)> valueTuple)
        {
            List<int>[] graph = new List<int>[n];
            // 隣接リストの初期化
            for (var i = 0; i < n; i++) graph[i] = new List<int>();
            
            for (var i = 0; i < m; i++)
            {
				var (v, u) = valueTuple[i];
				// 0-indexed
				v -= 1; u -= 1;
                // 頂点vに頂点uの辺を張る
                graph[v].Add(u);
                // 頂点uに頂点vの辺を張る
                graph[u].Add(v);
            }
            return graph;
        }

        // BFS（幅優先探索）
		// Enqueue：末尾に要素の追加 pythonだと.append()
		// Dequeue：queの先頭要素を取り出しqueから削除 pythonだと .popleft()
        public bool[] Bfs(List<int>[] graph, int n, int start)
		{
			// 先入先出し（頂点の訪問リスト）
			var que = new Queue<int>();
            // 頂点の訪問の管理用フラグ
            bool[] visited = new bool[n];
			// 最初の訪問する頂点を設定
			que.Enqueue(start);
			// 訪問済みに変更
			visited[start] = true;
			while (que.Count > 0)
			{
				var v = que.Dequeue();
				foreach (var nv in graph[v])
				{
					// 次の訪問予定の頂点が列に並んでいるイメージ
					if (!visited[nv])
					{
						visited[nv] = true;
						que.Enqueue(nv);
					}
				}
			}
			return visited;
		}


		// DFS（深さ優先探索）
		public bool[] Dfs(List<int>[] graph, int v, bool[] visited)
		{
			visited[v] = true;
			foreach (var nv in graph[v])
			{
				if (!visited[nv]) Dfs(graph, nv, visited);
			}

			return visited;
		}


		// 二部グラフの判定

		// 連結成分の個数をカウント

		// nC2の数え上げ


		// 累積和の作成
		public long[] PrefixSum(long n, long[] a)
		{
			var s = new long[n + 1];
			for (var i = 0; i < n; i++)
			{
				s[i + 1] = s[i] + a[i];
			}
			return s;
		} 


		// 動的計画法


		// ナップザック問題


		// メモ化（フィボナッチ数列）f(n) = f(n - 1) + f(n - 2)
		public long Memo(int n)
		{
			if (memo.TryGetValue(n, out var v)) return v;
			long res = Memo(n - 1) + Memo(n - 2);
			memo[n] = res;
			return res;
		}

		// bit全探索（部分和）：合計がちょうどkにする方法があルか
		public bool IsPartialSum(int n, int k, int[] a)
		{
			// 2^n通り試す
			for (var bit = 0; bit < (1 << n); bit++)
			{
				int sum = 0;
				for (var i = 0; i < n; i++)
				{
					if ((bit & (1 << i)) != 0)
					{
						sum += a[i];
					}
				}
				if (sum == k) return true;
			}
			return false;
		}


		// 集合系（差集合・和集合・積集合・対称差）

		// グリッドの走査（二次元配列）
    }
}

