using System;
namespace P.アルゴ式.中級.二分探索
{
	public class BinarySearch2
	{
		public BinarySearch2()
		{
		}

		// 二分探索
		public void Q1()
		{
			var n = double.Parse(Console.ReadLine());
			double ok = 0, ng = 100;
			while (ng - ok > 1e-4)
			{
				double mid = (ok + ng) / 2;
				if (mid * (mid * (mid + 1) + 2) + 3 < n)
				{
					ok = mid;
				}
				else
				{
					ng = mid;
				}
			}
			Console.WriteLine(ok);
		}

        // 0(今年）〜 5年後までの預金額をシミュレーションする関数
        public double Saving5(double n, double x)
		{
			double result = n + 1;
			for (var i = 0; i < 5; i++)
			{
				result = result * x + 1;
			}
			return result;
		}

		public void Q2()
		{
			var line = Console.ReadLine().Split().Select(double.Parse).ToArray();
			double n = line[0], m = line[1];
			double ok = 0, ng = 100;
			// 十分な精度になるまでx（利率）を探す
			while (ng - ok > 1e-4)
			{
				double mid = (ok + ng) / 2;
				if (Saving5(n, mid) < m)
				{
					ok = mid;
				}
				else
				{
					ng = mid;
				}
			}
			Console.WriteLine(ok);
		}

		// Ax ≧ Bi
		// bisect_leftで対応
		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(long.Parse).ToArray();

			for (var i = 0; i < m; i++)
			{
				int left = 0, right = n;
				// 最小のインデックスが見つかるまで
				while (left != right)
				{
					int mid = (left + right) / 2;
					if (a[mid] >= b[i])
					{
						right = mid;
					}
					else
					{
						left = mid + 1;
					}
				}
				Console.WriteLine(left);
			}
        }

        // Ax ≦ Bi
		// bisect_rightで対応
        public void Q4()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
			Array.Sort(a);
			for (var i = 0; i < b.Length; i++)
			{
				int left = 0, right = n;
				while (left != right)
				{
					int mid = (left + right) / 2;
					if (a[mid] <= b[i])
					{
						left = mid + 1;
					}
					else
					{
						right = mid;
					}
				}
				Console.WriteLine(left);
			}
        }

		public void Q5()
		{
			var line = Console.ReadLine().Split();
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
			int n = int.Parse(line[0]);
			long k = long.Parse(line[1]);
			Array.Sort(a);
			long count = 0;
			for (var i = 0; i < n; i++)
			{
				int left = 0, right = n;
				while (right != left)
				{
					int mid = (left + right) / 2;
					if (a[mid] >= k - a[i])
					{
						right = mid;
					}
					else
					{
						left = mid + 1;
					}
				}
				count += n - left;
			}
			Console.WriteLine(count);
		}

		public void Q6()
		{
			int n = int.Parse(Console.ReadLine());
			var w = Console.ReadLine().Split().Select(long.Parse).ToArray();
			var b = w.OrderBy(x => x).ToList();

			for (var i = 0; i < n; i++)
			{
				int left = 0, right = n;
				while (left != right)
				{
					int mid = (left + right) / 2;
					if (b[i] < w[mid])
					{
						left = mid + 1; 
					}
					else
					{
						right = mid;
					}
				}
				Console.WriteLine(left);
			}
		}

		public void Q7()
		{
            var nk = Console.ReadLine()
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();
            int n = nk[0];
            int k = nk[1];

            long[] a = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long[] x = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            for (var i = 0; i < n; i++)
            {
                int left = 0;
                int right = k;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (x[mid] <= a[i])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                Console.WriteLine(left);
            }
        }

		public long F(long d)
		{
			return d * (d + 1) / 2;
		}

		public void Q8()
		{
			int n = int.Parse(Console.ReadLine());
			var x = Console.ReadLine().Split().Select(long.Parse).ToArray();

			for (var i = 0; i < n; i++)
			{
				long left = 0;
				long right = (long)2e9;
				while (left < right)
				{
					long mid = left + (right - left) / 2;
					if (F(mid) >= x[i])
					{
						right = mid;
					}
					else
					{
						left = mid + 1;
					}
				}
				Console.WriteLine(left);
			}
		}

		public int L(int[] l, double x)
		{
			int sum = 0;
			for (var i = 0; i < l.Length; i++)
			{
				sum += (int)(l[i] / x);
			}
			return sum;
		}

		public void Q9()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], k = line[1];
			double left = 0;
			double right = 1e5;
			while (right - left > 1e-8)
			{
				double mid = (left + right) / 2;
				if (L(l, mid) >= k)
				{
					left = mid;
				}
				else
				{
					right = mid;
				}
			}
			Console.WriteLine(left);
		}
    }
	
}

