using System;

namespace P.アルゴ式.中級.計算量の工夫
{
	public class Calculation
	{
		public Calculation()
		{
		}

		public void Q1()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Array.Sort(a); ;
			Console.WriteLine(a[a.Length - 1] - a[0]);
		}

		public void Q2()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(long.Parse).ToList();
			var b = a.OrderByDescending(a_i => a_i).ToList();
			long ans = 0;
			for (var i = 0; i < n - 1; i++) ans += b[i];
			Console.WriteLine(ans);
		}

		// 数え上げの問題（32bit整数では収まらないためlong）
		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var (n, m) = (line[0], line[1]);
			long count = 0;
			for (var x = 1; x <= n; x++)
			{
				for (var y = 1; y <= n; y++)
				{
					count += Math.Max(0, Math.Min(n, m - x - y));
				}
			}
			Console.WriteLine(count);
		}

		public void Q4()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			long s = a.Sum();
			Console.WriteLine(s * s);
		}

		// 数え上げ（ペア和）の問題
		public void Q5()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int sum = a.Sum();
			long ans = 0;
			for (var i = 0; i < a.Length; i++)
			{
				sum -= a[i];
				ans += a[i] * sum;
			}
			Console.WriteLine(ans);
		}

		// 累積和の問題
		public void Q6()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int q = int.Parse(Console.ReadLine());
			var s = new int[n + 1];
			for (var i = 0; i < n; i++)
			{
				s[i + 1] = s[i] + a[i];
			}
			for (var i = 0; i < q; i++)
			{
				int k = int.Parse(Console.ReadLine());
				Console.WriteLine(s[k]);
			}
		}

		public void Q7()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int q = int.Parse(Console.ReadLine());
			var s = new int[n + 1];
			for (var i = 0; i < n; i++)
			{
				s[i + 1] = s[i] + a[i];
			}
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int l = line[0], r = line[1];
				Console.WriteLine(s[r] - s[l]);
			}
		}

		// 累積和の問題（連続するd日間の最大の来場者数の多い区間求める）
		public void Q8()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], d = line[1];
			var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] s = new int[n + 1];
			for (var i = 0; i < n; i++)
			{
				s[i + 1] = s[i] + x[i];
			}
			int max_start = 0, max_visitor = 0;
			for (var i = 0; i < n - d + 1; i++)
			{
				int dist = s[d + i] - s[i];
				if (dist >= max_visitor)
				{
					max_start = i;
					max_visitor = dist;
				}
			}
			int max_end = max_start + d - 1;
			Console.WriteLine($"{max_start}~{max_end}");
		}

		public void Q9()
		{
			int n = int.Parse(Console.ReadLine());
			var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int q = int.Parse(Console.ReadLine());
			int[] s = new int[n];
			for (var i = 0; i < n - 1; i++)
			{
				s[i + 1] = s[i] + d[i];
			}
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int l = line[0], r = line[1];
				Console.WriteLine(s[r] - s[l]);
			}
		}

		public void Q10()
		{
			int n = int.Parse(Console.ReadLine());
			var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int q = int.Parse(Console.ReadLine());
			Array.Sort(l);
			Argorithm.Argorithm algo = new Argorithm.Argorithm();
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = line[0], b = line[1];
				int left = algo.LowerBound(l, a);
				int right = algo.UpperBound(l, b);
				Console.WriteLine(Math.Max(0, right - left));
			}
		}
	}
}

