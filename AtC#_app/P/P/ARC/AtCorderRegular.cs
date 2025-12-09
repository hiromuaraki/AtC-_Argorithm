using System;
namespace P.ARC
{
	public class AtCorderRegular
	{
		public AtCorderRegular()
		{
		}

		// 周期性（サイクル）のシミュレーションを数学的解法で求める
		public void Arc028()
		{
			string[] line = Console.ReadLine().Split();
			int n = int.Parse(line[0]);
            int a = int.Parse(line[1]);
            int b = int.Parse(line[2]);
			int r = n % (a + b);
			string ans = "";
			if (r == 0) { ans = "Bug";  }
			else if (r <= a) { ans = "Ant"; }
			else { ans = "Bug"; }
			Console.WriteLine(ans);
        }

		// 部分文字列の個数の計算
		public void Arc033()
		{
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine(n * (n + 1) / 2);
		}
	}
}

