using System;
using P.Argorithm;
namespace P.ABC
{
	public class AtCorderB
	{
		public AtCorderB()
		{
		}

		public void Ac439()
		{
			int n = int.Parse(Console.ReadLine());
			int sum = n;
			var st = new HashSet<int>();
			while (sum != 1)
			{
				if (st.Contains(sum))
				{
					Console.WriteLine("No");
					return;
				}
				st.Add(sum);
				var s = sum.ToString();
				int digit = 0;
				for (var i = 0; i < s.Length; i++)
				{
					int digitN = int.Parse(s[i].ToString());
					digit += digitN * digitN;
				}
				sum = digit;
			}
			Console.WriteLine("Yes");
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

		public void Ac418()
		{
			string s = Console.ReadLine();
			int n = s.Length;

			double ans = 0.0;
			for (var l = 0; l < n; l++)
			{
				if (s[l] != 't') continue;
				for (var r = l + 2; r < n; r++)
				{
					if (s[r] != 't') continue;
					int len = r - l + 1;
					string t = s.Substring(l, len);
					double x = t.Count(c => c == 't');
					ans = Math.Max(ans, (x - 2) / (len - 2));
				}
			}
			Console.WriteLine(ans);
		}


		public void Ac411()
		{
			int n = int.Parse(Console.ReadLine());
			var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dist = new List<int>();
			for (var i = 0; i < n - 1; i++)
			{
				dist.Add(d[i]);
				int sum = d[i];
				for (var j = i + 1; j < n - 1; j++)
				{
					sum += d[j];
					dist.Add(sum);
				}
				Console.WriteLine(string.Join(" ", dist));
				dist = new List<int>();
            }

		}

		// O(N^2)
		// j - i = k - jはi, jが決まればkが決まる
		// 式変形し、k = 2j - iでkが求まるためkは固定しない
		public void Ac393()
		{
            string s = Console.ReadLine();
            int count = 0;
            int n = s.Length;

			for (var i = 0; i < n; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					int k = 2*j - i;
					if (k >= n) continue;

					if (s[i] == 'A' && s[j] == 'B' && s[k] == 'C')
                    {
                        count++;
                    }
                }
			}
			Console.WriteLine(count);
        }

		// 愚直：O(N^3)
		public void Ac393_n3()
		{
			string s = Console.ReadLine();
			int count = 0;
			int n = s.Length;

			for (var i = 0; i < n; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					for (var k = j + 1; k < n; k++)
					{
						// 等間隔の(i,j,k）組を調べる
						if (j - i != k - j) continue;
                        if (s[i] == 'A' && s[j] == 'B' && s[k] == 'C')
						{
							count++;
						}
					}
				}
			}
			Console.WriteLine(count);
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

		public void Ac342()
		{
			var s = Console.ReadLine().ToList();
			var t = new List<char>(s);
			s.Sort();
			char c = s[0] == s[1] ? s[s.Count - 1] : s[0];
			Console.WriteLine(t.IndexOf(c) + 1);
		}

		// 部分文字列＋回文（文字列の切り取りの範囲設計）
		public void Ac320()
		{
			string s = Console.ReadLine();
			int ans = 1;
			for (var r = 0; r < s.Length; r++)
			{
				for (var l = 0; l < s.Length - r; l++)
				{
					var t = s.Substring(r, l + 1);
					var rT = string.Join("", t.Reverse().ToArray());
					if (t.ToString() == rT)
					{
						ans = Math.Max(ans, t.Length);
					}
				}
			}
			Console.WriteLine(ans);

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

		public void Ac279()
		{
			string s = Console.ReadLine();
            string t = Console.ReadLine();

			if (s == t)
			{
				Console.WriteLine("Yes");
				return;
			}

			int n = s.Length - t.Length + 1;
			for (var i = 0; i < n; i++)
			{
				string x = "";
				for (var j = 0; j < t.Length; j++)
				{
					x += s[i + j];
				}

				if (x == t)
				{
					Console.WriteLine("Yes");
					return;
				}
			}
			Console.WriteLine("No");
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

		public void Ac223()
		{
			string s = Console.ReadLine();
			var list = new List<string>();
			list.Add(s);
			for (var i = 0; i < s.Length - 1; i++)
			{
				string t = s.Substring(i + 1);
				int slice = t.Length;
				list.Add(t + s.Substring(0, s.Length - slice));
			}
			list.Sort();
			Console.WriteLine(list[0]);
            Console.WriteLine(list[s.Length - 1]);
        }

		public void Ac221()
		{
			var s = Console.ReadLine().ToCharArray();
            var t = Console.ReadLine().ToCharArray();
			int n = s.Length;
			for (var i = 0; i < n; i++)
			{
				if (s[i] != t[i])
				{
					(t[i], t[i + 1]) = (t[i + 1], t[i]);
					break;
				}
			}
			string ss = string.Join("", s);
            string tt = string.Join("", t);
            Console.WriteLine(ss == tt ? "Yes" : "No");
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
					return;
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

		public void Ac135()
		{
			int n = int.Parse(Console.ReadLine());
			var p = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int diffCount = 0;
			for (var i = 0; i < n; i++)
			{
				if (i + 1 != p[i]) diffCount++;
			}
			Console.WriteLine(diffCount <= 2 ? "YES" : "NO");
		}

		public void Ac129()
		{
			int n = int.Parse(Console.ReadLine());
			var w = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int minDiff = 100_000_000;
			for (var t = 1; t < n; t++)
			{
				var (s1, s2) = (0, 0);
				for (var i = 0; i < n; i++)
				{
					if (i + 1 <= t) s1 += w[i];
					else s2 += w[i];
				}
				minDiff = Math.Min(minDiff, Math.Abs(s1 - s2));
			}
			Console.WriteLine(minDiff);
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
					return;
				}
				wList.Add(s);
			}
			for (var i = 0; i < n - 1; i++)
			{
				int len = wList[i].Length;
				if (wList[i][len - 1] != wList[i + 1][0])
				{
					Console.WriteLine("No");
					return;
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

