using System;
namespace P.アルゴ式.中級.ビット
{
	public class Bit
	{
		static int N, F;
		static long A, M;
		
		public Bit()
		{
		}

		public void Q1()
		{
			F = int.Parse(Console.ReadLine());
			Console.WriteLine(1 << F);
		}

		// ビットシフト演算
		public void Q2()
		{
			N = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			int ans = 0;
			foreach (var f in a)
			{
				ans += 1 << f; // 1をfビット左に移動させる
			}
			Console.WriteLine(ans);
		}

		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long n = line[0], x = line[1];
			Console.WriteLine((n & (1L << (int)x)) != 0 ? "Yes" : "No");
		}

		public void Q4()
		{
			long n = long.Parse(Console.ReadLine());
			var ans = new List<long>();
			int cnt = 0;
			for (var i = 0; i < 30; i++)
			{
				// iビット目が立っているか
				if ((n & (1L << (int)i)) != 0)
				{
					cnt++;
					ans.Add(i);
				}
			}
			Console.WriteLine(cnt);
			Console.WriteLine(string.Join(" ", ans));
		}

		public void Q5()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long n = line[0], m = line[1];
			Console.WriteLine(n | m);
		}

		// not演算子で0,1反転
		public void Q6()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long a = line[0], m = line[1];
			Console.WriteLine(a & ~m);
		}

		public void Q7()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long a = line[0], m = line[1];
			Console.WriteLine(a ^ m);
		}

		public void Q8()
		{
			var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
			A = line[0]; M = line[1];
			Console.WriteLine(Convert.ToBoolean(A & M) ? "Yes" : "No");
		}

        public void Q9()
        {
            var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
            A = line[0]; M = line[1];
            Console.WriteLine((A & M) == M ? "Yes" : "No");
        }

		// 2進数→10進数
		public void Q10()
		{
			N = int.Parse(Console.ReadLine());
			var led = new string[]
			{
				"1110111", "0100100", "1011101", "1101101", "0101110",
				"1101011", "1111011", "0100111", "1111111", "1101111",
            };
			Console.WriteLine(Convert.ToInt32(led[N], 2));
		}


		public void Q11()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var bit = new string[]
			{
                "1110111", "0100100", "1011101", "1101101", "0101110",
                "1101011", "1111011", "0100111", "1111111", "1101111",
            };
            char[] a = bit[n].ToCharArray();
            Array.Reverse(a);
            char[] b = bit[m].ToCharArray();
            Array.Reverse(b);
			int ans = 0;
			for (var i = 0; i < 7; i++)
			{
                // - '0' → int変換
                int ai = a[i] - '0';
                int bi = b[i] - '0';
                if (ai != bi) ans += (1 << i);
            }
			Console.WriteLine(ans);
		}

		// 別解
		public void Q11_2()
		{
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line[0], m = line[1];
            var bit = new string[]
            {
                "1110111", "0100100", "1011101", "1101101", "0101110",
                "1101011", "1111011", "0100111", "1111111", "1101111",
            };

			int maskA = Convert.ToInt32(bit[n], 2);
            int maskB = Convert.ToInt32(bit[m], 2);
			Console.WriteLine(maskA ^ maskB);
        }

		public void Q12()
		{
			var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
			for (var i = 0; i < 8; i++)
			{
				string s = "";
				for (var j = 0; j < 8; j++)
				{
					int x0 = x[i] & 1 << (15 - 2 * j);
                    int x1 = x[i] & 1 << (14 - 2 * j);

					if (x0 == 0 && x1 == 0) s += ".";
					else if (x0 == 0 && x1 != 0) s += "o";
					else if (x0 != 0 && x1 == 0) s += "x";
                }
				Console.WriteLine(s);
			}
		}

		public void Q13()
		{
			var x = Console.ReadLine();
            var line = Console.ReadLine().Split().ToArray();
			string p = line[0], q = line[1];
			var user = new Dictionary<string, int>()
			{
				{"o", 0 },
                {"g", 1 },
                {"u", 2 },
			}[p];
            var action = new Dictionary<string, int>()
            {
                {"r", 2 },
                {"w", 1 },
                {"x", 0 },
			}[q];
			int n = x[user] - '0';
			Console.WriteLine(((n >> action) & 1) == 1 ? "Yes" : "No");
        }

		// ネットワークアドレスの計算
		public void Q14()
		{
			var sub = new int[]{ 255, 255, 252, 0 };
			var ip = new int[] { 172, 60, 123, 20 };
			var s = new List<string>();
			for (var i = 0; i < 4; i++)
			{
				int n = sub[i] & ip[i];
				s.Add(n.ToString());
			}
			Console.WriteLine(string.Join(".", s));
		}
    }
}

