using System;
namespace P.ABC
{
	public class AtCorderC
	{
		public AtCorderC()
		{
		}

		public void Ac435()
		{
            int n = int.Parse(Console.ReadLine());
            int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int cur = 1;

			for (var i = 0; i < n; i++)
			{
				if (i >= cur)
				{
					Console.WriteLine(i);
					Environment.Exit(0);
				}
				cur = Math.Max(cur, i + a[i]);
			}
			Console.WriteLine(n);
        }

		public void Ac435_2()
		{
			int n = int.Parse(Console.ReadLine());
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int right = a[0] - 1;
			int i = 0;

			while (right > 0 && i < n)
			{
				right = Math.Max(right, a[i]);
				right--;
				i++;
			}
			Console.WriteLine(i);
		}
	}
}

