using System;
using P.Argorithm;
namespace P.ABC
{
	public class AtCorderB
	{
		public AtCorderB()
		{
		}

		// 次魔法陣を作る（二次元配列を扱う練習）
		public void Ac436()
		{
			int n = int.Parse(Console.ReadLine());
			var g = new int[n, n];
			int r = 0, c = (n - 1) / 2;
			g[r, c] = 1;

			for (var k = 2; k <= n * n; k++)
			{
				var (x, y) = ((r + n - 1) % n, (c + 1) % n);
				if (g[x, y] == 0)
				{
					r = x; c = y;
				}
				else
				{
					r = (r + 1) % n;
				}
				g[r, c] = k;
			}

			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					Console.Write($"{g[i, j]} ");
				}
				Console.WriteLine();
			}
		}

		// 計算量：O(N^3) 全探索（難しい）全ての(l, r)の組を走査（要勉強）
		// 1 <= l <= r <= n（整数の組）
		// S = Al + Al + 1 + ...Arを求める
		// 各 l <= i <= rについてSで割った余りを求める,
		// 余りが0となる条件が存在したら、(l, r)の条件を満たさない
		// 候補となる(l, r)の組の個数は、n(n + 1)/2個
		public void Ac435()
		{
			int n = int.Parse(Console.ReadLine());
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int ans = 0;
			for (var l = 0; l < n; l++)
			{
				int s = 0;
				for (var r = l; r < n; r++)
				{
					s += a[r];
					bool ok = true;

					for (var i = l; i <= r; i++)
					{
						if (s % a[i] == 0)
						{
							ok = false;
							break;
						}
					}
					if (ok) ans++;
				}

			}
			Console.WriteLine(ans);
		}

		public void Ac434()
		{
			string[] line = Console.ReadLine().Split();
			int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);

			var sum = new Dictionary<int, int>();
            var cnt = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
			{
				string[] bird = Console.ReadLine().Split();
				int key = int.Parse(bird[0]);
                int value = int.Parse(bird[1]);

				// キーの存在チェック
				// キーが存在しない場合のみ追加、なければ追加しない
				if (!sum.TryAdd(key, value))
				{
                    sum[key] += value;
                    cnt[key] ++;
                }
				else
				{
					cnt[key] = 1;
				}


            }

            for (var i = 1; i <= m; i++)
            {
				Console.WriteLine((double)sum[i] / cnt[i]);
            }
            
        }

		

		// 2点間の最大の距離（ユークリッド距離を求める）
		// List<(int x, int y)>でリストにタプルのように追加可能
		public void Ac348()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new List<(int x, int y)>(n);
            P.Argorithm.Argorithm argo = new P.Argorithm.Argorithm();
            for (var i = 0; i < n; i++)
			{
				var t = Console.ReadLine().Split();
                a.Add((int.Parse(t[0]), int.Parse(t[1])));
            }
			
			for (var i = 0; i < n; i++)
			{
				double max = 0.0; int ans = 0;
				for (var j = 0; j < n; j++)
				{
					double dist = argo.EuclideanDist(a[i], a[j]);
                    if (max < dist)
					{
						max = dist;
						ans = j + 1;
					}
                }
				Console.WriteLine(ans);
			}
		}

		public void Ac301()
		{
			int n = int.Parse(Console.ReadLine());
			int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
			List<int> ans = b.ToList();
			
            for (var i = 0; i < 10000; i++)
			{
				if (i + 1 >= ans.Count) break;
				if (Math.Abs(ans[i] - ans[i + 1]) != 1)
				{
					if (ans[i] < ans[i + 1]) ans.Insert(i + 1, ans[i] + 1);
					else ans.Insert(i + 1, ans[i] - 1);
				}
			}

			foreach (var x in ans)
			{
				Console.Write($"{x} ");
			}

			
 		}

		// 差集合
		public void Ac257()
		{
			var a = new HashSet<string> { "ABC", "ARC", "AGC", "AHC" };
			var b = new HashSet<string> { };
			for (var i = 0; i < 3; i++) b.Add(Console.ReadLine());
			// 差集合
			a.ExceptWith(b);
            Console.WriteLine(String.Join("", a));
		}

		public void Ac211()
		{
			var s = new string[4];
			for (var i = 0; i < 4; i++) s[i] = Console.ReadLine();
			var st = s.Distinct().Count();
			string ans = "Yes";
			if (st != 4) ans = "No";
			Console.WriteLine(ans);

		}

        // 一つ前の高さの最大値として保持しておき状態を更新していく
        public void Ac124()
        {
            int n = int.Parse(Console.ReadLine());
            int[] h = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currentMax = 0;
            int ans = 0;
            for (var i = 0; i < n; i++)
            {
                if (h[i] >= currentMax) ans++;
                if (currentMax < h[i]) currentMax = h[i];
            }
            Console.WriteLine(ans);
        }

        public void Ac081()
		{
			int n = int.Parse(Console.ReadLine());
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int count = 0;
			bool ok = true;

			while (ok)
			{
				for (var i = 0; i < n; i++)
				{
					if (a[i] % 2 != 0)
					{
						ok = false;
						break;
					}
				}
				if (!ok) break;
				for (var i = 0; i < n; i++) a[i] = a[i] / 2;
				count++;
			}
			Console.WriteLine(count);
        }


		public void Ac050()
		{
			int n = int.Parse(Console.ReadLine());
			var t = Console.ReadLine().Split().Select(int.Parse).ToList();
			int m = int.Parse(Console.ReadLine());
			var tt = new List<int>(t);
			for (var i = 0; i < m; i++)
			{
				int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int p = a[0], x = a[1];
				p -= 1;
				tt[p] = x;
				Console.WriteLine(tt.Sum());
				// 深いコピー（新しいリストを作り元リストを参照しない）
				tt = new List<int>(t);
 			}
		}

		
	}
}

