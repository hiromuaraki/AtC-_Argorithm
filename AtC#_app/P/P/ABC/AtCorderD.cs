using System;
namespace P.ABC
{
	public class AtCorderD
	{
		public const long MOD = 998244353;

        public AtCorderD()
		{
		}

		// O((n + m) log m)
		public void Ac437()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long n = line[0], m = line[1];
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
			// 連続した区間にする為、x未満の要素／x以上の要素に並べ替え
			Array.Sort(a);
			P.Argorithm.Argorithm algo = new P.Argorithm.Argorithm();
			// 区間和を計算しておく
			var s = algo.PrefixSum(n, a);

			long ans = 0;

			foreach (var x in b)
			{
				var k = algo.BisectLeft(x, a);
				// （左側）ai < x
				long left = (x * k - s[k]) % MOD;
				// （右側）ai >= x
				long right = ((s[n] - s[k]) - x * (n - k)) % MOD;
				ans += (left + right) % MOD;
			}

			Console.WriteLine(ans % MOD);
        }

		// 愚直解法（全組合せ O(NM))
		public void Ac437_2()
		{
            var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long n = line[0], m = line[1];
            var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long ans = 0;
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < m; j++)
				{
					ans += Math.Abs(a[i] - b[j]) % MOD;
				}
			}
			Console.WriteLine(ans % MOD);
        }
	}
}

