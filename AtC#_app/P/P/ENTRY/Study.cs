using System;
namespace P.ENTRY
{
	public class Study
	{
        const int ODD_COUNT = 250;

        public Study()
		{
		}

		public void Chapter5_1()
		{
			while (true)
			{
				int n = int.Parse(Console.ReadLine());
				if (n < 0) break;
				Console.WriteLine($"入力値：{n} 0未満の値が入力されるまで終了しません。");
			}

		}

		// 一番長い文字列を表示
		public void Chapter5_2()
		{
			Console.WriteLine("10行文字列を入力してください。");
			int maxLen = 0;
			string longestString = "";
			int idx = -1;
			for (var i = 0; i < 10; i++)
			{
                string s = Console.ReadLine();
				if (maxLen < s.Length)
				{
                    maxLen = s.Length;
                    longestString = s;
					idx = i + 1;
				}
            }
			Console.WriteLine($"最長の文字列は{idx}番目：{longestString} ");
		}

		// 愚直解法
		public void Chapter5_3()
		{
			int count = 0;
			for (var i = 1; i <= 500; i++)
			{
				if (i % 2 != 0 && (i % 3 == 0 || i % 7 == 0))
				{
					count++;
				}
			}
			Console.WriteLine(count);
		}

		// 数学的解法（集合）500以下の3,7で割り切れてかつ奇数である倍数の個数を求める
		public int Domrgan(int n1, int n2)
		{
			// 500の中に奇数は 500 / 2 = 250個
			// a = 250以下の中に3の倍数：83個
			// b = 250以下の中に7の倍数：35個
			// c = 3,7の共通の倍数が重複している：最小公倍数：21 250 / 21
			// 補足：最小公倍数＝(a * b) // a,bの最大公約数
			// 答え＝ a + b - c
			int na = ODD_COUNT / n1;
			int nb = ODD_COUNT / n2;
			int distinct_count = ODD_COUNT / 21;
			
			return na + nb - distinct_count;
        }

		public double Chapter5_4()
		{
			double sum = 0.0;
			while (true)
			{
				double n = double.Parse(Console.ReadLine());
				if (n <= 0) break;
				sum += n;
			}

			return sum;
		}

		// O(N)
		public void Chapter5_5()
		{
			int n = int.Parse(Console.ReadLine());
			string s = "★";
			for (var i = 0; i < n; i++)
			{
				Console.WriteLine(s);
				s += "★";
			}
		}

        // O(N^2)
        public void Chapter5_5_2()
        {
            int n = int.Parse(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
				string s = "";
                for (var j = 0; j < i; j++)
				{
					s += "★";
				}
				Console.WriteLine(s);
            }
        }
    }
}

