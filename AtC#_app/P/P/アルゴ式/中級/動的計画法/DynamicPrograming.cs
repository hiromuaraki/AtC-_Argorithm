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

		public void Q6()
		{
			int n = int.Parse(Console.ReadLine());
			int[] dp = new int[n + 1];
			dp[0] = 1;
			for (var i = 1; i < n + 1; i++)
			{
				// 1 * iの長方形のタイルを敷き詰める方法の個数を求める
				if (i - 1 >= 0) dp[i] += dp[i - 1];
                if (i - 2 >= 0) dp[i] += dp[i - 2];
                if (i - 3 >= 0) dp[i] += dp[i - 3];
            }
			Console.WriteLine(dp[n]);
		}

		public void Q7()
		{
			const int N = 4;
			var dp = new int[N, N];
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			for (var j = 0; j < N; j++) dp[0, j] = a[j];
			for (var i = 1; i < N; i++)
			{
				for (var j = 0; j < N; j++)
				{
					// 真上を足す
					dp[i, j] += dp[i - 1, j];
					// 左上を足す
					if (j - 1 >= 0) dp[i, j] += dp[i - 1, j - 1];
                    // 右上を足す
                    if (j + 1 < N) dp[i, j] += dp[i - 1, j + 1];
				}
			}
			Console.WriteLine(dp[N - 1, N - 1]);
		}

		public void Q8()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            var dp = new int[n, n];
			for (var i = 0; i < n; i++) dp[0, i] = a[i];
			for (var i = 1; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					// 真上を足す
					dp[i, j] += dp[i - 1, j];
					// 左上を足す
					if (j - 1 >= 0) dp[i, j] += dp[i - 1, j - 1];
					if (j + 1 < n) dp[i, j] += dp[i - 1, j + 1];
					dp[i, j] %= 100;
				}
			}
			Console.WriteLine(dp[n - 1, n - 1]);
		}

		public void Q9()
		{
			int n = int.Parse(Console.ReadLine());
			var dp = new int[n, 3];
			var a = new List<int[]>();
			for (var i = 0; i < n; i++)
			{
                a.Add(Console.ReadLine().Trim().Split().Select(int.Parse).ToArray());
            }
			// ３種類の仕事は全て選べる
			for (var j = 0; j < 3; j++) dp[0, j] = a[0][j];

			for (var i = 1; i < n; i++)
			{
				dp[i, 0] = Math.Max(dp[i - 1, 1], dp[i - 1, 2]) + a[i][0];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 2]) + a[i][1];
                dp[i, 2] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]) + a[i][2];
            }

			int ans = 0;
			for (var j = 0; j < 3; j++) ans = Math.Max(ans, dp[n - 1, j]);
			Console.WriteLine(ans);
		}

		// 貰うDP（過去から今を作る）
		public void Q10()
		{
			int n = int.Parse(Console.ReadLine());
			var dp = new int[n, n];
			dp[0, 0] = 1;
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					// 上から来る通り数を集約
					if (i - 1 >= 0) dp[i, j] += dp[i - 1, j];
                    // 左から来る通り数を集約
                    if (j - 1 >= 0) dp[i, j] += dp[i, j - 1];
                }
			}
			Console.WriteLine(dp[n - 1, n - 1]);
		}

		public void Q11()
		{
			int n = int.Parse(Console.ReadLine());
			var s = new string[n];
			var dp = new int[n, n];
			dp[0, 0] = 1;
			for (var i = 0; i < n; i++) s[i] = Console.ReadLine();
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (s[i][j] == '#') continue;
					if (i - 1 >= 0) dp[i, j] += dp[i - 1, j];
                    if (j - 1 >= 0) dp[i, j] += dp[i, j - 1];
                }
			}
			Console.WriteLine(dp[n - 1, n - 1]);
		}

		public void Q12()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new int[n][];
			var dp = new int[n, n];
			for (var i = 0; i < n; i++) a[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
			dp[0, 0] = a[0][0];
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (i == 0 && j == 0) continue;
					int val = int.MinValue;
					if (i - 1 >= 0) val = Math.Max(val, dp[i - 1, j]);
                    if (j - 1 >= 0) val = Math.Max(val, dp[i, j - 1]);
					dp[i, j] = val + a[i][j];
                }
			}
			Console.WriteLine(dp[n - 1, n - 1]);
		}

		public void Q13()
		{
			int n = int.Parse(Console.ReadLine());
			var a = new int[n][];
			var INF = 1000000000;
			var dp = new int[n, n];
			for (var i = 0; i < n; i++) a[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					dp[i, j] = INF;
				}
			}
			dp[0, n - 1] = a[0][n - 1];

			for (var i = 0; i < n; i++)
			{
				for (var j = n - 1; j >= 0; j--)
				{
					if (i - 1 >= 0)
					{
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + a[i][j]);
                    }
                    if (j + 1 < n)
					{
                        dp[i, j] = Math.Min(dp[i, j], dp[i, j + 1] + a[i][j]);
                    }
                }
			}
			Console.WriteLine(dp[n - 1, 0]);

		}
	}
}

