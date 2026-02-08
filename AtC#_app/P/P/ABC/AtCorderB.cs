using System;
using System.Text;
using P.Argorithm;
namespace P.ABC
{
	public class AtCorderB
	{
		public AtCorderB()
		{
		}

		public void Ac444()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, k) = (line[0], line[1]);
			int count = 0;
			string s = "";
			for (var i = 1; i <= n; i++)
			{
				s = i.ToString();
				var sum = s.Sum(x => int.Parse(x.ToString()));
				if (sum == k) count++;
			}
			Console.WriteLine(count);
		}

		public void Ac443()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, k) = (line[0], line[1]);
			int year = 0, count = 0;
			while (count < k)
			{
				count += n + year;
				year++;
			}
			Console.WriteLine(year - 1);
		}

		public void Ac442()
		{
			int q = int.Parse(Console.ReadLine());
			bool IsPlayer = false;
			int volume = 0;

			while (q-- >= 0)
			{
				var a = int.Parse(Console.ReadLine());
				if (a == 1) volume++;
				else if (a == 2 && volume > 0) volume--;
				else IsPlayer ^= true;

				string msg = volume >= 3 && IsPlayer ? "Yes" : "No";
				Console.WriteLine(msg);
			}
		}

		// 部分集合 chars <= 集合S,Tに含まれれているか
		public void Ac441()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			var s = new HashSet<char>(Console.ReadLine());
            var t = new HashSet<char>(Console.ReadLine());
			int q = int.Parse(Console.ReadLine());

			for (var i = 0; i < q; i++)
			{
				var chars = new HashSet<char>(Console.ReadLine());
				var inS = chars.IsSubsetOf(s);
				var inT = chars.IsSubsetOf(t);

				string result = "";
				if (inS && inT) result = "Unknown";
				else if (inS) result = "Takahashi";
				else result = "Aoki";
				Console.WriteLine(result);
            }
        }

		public void Ac440()
		{
			int n = int.Parse(Console.ReadLine());
			var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dict = new Dictionary<int, int>();
			var tList = new List<int>(t);
			tList.Sort();
			for (var i = 0; i < n; i++) dict[t[i]] = i + 1;
			for (var i = 0; i < 3; i++) Console.WriteLine(dict[tList[i]]);
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

		public void Ac408()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
			var b = a.OrderBy(x => x).ToList();
			Console.WriteLine(b.Count);
            Console.WriteLine(string.Join(" ", b));
        }

		public void Ac407()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (x, y) = (line[0], line[1]);
			int count = 0;
			for (var a = 1; a < 7; a++)
			{
				for (var b = 1; b < 7; b++)
				{
					if (a + b >= x || Math.Abs(a - b) >= y)
					{
						count++;
					}
				}
			}
            Console.WriteLine((double)count / 36);
		}

		// オーバーフロー対策の問題
		public void Ac400()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			long x = 1;
			const int INF = 1_000_000_000;
			for (var i = 1; i <= m; i++)
			{
				x += (long)Math.Pow(n, i);
			}
			Console.WriteLine(Math.Abs(x) <= INF ? x : "inf");
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


		public void Ac380()
		{
			var s = Console.ReadLine().Split("|");
			for (var i = 0; i < s.Length; i++)
			{
				if (string.IsNullOrEmpty(s[i])) continue;
				Console.Write($"{s[i].Length} ")	;
			}
		}

		public void Ac377()
		{
			var s = new List<char[]>();
			for (var i = 0; i < 8; i++) s.Add(Console.ReadLine().ToArray());
			var tate = new HashSet<int>();
            var yoko = new HashSet<int>();
			for (var i = 0; i < 8; i++)
			{
				for (var j = 0; j < 8; j++)
				{
					if (s[i][j] == '#')
					{
						tate.Add(i);
						yoko.Add(j);
					}
				}
			}
			Console.WriteLine((8 - tate.Distinct().Count()) * (8 - yoko.Distinct().Count()));
        }

		public void Ac371()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			var child = new int[n];
			for (var i = 0; i < m; i++)
			{
				var c = Console.ReadLine().Split();
				int a = int.Parse(c[0]) - 1;
				string b = c[1];
				if (b == "M" && child[a] == 0)
				{
					Console.WriteLine("Yes");
					child[a]++;
				}
				else
				{
					Console.WriteLine("No");
				}
			}
		}

		public void Ac369()
		{
			int n = int.Parse(Console.ReadLine());
			int[] acc = new int[2];
			int[] hand = new int[2];
			var idx = new Dictionary<string, int>(){["L"] = 0,["R"] = 1};
			int dist = 0;
			int sum = 0;
			for (var i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Split().ToArray();
				var (a, s) = (int.Parse(line[0]), line[1]);
				int move = idx[s];
				hand[move]++;
				dist = Math.Abs(a - acc[move]);
				acc[move] = a;
				if (hand[move] >= 2) sum += dist;
			}
			Console.WriteLine(sum);
		}

		public void Ac367()
		{
			var c = Console.ReadLine().ToCharArray();
			var list = new List<char>(c);
			int idx = list.Count - 1;
			while (list[idx] == '0')
			{
				list.RemoveAt(idx);
				idx = list.Count - 1;
			}

			if (list[idx] == '.') list.RemoveAt(idx);
			Console.WriteLine(string.Join("", list));
		}

		public void Ac364()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w) = (line[0], line[1]);
			var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (si, sj) = (xy[0], xy[1]);
			var c = new string[h];
			for (var i = 0; i < h; i++) c[i] = Console.ReadLine();
			// 上下左右
			var d = new Dictionary<char, (int, int)>()
			{
				['U'] = (-1, 0),
                ['D'] = (1, 0),
                ['L'] = (0, -1),
                ['R'] = (0, 1),
            };
			var x = Console.ReadLine();
			si--; sj--;
			for (var i = 0; i < x.Length; i++)
			{
				var (di, dj) = d[x[i]];
				int ni = si + di, nj = sj + dj;
				if (0 <= ni && ni < h && 0 <= nj && nj < w && c[ni][nj] == '.')
				{
					si = ni;
					sj = nj;	
				}
			}
			Console.WriteLine($"{si + 1} {sj + 1}");
		}

		public void Ac363()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], t = line[1], p = line[2];
			var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int ans = 0;

			while (true)
			{
				int count = 0;
				for (var i = 0; i < n; i++)
				{
					if (l[i] >= t)
					{
						count++;
					}
					l[i]++;
				}
				if (count >= p) break;
				ans++;
			}
			Console.WriteLine(ans);
		}

		public void Ac358()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, a) = (line[0], line[1]);
			int procTime = 0;

			for (var i = 0; i < n; i++)
			{
				int time = t[i];
				if (procTime <= time) procTime = time + a;
				else procTime += a;
				Console.WriteLine(procTime);
			}
		}

		public void Ac356()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var x = new List<int[]>();
			for (var i = 0; i < n; i++) x.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());

			for (var j = 0; j < m; j++)
			{
				int s = 0;
				for (var i = 0; i < n; i++)
				{
					s += x[i][j];
				}
				if (s < a[j])
				{
					Console.WriteLine("No");
					return;
				}
			}
			Console.WriteLine("Yes");
		}

		// 辞書順の問題
        public void Ac354()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            int t = 0;
            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().ToArray();
                var (s, c) = (line[0], line[1]);
                list.Add(s);
                t += int.Parse(c);
            }
            list.Sort();
            Console.WriteLine(list[t % n]);
        }

		public void Ac350()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, q) = (line[0], line[1]);
			var dental = new int[n];
			for (var i = 0; i < n; i++) dental[i]++;
			for (var i = 0; i < q; i++) dental[t[i] - 1] ^= 1;
			Console.WriteLine(dental.Sum());
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

		// 部分文字列の列挙
		public void Ac347()
		{
			string s = Console.ReadLine();
			int n = s.Length;
			var st = new HashSet<string>();
			for (var i = 0; i < n; i++)
			{
				string t = "";
				for (var j = i; j < n; j++)
				{
					t += s[j];
					st.Add(t);
				}

			}
			Console.WriteLine(st.Count);
		}

		public void Ac344()
		{
			var a = new List<int>();
			while (true)
			{
				int n = int.Parse(Console.ReadLine());
				a.Add(n);
				if (n == 0) break;
			}
			a.Reverse();
			for (var i = 0; i < a.Count; i++)
			{
				Console.WriteLine(a[i]);
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

		public void Ac338()
		{
			char[] chars = Console.ReadLine().ToArray();
			var dict = new Dictionary<char, int>();
			for (var i = 0; i < chars.Length; i++)
			{
				if (!dict.TryAdd(chars[i], 1)) dict[chars[i]]++;
			}
			int value = int.MinValue;
			char ans = char.MaxValue;
			foreach (var (k, v) in dict)
			{
				if (value < v)
				{
					value = v;
					ans = k;
				}
				else if (value == v && k < ans)
				{
					ans = k;
				}
			}
			Console.WriteLine(ans);
		}

		public void Ac336()
		{
			int s = int.Parse(Console.ReadLine());
			char[] bin = Convert.ToString(s, 2).Reverse().ToArray();
			int ans = 0;
			for (var i = 0; i < bin.Length; i++)
			{
				if (bin[i] != '0') break;
				ans++;
			}
			Console.WriteLine(ans);
		}

		public void Ac333()
		{
			var s = Console.ReadLine();
            var t = Console.ReadLine();
			var p = new Dictionary<char, int>()
			{
				['A'] = 0,
                ['B'] = 1,
                ['C'] = 2,
                ['D'] = 3,
                ['E'] = 4
            };

			Argorithm.Argorithm algo = new Argorithm.Argorithm();
			if (algo.Pentagon(p[s[0]], p[s[1]]) == algo.Pentagon(p[t[0]], p[t[1]]))
			{
				Console.WriteLine("Yes");
			}
			else
			{
				Console.WriteLine("No");
			}
        }

		public void Ac326()
		{
			int n = int.Parse(Console.ReadLine());
			int a = n / 100;
			int b = (n % 100) / 10;
			int c = n % 10;

            while (a*b != c)
			{
				string k = string.Join("", a * 100 + b * 10 + c + 1);
				a = int.Parse(k[0].ToString());
                b = int.Parse(k[1].ToString());
                c = int.Parse(k[2].ToString());
            }
			Console.WriteLine(a*100 + b*10 + c);
		}

		public void Ac324()
		{
			long n = long.Parse(Console.ReadLine());
			while (n % 2 == 0) n /= 2;
			while (n % 3 == 0) n /= 3;
			string ans = "";
			if (n >= 2) ans = "No";
			else ans = "Yes";
			Console.WriteLine(ans);
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

		public void Ac318()
		{
			int n = int.Parse(Console.ReadLine());
			var covered = new bool[101, 101];
			for (var i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var (a, b, c, d) = (line[0], line[1], line[2], line[3]);
				for (var x = a; x < b; x++)
				{
					for (var y = c; y < d; y++)
					{
						covered[x, y] = true;
					}
				}
			}

			int count = 0;
			for (var i = 0; i < 101; i++)
			{
				for (var j = 0; j < 101; j++)
				{
					if (covered[i, j]) count++;
				}
			}
			Console.WriteLine(count);
		}

		public void Ac315()
		{
			int m = int.Parse(Console.ReadLine());
			var d = Console.ReadLine().Split().Select(int.Parse).ToList();
			int middle = (d.Sum() + 1) / 2;
			int sum = 0;
			int month = 0, day = 0;
			for (var i = 0; i < m; i++)
			{
				month = i + 1;
				day = middle - sum;
				sum += d[i];
				if (middle <= sum) break;
			}
			Console.WriteLine($"{month} {day}");
		}

		public void Ac311()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, d) = (line[0], line[1]);
			var s = new string[n];
			bool[] free = new bool[d];

			for (var i = 0; i < n; i++) s[i] = Console.ReadLine();
			for (var j = 0; j < d; j++)
			{
				bool isFree = true;
				for (var i = 0; i < n; i++)
				{
					if (s[i][j] == 'x')
					{
						isFree = false;
						break;
					}
				}
				if (isFree) free[j] = isFree;
			}

			if (free.Count(x => x == true) == 0)
			{
				Console.WriteLine(0);
				return;
			}

			int ans = 1, count = 1;
			for (var i = 0; i < d - 1; i++)
			{
				if (free[i] && free[i + 1]) count++;
				else count = 1;
				ans = Math.Max(ans, count);
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

		public void Ac307()
		{
			int n = int.Parse(Console.ReadLine());
			var s = new string[n];
			for (var i = 0; i < n; i++) s[i] = Console.ReadLine();

			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (i == j) continue;
					string t = s[i] + s[j];

					if (t == string.Join("", t.Reverse()))
					{
						Console.WriteLine("Yes");
						return;
					}
				}
			}
			Console.WriteLine("No");
		}

		public void Ac306()
		{
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			ulong sum = 0;
			for (var i = 0; i < 64; i++) sum += ((ulong)a[i]) << i;
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

		public void Ac292()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, q) = (line[0], line[1]);
			var player = new int[n];
			for (var i = 0; i < q; i++)
			{
				var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var (c, x) = (query[0], query[1]);
				x--;
				switch (c)
				{
					case 1:
						player[x]++;
						break;
					case 2:
						player[x] = -1;
						break;
					case 3:
						Console.WriteLine(player[x] == -1 || player[x] == 2 ? "Yes" : "No");
						break;
				}
			}
		}
		// スライスの設計がめんどくさい
		public void Ac291()
		{
			int n = int.Parse(Console.ReadLine());
			var x = Console.ReadLine().Split().Select(int.Parse).ToList();
			x.Sort();
			var stA = x.GetRange(n, x.Count - n);
			var stB = stA.GetRange(0, stA.Count - n);
			int sum = stB.Sum();
			Console.WriteLine((double)sum / ((x.Count) - 2*n));
		}

		public void Ac288()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, k) = (line[0], line[1]);
			var s = new List<string>();
			for (var i = 0; i < n; i++) s.Add(Console.ReadLine());
			var ss = s.GetRange(0, k);
			ss.Sort();
			for (var i = 0; i < k; i++)
			{
				Console.WriteLine(ss[i]);
			}
		}

		public void Ac287()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			string[] s = new string[n];
			var t = new HashSet<string>();
			for (var i = 0; i < n; i++) s[i] = Console.ReadLine();
			for (var i = 0; i < m; i++) t.Add(Console.ReadLine());
			int count = 0;
			for (var i = 0; i < n; i++)
			{
				string ss = s[i].Substring(6 - 3, 3);
				if (t.Contains(ss)) count++;
			}
			Console.WriteLine(count);
		}

		public void Ac282()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			var s = new List<char[]>();
			for (var i = 0; i < n; i++) s.Add(Console.ReadLine().ToArray());

			int ans = 0;
			for (var i = 0; i < n; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					bool isOk = true;
					for (var k = 0; k < m; k++)
					{
						if (s[i][k] == 'x' && s[j][k] == 'x')
						{
							isOk = false;
							break;
						}
					}
					if (isOk) ans++;
				}
			}
			Console.WriteLine(ans);
		}

		public void Ac280()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
			var s = new long[n];
			long sum = 0;
			for (var i = 0; i < n; i++)
			{
				s[i] = a[i] - sum;
				sum += s[i];
			}

			Console.WriteLine(string.Join(" ", s));
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

		public void Ac277()
		{
			int n = int.Parse(Console.ReadLine());
			var t = new HashSet<string>()
			{
				"A", "2", "3", "4", "5", "6", "7",
				"8", "9", "T", "J", "Q", "K"
			};
			int count = 0;
			var s = new List<string>();
			var list = new List<string>();
			for (var i = 0; i < n; i++) s.Add(Console.ReadLine());
			for (var i = 0; i < n; i++)
			{
				char[] chars = s[i].ToArray();
				string ss = chars[0].ToString();
				if (!(ss == "H" || ss == "D" || ss == "C" || ss == "S")) break;
				if (!t.Contains(chars[1].ToString())) break;
				if (list.Contains(s[i])) break;
				list.Add(s[i]);
				count++;
			}
			Console.WriteLine(count == n ? "Yes" : "No");
		}

		public void Ac274()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w) = (line[0], line[1]);
			var c = new string[h];
			int[] cnt = new int[w];
			for (var i = 0; i < h; i++) c[i] = Console.ReadLine();
			for (var i = 0; i < h; i++)
			{
				for (var j = 0; j < w; j++)
				{
					if (c[i][j] == '#') cnt[j]++;
				}
			}
			Console.WriteLine(string.Join(" ", cnt));
		}

		public void Ac270()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (x, y, z) = (line[0], line[1], line[2]);

			if (y < 0)
			{
				x = -x;
				y = -y;
				z = -z;
			}
			int ans = 0;
			if (x < y)
			{
				ans = Math.Abs(x);
			}
			else
			{
				if (z > y)
				{
					ans = -1;
				}
				else
				{
					ans = Math.Abs(z) + Math.Abs(x - z);
				}
			}
			Console.WriteLine(ans);
		}

		// 偶奇に着目（中心点（8,8）からのチェビシェフ距離を計算）
		public void Ac264()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (r, c) = (line[0], line[1]);
			int dist = Math.Max(Math.Abs(r - 8), Math.Abs(c - 8));
			Console.WriteLine(dist % 2 == 0 ? "white" : "black");
		}

		public void Ac261()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new List<char[]>();
			for (var i = 0; i < n; i++) a.Add(Console.ReadLine().ToArray());
			var target = new string[] { "WL", "LW", "DD" };
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (i == j) continue;
					var s = a[i][j] + a[j][i].ToString();
					if (!target.Contains(s))
					{
						Console.WriteLine("incorrect");
						return;
					}
				}
			}
			Console.WriteLine("correct");
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

		public void Ac245()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
			var b = Enumerable.Range(0, a.Max() + 2).ToList();
			foreach (var b_i in b)
			{
				if (!a.Contains(b_i))
				{
					Console.WriteLine(b_i);
					return;
				}
			}
		}

		public void Ac244()
		{
			int n = int.Parse(Console.ReadLine());
			string t = Console.ReadLine();
			int cur = 0;
			var move = new int[] {1, -1, -1, 1};
			int[] x_y = new int[2]; 

			foreach (var s in t)
			{
				int idx = cur % 2 == 0 ? 0 : 1;
				if (s == 'S') x_y[idx] += move[cur];
				else cur = (cur + 1) % 4;
			}
			Console.WriteLine(string.Join(" ", x_y));
		}

		public void Ac242()
		{
			var s = Console.ReadLine().ToList();
			s.Sort();
			Console.WriteLine(string.Join("", s));

			
		}

		public void Ac241()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			var dict = new Dictionary<int, int>();
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

			for (var i = 0; i < n; i++)
			{
				if (!dict.TryAdd(a[i], 1)) dict[a[i]]++;
			}
			for (var i = 0; i < m; i++)
			{
				// キーが存在したとき
				if (dict.TryGetValue(b[i], out int value))
				{
					// すでに登場しているなら
					if (value == 0)
					{
                        Console.WriteLine("No");
                        return;
                    }
				}
				else
				{
					Console.WriteLine("No");
					return;
				}
				dict[b[i]]--;
			}
			Console.WriteLine("Yes");
		}

		public void Ac240()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
			Console.WriteLine(a.Count);
		}

		// 文字列連結はTLEのためStringBuilderで高速化
		public void Ac237()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w) = (line[0], line[1]);
			var a = new List<int[]>();
			for (var i = 0; i < h; i++) a.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
			for (var j = 0; j < w; j++)
			{
				StringBuilder sb = new StringBuilder();
				for (var i = 0; i < h; i++)
				{
					sb.Append(a[i][j] + " ");
				}
				Console.WriteLine(sb);
			}
		}

		public void Ac232()
		{
			string s = Console.ReadLine();
            string t = Console.ReadLine();
			int n = s.Length;
			var list = new List<int>();

			for (var i = 0; i < n; i++)
			{
				int k = (t[i] - s[i]) % 26;
				list.Add(k);
			}

			for (var i = 0; i < n - 1; i++)
			{
				if (list[i] != list[i + 1])
				{
					Console.WriteLine("No");
					return;
				}
			}
			Console.WriteLine("Yes");
        }

		public void Ac231()
		{
			int n = int.Parse(Console.ReadLine());
			var dict = new Dictionary<string, int>();
			for (var i = 0; i < n; i++)
			{
				string key = Console.ReadLine();
				if (!dict.TryAdd(key, 1)) dict[key]++;
			}

			int max = 0;
			string ans = "";
			foreach (var (k, v) in dict)
			{
				if (max < v)
				{
					max = v;
					ans = k;
				}
			}
			Console.WriteLine(ans);
		}

		// 部分文字列：sがtに含まれるかどうかだけ見ればいい
		public void Ac230()
		{
			string s = Console.ReadLine();
			string t = "";
			for (var i = 0; i < 10; i++) t += "oxx";
			Console.WriteLine(t.Contains(s) ? "Yes" : "No");
		}

		public void Ac224()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w) = (line[0], line[1]);
			var a = new List<int[]>();
			for (var i = 0; i < h; i++) a.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
			for (var i = 0; i < h - 1; i++)
			{
				for (var j = 0; j < w - 1; j++)
				{
					if (a[i][j] + a[i + 1][j + 1] > a[i][j + 1] + a[i + 1][j])
					{
						Console.WriteLine("No");
						return;
					}
				}
			}
			Console.WriteLine("Yes");
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

		// 変数を削る
		public void Ac214()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int s = line[0], t = line[1];
			int count = 0;

			for (var a = 0; a <= s; a++)
			{
				for (var b = 0; b <= s; b++)
				{
					// 条件が成立しない
					if (a + b > s) continue;

					// cの取りうる範囲であればカウント
					if (a == 0 || b == 0)
					{
						count += (s - a - b + 1);
					}
					else
					{
						int cMax = Math.Min(s - a - b, t / (a * b));
						if (cMax >= 0)
						{
							count += cMax + 1;
						}

					}
				}
			}
			Console.WriteLine(count);
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

		public void Ac206()
		{
			int n = int.Parse(Console.ReadLine());
			int s = 0;
			int ans = 0;

			for (var i = 1; i <= n; i++)
			{
				s += i;
				ans = i;
				if (s >= n) break;
			}
			Console.WriteLine(ans);

		}

		public void Ac202()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToList();
			var b = Enumerable.Range(1, n).ToList();
			Console.WriteLine(a.Intersect(b).Count() == n ? "Yes" : "No");
		}

		public void Ac197()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w, x, y) = (line[0], line[1], line[2], line[3]);
			var s = new string[h];
			for (var i = 0; i < h; i++) s[i] = Console.ReadLine();
			int[] dy = { -1, 1, 0, 0 };
            int[] dx = { 0, 0, -1, 1 };

			x--; y--;
			int count = 1;
			for (var i = 0; i < 4; i++)
			{
				int ni = x + dy[i], nj = y + dx[i];
				while ((0 <= ni && ni < h) && (0 <= nj && nj < w) && s[ni][nj] != '#')
				{
					count++;
					ni += dy[i];
					nj += dx[i];
				}
			}
			Console.WriteLine(count);
		}

		public void Ac185()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m, t) = (line[0], line[1], line[2]);
			int pre = 0;
			int battery = n;
			for (var i = 0; i < m; i++)
			{
				var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var (a, b) = (arr[0], arr[1]);
				battery -= a - pre;
				if (battery <= 0)
				{
					Console.WriteLine("No");
					return;
				}
				battery = Math.Min(n, battery + (b - a));
				pre = b;
			}
			Console.WriteLine(battery - (t - pre) > 0 ? "Yes" : "No");
		}

		public void Ac177()
		{
			string s = Console.ReadLine();
            string t = Console.ReadLine();
			int n = s.Length - t.Length + 1;
			int tLen = t.Length;
			int ans = 100_000_000;
			for (var i = 0; i < n; i++)
			{
				string k = s.Substring(i, tLen);
				int diffCount = 0;
				for (var j = 0; j < tLen; j++)
				{
					if (k[j] != t[j]) diffCount++;
				}
				ans = Math.Min(ans, diffCount);
			}
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

		public void Ac171()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var p = Console.ReadLine().Split().Select(int.Parse).ToList();
			var (n, k) = (line[0], line[1]);
			p.Sort();
			Console.WriteLine(p.GetRange(0, k).Sum());
		}

		public void Ac166()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, k) = (line[0], line[1]);
			int[] cnt = new int[n];

			for (var i = 0; i < k; i++)
			{
				int d = int.Parse(Console.ReadLine());
				var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (var j = 0; j < d; j++)
				{
					cnt[a[j] - 1]++;
				}
			}
			Console.WriteLine(cnt.Count(x => x == 0));
		}

		public void Ac165()
		{
			// Overflow対策でlong型で対応
			long x = long.Parse(Console.ReadLine());
			long a = 100;
			int year = 0;

			while (a < x)
			{
				a += a / 100;
				year++;
			}
			Console.WriteLine(year);
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

		public void Ac118()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			int[] k = new int[m];
			for (var i = 0; i < n; i++)
			{
				var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int t = a[0];
				for (var j = 1; j <= t; j++)
				{
					k[a[j] - 1]++;
				}
			}
			Console.WriteLine(k.Count(x => x == n));
		}

		public void Ac116()
		{
			int s = int.Parse(Console.ReadLine());
			var st = new HashSet<int>();
			st.Add(s);
			while (true)
			{
				if (s % 2 == 0) s /= 2;
				else s = 3 * s + 1;
				if (st.Contains(s)) break;
				st.Add(s);
			}
			Console.WriteLine(st.Count + 1);
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


		public void Ac106()
		{
			int n = int.Parse(Console.ReadLine());
			int divisor = 0;
			int ans = 0;

			for (var i = 1; i <= n; i++)
			{
				if (i % 2 == 0) continue;
				divisor = 0;
				for (var j = 1; j <= i; j++)
				{
					if (i % j == 0)
					{
						divisor++;
					}
				}
				if (divisor == 8) ans++;
			}
			Console.WriteLine(ans);
		}

		public void Ac105()
		{
			int n = int.Parse(Console.ReadLine());

			while (n >= 4)
			{
				if (n % 4 == 0 || n % 7 == 0)
				{
					Console.WriteLine("Yes");
					return;
				}
				n -= 4;
			} 
			
			Console.WriteLine("No");
			
		}

		// 辞書から最大値を取得
		public void Ac091()
		{
			int n = int.Parse(Console.ReadLine());
			var dict = new Dictionary<string, int>();
			for (var i = 0; i < n; i++)
			{
				string s = Console.ReadLine();
				if (!dict.TryAdd(s, 1))
				{
					dict[s]++;
				}
			}

			int m = int.Parse(Console.ReadLine());
			for (var i = 0; i < m; i++)
			{
				string t = Console.ReadLine();
				if (dict.ContainsKey(t)) dict[t]--;
			}
			Console.WriteLine(Math.Max(dict.Values.Max(), 0));
		}

		public void Ac088()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToList();
			var b = a.OrderByDescending(x => x).ToArray();
			int sum = 0;
			for (var i = 0; i< n; i++)
			{
				if (i % 2 == 0) sum += b[i];
				else sum -= b[i];
			}
			Console.WriteLine(sum);
		}

		public void Ac087()
		{
			var line = new int[4];
			for (var i = 0; i < 4; i++) line[i] = int.Parse(Console.ReadLine());
			int a = line[0], b = line[1], c = line[2], x = line[3];

			int count = 0;
			// 全探索：O(N^2)
			for (var i = 0; i <= a; i++)
			{
				for (var j = 0; j <= b; j++)
				{
					int k = x - (500*i + 100*j);
					if (0 <= k && k <= 50*c)
					{
						count++;
					}
				}
			}

			// 全探索:O(N^3)
			for (var i = 0; i <= a; i++)
            {
                for (var j = 0; j <= b; j++)
                {
					for (var k = 0; k <= c; k++)
					{
						if (500*i + 100*j + 50*k == x)
						{
							count++;
						}
					}
                    
                }
            }
            Console.WriteLine(count);
		}

		public void Ac085()
		{
			int n = int.Parse(Console.ReadLine());
			var st = new HashSet<string>();
			for (var i = 0; i < n; i++) st.Add(Console.ReadLine());
			Console.WriteLine(st.Count);
		}

		public void Ac083()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], a = line[1], b = line[2];
			int sum = 0;
			for (var i = 1; i <= n; i++)
			{
				List<string> digits = i.ToString().ToCharArray().Select(c => c.ToString()).ToList();
				int s = digits.Sum(c => int.Parse(c.ToString()));
				if (a <= s && s <= b)
				{
					sum += i;
				}
			}
			Console.WriteLine(sum);
		}

		// 文字列の辞書順の比較
		// C#では文字列で比較演算子は使えないため、string.Compareで比較する
		public void Ac082()
		{
			var s = Console.ReadLine().OrderBy(c => c);
            var t = Console.ReadLine().OrderByDescending(x => x);
			string ss = string.Join("", s);
			string ts = string.Join("", t);
			Console.WriteLine(string.Compare(ss, ts) < 0 ? "Yes" : "No");
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

		// 深いコピー
		public void Ac075()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (h, w) = (line[0], line[1]);
			var s = new char[h][];
			for (var i = 0; i < h; i++) s[i] = Console.ReadLine().ToCharArray();
			int[] di = { -1, 1, 0, 0, -1, 1, 1, -1 };
            int[] dj = { 0, 0, -1, 1, 1, 1, -1, -1 };
            var c = s.Select(row => row.ToArray()).ToArray();

            for (var i = 0; i < h; i++)
			{
				for (var j = 0; j < w; j++)
				{
					int count = 0;
					for (var k = 0; k < 8; k++)
					{
						int ni = i + di[k], nj = j + dj[k];
						if ((0 <= ni && ni < h) && (0 <= nj && nj < w) && s[ni][nj] == '#')
						{
							count++;
						}
					}
					if (c[i][j] != '#')
						// 数値に変換
						c[i][j] = (char)('0' + count);
				}
				Console.WriteLine(new string(c[i]));
			}
        }

		// 差集合
		public void Ac071()
		{
			var s = new HashSet<char>(Console.ReadLine().ToArray());
			var t = new HashSet<char>();
			for (var i = 'a'; i <= 'z'; i++) t.Add(i);
			t.ExceptWith(s);
			Console.WriteLine(t.Count != 0 ? t.Min() : "None");
		}

        public void Ac067()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var l = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, k) = (line[0], line[1]);
            var list = l.OrderByDescending(x => x).ToList();
            Console.WriteLine(list.GetRange(0, k).Sum());
        }

        public void Ac066()
		{
			string s = Console.ReadLine();
			int n = s.Length;
			int ans = 1;

			for (var i = 0; i < n; i++)
			{
				string t = s.Substring(0, n - i - 1);
				int slice = t.Length;
				if (slice % 2 == 0)
				{
                    var (tl, tr) = (t.Substring(0, slice / 2), t.Substring(slice / 2));
                    if (tl == tr)
					{
						ans = slice;
						break;
					}
				}
			}
			Console.WriteLine(ans);
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

		public void Ac044()
		{
			string w = Console.ReadLine();
			var dict = new Dictionary<string, int>();
			for (var i = 0; i < w.Length; i++)
			{
				string key = w[i].ToString();
				if (!dict.TryAdd(key, 1)) dict[key]++;
			}
			foreach (var (k, v) in dict)
			{
				if (v % 2 != 0)
				{
					Console.WriteLine("No");
					return;
				}
			}
			Console.WriteLine("Yes");
		}
		
	}
}

