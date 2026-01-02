using System;
using P.Argorithm;
namespace P.ABC
{
	public class AtCorderB
	{
		public AtCorderB()
		{
		}

		// 部分文字列＋周期＋全探索
		public void Ac438()
		{
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line[0], m = line[1];
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            int ans = 100_000;
            // n - m + 1通り試す（m文字ペア全部探す）
            for (var i = 0; i <= n - m; i++)
            {
                int cost = 0; // tが部分文字列sと一致する最小の操作回数
                for (var j = 0; j < m; j++)
                {
                    int sDigit = s[i + j];
                    int tDigit = t[j];
                    // 時計：s桁からt桁まので位置＝操作回数(+1操作)
                    // 負の値でも0-9の範囲に収めるため+10し調整
                    cost += (sDigit - tDigit + 10) % 10;
                }
                ans = Math.Min(ans, cost);
            }
            Console.WriteLine(ans);
        }
    

		// 実装少し重い
		// bをsetにすることで各行に含まれる数だけを見ればいいのでO(N^2)にできる
		public void Ac437()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int h = line[0], w = line[1], n = line[2];
			var g = new int[h, w];
			var b = new HashSet<int>();
			for (var i = 0; i < h; i++)
			{
				var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (var j = 0; j < w; j++)
				{
					g[i, j] = a[j];
				}
			}

			for (var i = 0; i < n; i++) b.Add(int.Parse(Console.ReadLine()));

			int ans = 0;
			for (var i = 0; i < h; i++)
			{
				int count = 0;
				for (var j = 0; j < w; j++)
				{
					if (b.Contains(g[i, j])) count++;
				}
				ans = Math.Max(ans, count);
			}
			Console.Write(ans);
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

		public void Ac308()
		{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int n = line[0], m = line[1];
				string[] c = Console.ReadLine().Split();
				string[] d = Console.ReadLine().Split();
				int[] p = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var mapPrice = new Dictionary<string, int>();

				for (var i = 0; i < d.Length; i++)
				{
					mapPrice.TryAdd(d[i], p[i + 1]);
				}

				int sum = 0;
				for (var i = 0; i < c.Length; i++)
				{
					if (mapPrice.ContainsKey(c[i]))
					{
						sum += mapPrice[c[i]];
						continue;
					}
					sum += p[0];
				}
				Console.WriteLine(sum);
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

		// set+tupleをうまく組み合わせてデータを保持
		public void Ac216()
		{
			int n = int.Parse(Console.ReadLine());
			var names = new HashSet<(string, string)>();
			for (var i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Split();
				string s = line[0], t = line[1];
				if (names.Contains((s, t)))
				{
					Console.WriteLine("Yes");
					Environment.Exit(0);
				}
				names.Add((s, t));
			}
			Console.WriteLine("No");
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

		// 三角形の成立条件 li + lj > lk
		public void Ac175()
		{
			int n = int.Parse(Console.ReadLine());
			var l = Console.ReadLine().Split().Select(int.Parse).ToList();
			int count = 0;
			l.Sort();
			for (var i = 0; i < n; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					for (var k = j + 1; k < n; k++)
					{
						if (l[i] != l[j] && l[i] != l[k] && l[j] != l[k])
						{
							if (l[i] + l[j] > l[k])
							{
								count++;
							}
						}
					}
				}
			}
			Console.WriteLine(count);
		}

		public void Ac143()
		{
			int n = int.Parse(Console.ReadLine());
			var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int sum = 0;
			for (var i = 0; i < n - 1; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					sum += d[i] * d[j];
				}
			}
			Console.WriteLine(sum);
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


		public void Ac122()
		{
			string s = Console.ReadLine();
			int n = s.Length;
			var t = new HashSet<char> {'A', 'C', 'G', 'T'};
			int count = 0;
			int l = 0;
			for (var r = 0; r < n; r++)
			{
				if (t.Contains(s[r])) count = Math.Max(count, r - l + 1);
				else l = r + 1;
			}
			Console.WriteLine(count);
		}

		public void Ac109()
		{
			var wList = new List<string>();
			int n = int.Parse(Console.ReadLine());
			for (var i = 0; i < n; i++)
			{
				string s = Console.ReadLine();
				if (wList.Contains(s))
				{
					Console.WriteLine("No");
					Environment.Exit(0);
				}
				wList.Add(s);
			}
			for (var i = 0; i < n - 1; i++)
			{
				int len = wList[i].Length;
				if (wList[i][len - 1] != wList[i + 1][0])
				{
					Console.WriteLine("No");
					Environment.Exit(0);
				}
			}
			Console.WriteLine("Yes");
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

		// set() → s.Distinct()
		public void Ac063()
		{
			var s = Console.ReadLine();
			Console.WriteLine(s.Length == s.Distinct().Count() ? "yes" : "no");
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

