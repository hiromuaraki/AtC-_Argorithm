using System;
namespace P.PG鉄則
{
	public class ProgramingTessoku
	{
		public ProgramingTessoku()
		{
		}

		public void Q1()
		{
			int n = int.Parse(Console.ReadLine());
			string binary = "";
			while (n > 0)
			{
				binary = (n % 2) + binary;
				n /= 2;
			}
			binary = binary.PadLeft(10, '0');
			Console.WriteLine(binary);
		}

		public void Q2()
		{
			string n = Console.ReadLine();
			int ans = 0;
			int l = n.Length;
			for (var i = 0; i < l; i++)
			{
				ans += int.Parse(n[l - 1 - i].ToString()) * (1 << i);
			}
			Console.WriteLine(ans);
		}
	}
}

