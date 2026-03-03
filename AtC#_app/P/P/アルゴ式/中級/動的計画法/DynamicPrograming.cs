using System;
namespace P.アルゴ式.中級.動的計画法
{
	public class DynamicPrograming
	{
		public DynamicPrograming()
		{
		}

		// フィボナッチ数列
		public void Q1()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], x = line[1], y = line[2];
			var fib = new int[n];
			fib[0] = x; fib[1] = y;
			for (var i = 2; i < n; i++)
			{
				fib[i] = (fib[i - 2] + fib[i - 1]) % 100;
            }
			Console.WriteLine(fib[n - 1]);
		}

		// 最小移動コスト
		public void Q2()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int[] dp = new int[n];
			for (var i = 1; i < n; i++)
			{
				if (i == 1)
				{
					dp[i] = dp[i - 1] + a[i];
					continue;
				}
                dp[i] = Math.Min(dp[i - 1] + a[i], dp[i - 2] + 2 * a[i]);
            }
			Console.WriteLine(dp[n - 1]);
		}

		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var dp = new int[n];
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			for (var i = 0; i < n; i++) dp[i] = 1000000;
			dp[0] = 0;
			for (var i = 1; i < n; i++)
			{
				for (var j = 1; j <= m; j++)
				{
					// マスの存在チェック（マスがある時のみマスの位置を進む）
					if (i - j >= 0)
					{
						dp[i] = Math.Min(dp[i], dp[i - j] + j * a[i]);
					}
				}
			}
			Console.WriteLine(dp[n - 1]);
		}

		// 部分和DP
		public void Q4()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var d = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			bool[] dp = new bool[n + 1]; // マスiに到達できるか管理するテーブル配列
			dp[0] = true; // マス0には到達できる

			for (var i = 1; i <= n; i++)
			{
				for (var j = 0; j < m; j++)
				{
					// マスの盤面外か＋i - d[j]のマスにすでに到達しているか
					if (i - d[j] >= 0 && dp[i - d[j]])
					{
						dp[i] = true;
						// 一つでもマスiに到達できるならOK
						break;
					}
				}
			}
			Console.WriteLine(dp[n] ? "Yes" : "No");
		}

		public void Q5()
		{
			int n = int.Parse(Console.ReadLine());
			int[] dp = new int[n + 1];
			dp[0] = 1; dp[1] = 1;
            for (var i = 2; i <= n; i++)
			{
				dp[i] = dp[i - 1] + dp[i - 2];
			}
			Console.WriteLine(dp[n]);
		}
	}
}

