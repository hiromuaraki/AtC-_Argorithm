using System;
namespace P.Argorithm
{
	public class Argorithm
	{
		public Argorithm()
		{
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
			return true;
		}

		// N以下の素数を列挙
		public List<int> Prime()
		{
			return null;
		}

        // 素因数分解
        public List<int> Factorization(int n)
		{
			List<int> result = null;
			return result;
		}

        // 約数列挙
        public List<int> Divisor()
		{
			List<int> divisor = null;
			return divisor;
		}

		// 部分文字列の個数をカウント または 等差数列
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
		public int Arithmetic(int a, int z, int n)
		{
			return (a + z) * n / 2;
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
        static List<T> Slice<T>(List<T> list, int start, int count)
        {
            return list.GetRange(start, count);
        }


        // 整数桁の総和
        public int DigitsSum(int n)
		{
			return 0;
		}

		// 切り上げ処理（相手のHPを0まで削り切る）
		public int RoundN(int a, int b)
		{
			return (a + b - 1) / b;
		}

		// 10進数→2進数に変換

		// ok/ng境界のチェック
		public bool IsOk(int x, int n)
		{
			return x >= n;
		}

		// 二分探索（単調性がある場合）
		// 常にokが探索結果
		public int Binarylogic(int n)
		{
			int ok = -1; // 常に条件を満たす最も小さい値
			int ng = n; //常に条件を満たさない最も大きい値

			// 未探索領域がなくなるまで繰り返す
			// ng - ok = 1は探索完了
			while (ng - ok > 1)
			{
				// okからngに切り替わる境界の最小のインデックスを探す
				int mid = (ok + ng) / 2;

				if (IsOk(mid, n))
				{
					ok = mid;
				}
				else
				{
					ng = mid;
				}

			} 
			return ok;
		}

		// BFS（幅優先探索）
		public bool Bfs()
		{
			return true;
		}


		// DFS（深さ優先探索）
		public bool Dfs()
		{
			return true;
		}


		// グラフ：隣接リストの作成


		// 二部グラフの判定

		// 連結成分の個数をカウント

		// nC2の数え上げ


		// 累積和（区間差を求める）

		// 動的計画法


		// ナップザック問題


		// メモ化（フィボナッチ数列）


		// 部分和

		// bit全探索

		// 全探索

		// 集合系（差集合・和集合・積集合・対称差）

		// グリッドの走査（二次元配列）
    }
}

