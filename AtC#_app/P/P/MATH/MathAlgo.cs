using System;
namespace P.MATH
{
	public class MathAlgo
	{
		public MathAlgo()
		{
		}

		public void Math091()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], x = line[1];

			// O(N^3)
			//for (var a = 1; a < n; a++)
			//{
			//	for (var b = a + 1; b < n; b++)
			//	{
			//		for (var c = b + 1; c <= n; c++)
			//		{
			//			if (a + b + c == x) ans++;
			//		}
			//	}
			//}

			int ans = 0;
			for (var a = 1; a < n; a++)
			{
				for (var b = a + 1; b < n; b++)
				{
					// cは固定しない
					// a, bが決まればcも決まる
					int c = x - a - b;
					if (b < c && c <= n) ans++;
				}
			}
			Console.WriteLine(ans);
		}

		public void Math034()
		{
			int n = int.Parse(Console.ReadLine());
			var dist = new List<(int, int)>();
			for (var i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int x = line[0], y = line[1];
                dist.Add((x, y));
            }
			P.Argorithm.Argorithm arg = new P.Argorithm.Argorithm();
			double minDist = 100_000_000;
			for (var i = 0; i < n - 1; i++)
			{
				for (var j = i + 1; j < n; j++)
				{
					minDist = Math.Min(minDist, arg.EuclideanDist(dist[i], dist[j]));
				}
			}
			Console.WriteLine($"{minDist: F10}");
		}
	}
}

