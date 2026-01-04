using System;
namespace P.JOI
{
	public class Joi
	{
		public Joi()
		{
		}

		public void Q1()
		{
			int h = 0, m = 0, s = 0;
			for(int i = 0; i < 3; i++)
			{
				// 3600h + 60m + s（時分を秒に変換し差を求める）
				string[] line = Console.ReadLine().Split();
				int h1 = 3600 * int.Parse(line[0]);
                int h2 = 3600 * int.Parse(line[3]);
                int m1 = 60 * int.Parse(line[1]);
                int m2 = 60 * int.Parse(line[4]);
                int s1 = int.Parse(line[2]);
                int s2 = int.Parse(line[5]);

				int x = (h2 + m2 + s2) - (h1 + m1 + s1);
				Console.WriteLine("{0} {1} {2}", x / 3600, (x / 60) % 60, x % 60);
            }
		}

		public void Q2()
		{
			string[] line = Console.ReadLine().Split();
			int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            int z = int.Parse(line[2]);
			int ans = (z * y) / x;
			if ((z * y) % x == 0) { ans--; }
			Console.WriteLine(ans);
        }

		public void Q3()
		{
			int n = int.Parse(Console.ReadLine());
			char[] c = Console.ReadLine().ToCharArray();
			string ans = "No";
			if (c.Distinct().Count() >= 3) ans = "Yes";
			Console.WriteLine(ans);

		}

		// JJJOOOIIIII
		public void Q4()
		{
			int n = int.Parse(Console.ReadLine());
			char[] c = Console.ReadLine().ToCharArray();
			var cc = c.OrderByDescending(x => x).ToArray();
			
			int si = 0;
			for (var i = 0; i < n; i++)
			{
				if (cc[i] != 'J') continue;
				(cc[si], cc[i]) = (cc[i], cc[si]);
				si++;
			}
			Console.WriteLine(String.Join("", cc));
		}

		public void Q5()
		{
			int n = int.Parse(Console.ReadLine());
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] cnt = new int[n];
			for (var i = 0; i < a.Length; i++)
			{
				a[i] -= 1;
				cnt[a[i]]++;
			}
			int num = Array.IndexOf(cnt, cnt.Min()) + 1;
            Console.WriteLine(num);
		}

		public void Q6()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToList();
			// リストのコピー（新しいリストを作り元データを参照しない）
			var b = new List<int>(a); // Python: a[:]と同じ＝リストコピー
			for (var i = 1; i < n; i++)
			{
				for (var j = 0; j < n - i; j++)
				{
					b[j] = Math.Abs(b[j] - b[j + 1]);
				}
				// スライス記法（リストの部分更新を行う）
				b = b.GetRange(0, n - i);
			}
			Console.WriteLine(b.First());
		}

		public void Q7()
		{
			int n = int.Parse(Console.ReadLine());
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			for (var i = 0; i < n; i++)
			{
				int rank = 1;
				for (var j = 0; j < n; j++)
				{
					if (a[i] > a[j]) rank++;
				}
				Console.WriteLine(rank);
			}
		}

		public void Q8()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var b = new HashSet<int>(Console.ReadLine().Split().Select(int.Parse));
			Dictionary<int, int> box = new Dictionary<int, int>();

			for (var i = 0; i < a.Length; i++)
			{
				// キーが存在しない場合キー値のペアを新規追加
				if (!box.TryAdd(a[i], 1))
				{
					box[a[i]]++;
				}
			}

			int ans = 0;
			foreach (var b_i in b)
			{
				if (box.ContainsKey(b_i)) ans += box[b_i];
			}
			Console.WriteLine(ans);
		}

		public void Q9()
		{
			int n = int.Parse(Console.ReadLine());
			string s = Console.ReadLine();
			for (var i = 0; i < n; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					for (var k = j + 1; k < n; k++)
					{
						if (s[i] == 'I' && s[j] == 'O' && s[k] == 'I')
						{
							Console.WriteLine("Yes");
							return;

						}
					}
				}
			}
			Console.WriteLine("No");
		}

		public void Q10()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int current = 1, maxLen = 1;

			for (var i = 0; i < n - 1; i++)
			{
				// 昇順の連続区間なら区間を広げる
				if (a[i] <= a[i + 1]) current++;
				else current = 1;
				maxLen= Math.Max(maxLen, current);
            }
			Console.WriteLine(maxLen);
			
		}
	}
}

