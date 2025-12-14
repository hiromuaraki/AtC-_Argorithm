using System;
namespace P.ABC
{
	public class AtCorderC
	{
		public AtCorderC()
		{
		}

		public void Ac436()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var st = new HashSet<(int, int)>();
			int ans = 0;
			for (var i = 0; i < m; i++)
			{
				int[] l = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int r = l[0], c = l[1];
				r -= 1; c -= 1;

				if (st.Contains((r, c))) { continue; }
                if (st.Contains((r, c + 1))) { continue; }
                if (st.Contains((r + 1, c))) { continue; }
                if (st.Contains((r + 1, c + 1)))  { continue; }
				st.Add((r, c));
				st.Add((r, c + 1));
                st.Add((r + 1, c));
				st.Add((r + 1, c + 1));
				ans++;
            }
			Console.WriteLine(ans);
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

