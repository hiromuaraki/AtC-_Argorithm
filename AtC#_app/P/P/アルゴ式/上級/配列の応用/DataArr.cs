using System;
namespace P.アルゴ式.上級.配列の応用
{
	public class DataArr
	{
		public DataArr()
		{
		}

		static int N, Q, L, M, K;
		public void Q1()
		{
			N = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();
			Q = int.Parse(Console.ReadLine());
			while (Q-- > 0)
			{
				var queryType = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int type = queryType[0], k = queryType[1];
				if (type == 0)
				{
					int v = queryType[2];
					a.Insert(k, v);
				}
				else if (type == 1)
				{
					a.RemoveAt(k);
				}
				else
				{
					Console.WriteLine(a.Count(x => x == k));
				}
			}
		}

		public void Q2()
		{
			N = int.Parse(Console.ReadLine());
			var a = Enumerable.Range(1, N).ToList();
			while (a.Count != 1)
			{
				a.RemoveAt(0);
				a.Add(a[0]);
				a.RemoveAt(0);
			}
			Console.WriteLine(string.Join("", a));
		}

		public void Q3()
		{
			N = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();
			Q = int.Parse(Console.ReadLine());
			while (Q-- > 0)
			{
				var queryType = Console.ReadLine().Split().Select(int.Parse).ToArray();
				if (queryType[0] == 0)
				{
					a.Reverse();
				}
				else if (queryType[0] == 1)
				{
					a.Add(queryType[1]);
				}
				else
				{
					int n = a.Count;
					if (n == 0)
					{
						Console.WriteLine("Error");
					}
					else
					{
						n--;
						Console.WriteLine(a[n - 1]);
						a.RemoveAt(n - 1);
					}
				}
			}
		}

		public void Q4()
		{
			N = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();
			Q = int.Parse(Console.ReadLine());
			a.Reverse();
			while (Q-- > 0)
			{
				var queryType = Console.ReadLine().Split().Select(int.Parse).ToArray();
				if (queryType[0] == 0)
				{
					a.Add(queryType[1]);
				}
				else
				{
					int n = a.Count;
					if (n == 0)
					{
						Console.WriteLine("Error");
					}
					else
					{
						n--;
						Console.WriteLine(a[n]);
						a.RemoveAt(n);

					}
				}
			}
		}

		public void Q5()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();
			int q = int.Parse(Console.ReadLine());
            int size = n + q + 10;
            int[] deque = new int[size * 2];
            int head = size;
            int tail = size;
            // 初期データ
            foreach (var v in a)
            {
                deque[tail++] = v;
            }
            while (q-- > 0)
			{
				var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int queryType = query[0], k = query[1];
				if (queryType == 0)
				{
					deque[--head] = k;
				}
				else if (queryType == 1)
				{
					deque[tail++] = k;
				}
				else
				{
					if (k < tail - head)
					{
						Console.WriteLine(deque[head + k]);
					}
					else
					{
						Console.WriteLine("Error");
					}
				}
			}
		}

		// シミュレーション＋状態管理（少し実装重い）
		public void Q6()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int h = line[0], w = line[1];
			int[,] table = new int[h,w];
			// 4近傍用の座標
			int[] di = new int[] { -1, 1, 0, 0};
            int[] dy = new int[] { 0, 0, -1, 1 };
			for (var i = 0; i < h; i++)
			{
				var s = Console.ReadLine().ToCharArray();
				for (var j = 0; j < w; j++)
				{
					if (s[j] == '#') table[i, j] = 1;
				}
			}

            int Q = int.Parse(Console.ReadLine());
			for (var i = 0; i < Q; i++)
			{
				var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int type = query[0];
				int p = query[1], q = query[2];
				int cnt = 0;
				for (var j = 0; j < 4; j++)
				{
					int row = p + di[j];
					int col = q + dy[j];
					if ((0 <= row && row < h) && (0 <= col && col < w))
					{
						if (type == 0)
						{
							table[row, col] ^= 1;
						}
						else
						{
							if (table[row, col] == 1)
							{
								cnt++;
							}
						}
					}
				}
				if (type == 0)
				{
					table[p, q] ^= 1;
				}
				if (table[p, q] == 1)
				{
					cnt++;
				}
				if (type == 1)
				{
					Console.WriteLine(cnt);
				}
			}
		}
	}
}

