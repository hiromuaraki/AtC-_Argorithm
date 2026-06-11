using System;
namespace P.アルゴ式.上級.動的計画法の活用
{
	public class Dp
	{
		private static int N,Q,M,K,H,W,A,B;
		private static long LM;
		public Dp()
		{
		}

		// 部分和問題 (到達可能性）
		public void Q1()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
            M = int.Parse(line[1]);
			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var dp = new bool[N, M];
			dp[0, 0] = true; // 0個目の時点で合計0作れる

			for (var i = 0; i < N - 1; i++)
			{
				for (var j = 0; j < M; j++)
				{
					if (!dp[i, j]) continue;

					// マスを選ばない：合計値変化なし
					dp[i + 1, j] = true;

					// マスの範囲内か
					if (j + A[i] < M)
					{
						// マスを選ぶ：合計値変化あり
						dp[i + 1, j + A[i]] = true;
					}
				}
			}

			int count = 0;
            for (var j = 0; j < M; j++)
            {
                if (dp[N - 1, j]) count++;
            }
            Console.WriteLine(count);
        }


		// 部分和問題（到達可能性）True/False
		public void Q2()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
            M = int.Parse(line[1]);
			var W = Console.ReadLine().Split().Select(int.Parse).ToArray();

			// i個時点で合計jを作れるかを管理する配列
			// 最終的にdp[N][M]を求めたい
			var dp = new bool[N + 1, M + 1];
			dp[0, 0] = true;

			for (var i = 0; i < N; i++) // N行見る
			{
				for (var j = 0; j <= M; j++) // 0..M+1まで範囲を設定
				{
					if (!dp[i, j]) continue;

					// 選ばない
					dp[i + 1, j] = true;

					// 合計がM以下のみMになりうる
					if (j + W[i] <= M)
					{
						// 選ぶ 重さが変化
						dp[i + 1, j + W[i]] = true;
					}
				}
			}
			Console.WriteLine(dp[N, M] ? "Yes" : "No");
        }

		// 部分和問題（最小個数）min()
		public void Q3()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
			M = int.Parse(line[1]);
			var W = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int INF = int.MaxValue;

			var dp = new int[N + 1, M + 1];

			for (var i = 0; i <= N; i++)
			{
				for (var j = 0; j <= M; j++)
				{
					dp[i, j] = INF;
				}
			}
			dp[0, 0] = 0;

			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j <= M; j++)
				{
					if (dp[i, j] == INF) continue;
					// ボール選ばない
					dp[i + 1, j] = Math.Min(dp[i + 1, j], dp[i, j]);

					// 1個ボール選ぶ
					if (j + W[i] <= M)
					{
						dp[i + 1, j + W[i]] = Math.Min(dp[i + 1, j + W[i]], dp[i, j] + 1);
					}
				}
			}
			Console.WriteLine(dp[N, M] != INF ? dp[N, M] : -1);

		}

		// 部分和問題（数え上げ）加算
		public void Q4()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
            M = int.Parse(line[1]);
			int MOD = 1000;

			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dp = new int[N + 1, M + 1];
			dp[0, 0] = 1;

			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j <= M; j++)
				{
					if (dp[i, j] == 0) continue;
					// 選ばない（方法数を引き継ぐ）
					dp[i + 1, j] += dp[i, j];
					dp[i + 1, j] %= MOD;
					// 選ぶ（iごとの方法数を加算）
					if (j + A[i] <= M)
					{
						dp[i + 1, j + A[i]] += dp[i, j];
						dp[i + 1, j + A[i]] %= MOD;
					}
				}
			}
			Console.WriteLine(dp[N, M]);
        }

		// 余りを持つ（状態圧縮：合計値は持たない）
		public void Q5()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
            A = int.Parse(line[1]);
            B = int.Parse(line[2]);
			var X = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dp = new bool[N + 1, A];
			dp[0, 0] = true;
			for (var i = 0; i < N; i++)
			{
				for (var r = 0; r < A; r++)
				{
					if (!dp[i, r]) continue;
					dp[i + 1, r] = true;
					dp[i + 1, (r + X[i]) % A] = true;
				}
			}
			Console.WriteLine(dp[N, B] ? "Yes" : "No");
        }

		// ２つのグループに分ける（状態圧縮：片方の合計が決まればもう片方も自動的に決まる）
		public void Q6()
		{
			N = int.Parse(Console.ReadLine());
			var W = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int S = W.Sum();
			var dp = new bool[N + 1, S + 1];
			dp[0, 0] = true;
			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j <= S; j++)
				{
					if (!dp[i, j]) continue;
					dp[i + 1, j] = true;
					dp[i + 1, j + W[i]] = true;
				}
			}
			int ans = S;
			for (var j = 0; j <= S; j++)
			{
				if (dp[N, j])
				{
					ans = Math.Min(ans, Math.Abs(j - (S - j)));
				}
			}
			Console.WriteLine(ans);
		}

		public void Q7()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
			M = int.Parse(line[1]);
			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var B = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dp = new int[N, M];
			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j < M; j++)
				{
					dp[i, j] = -1;
				}
			}
			dp[0, 0] = 0;
			for (var i = 0; i < N - 1; i++)
			{
				for (var j = 0; j < M; j++)
				{
					if (dp[i, j] < 0) continue;
					dp[i + 1, j] = Math.Max(dp[i + 1, j], dp[i, j]);

					if (j + A[i] < M)
					{
						dp[i + 1, j + A[i]] = Math.Max(
							dp[i + 1, j + A[i]],
							dp[i, j] + B[i]
						);
					}
				}
			}
			Console.WriteLine(dp[N - 1, M - 1]);
        }

		// ナップサック問題：（合計jの重さを作る最大価値）
		public void Q8()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
			M = int.Parse(line[1]);
			var W = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var V = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var dp = new int[N + 1, M + 1];
			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j < M; j++)
				{
					dp[i, j] = -1;
				}
			}
			dp[0, 0] = 0;
			int ans = 0;
			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j <= M; j++)
				{
					if (dp[i, j] < 0) continue;
					dp[i + 1, j] = Math.Max(dp[i + 1, j], dp[i, j]);

					if (j + W[i] <= M)
					{
						dp[i + 1, j + W[i]] = Math.Max(
							dp[i + 1, j + W[i]],
							dp[i, j] + V[i]
						);
						ans = Math.Max(ans, dp[i + 1, j + W[i]]);
					}
				}
			}
			Console.WriteLine(ans);
        }

		// 経路最小値DP＋状態圧縮（直前の行のコストを持つ）
		public void Q9()
		{
            N = int.Parse(Console.ReadLine());

			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var B = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var C = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var P = new List<int[]>(){ A,B,C };

			int INF = int.MaxValue;
			var dp = new int[N, 3];

			for (var i = 0; i < N; i++)
			{
				for (var j = 0; j < 3; j++)
				{
					dp[i, j] = INF;
				}
			}

			for (var r = 0; r < 3; r++)
			{
				dp[0, r] = 0;
			}

			for (var i = 0; i < N - 1; i++)
			{
				// 現在の行
				for (var now = 0; now < 3; now++)
				{
                    // 次の行
                    for (var next = 0; next < 3; next++)
					{
						int cost = Math.Abs(P[now][i] - P[next][i + 1]);
						dp[i + 1, next] = Math.Min(
							dp[i + 1, next],
							dp[i, now] + cost
						);
					}
				}
			}

			int ans = INF;
			for (var j = 0; j < 3; j++)
			{
				ans = Math.Min(ans, dp[N - 1, j]);
			}
            Console.WriteLine(ans);
        }

		// 部分和問題（K個以内の個数制約あり）
		// N個の整数の中から、K個以内の整数を使い総和をMにできるか。
		public void Q10()
		{
			var line = Console.ReadLine().Split();

			N = int.Parse(line[0]);
            M = int.Parse(line[1]);
			K = int.Parse(line[2]);

			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 合計 j を作るための最小個数を持つ
            // 例）A=[7,5,3]の場合
            // 7 → 1, 5 → 1, 3 → 1, 10 → 2, 8 → 2
            var dp = new int[M + 1];
			var INF = int.MaxValue;
			Array.Fill(dp, INF);

			dp[0] = 0; // 合計0は0個で作れる

			for (var i = 0; i < N; i++)
			{
				for (var j = M; j >= 0; j--)
				{
					if (dp[j] == INF) continue;
					// j=これまでの部分和
					if (j + A[i] <= M)
					{
						dp[j + A[i]] = Math.Min(
							dp[j + A[i]],
							dp[j] + 1 // 個数の追加
						);
					}
				}
			}
			// 総和MがK個以内で作れるか？
			Console.WriteLine(dp[M] <= K ? "Yes" : "No");
        }

		public void Q11()
		{
			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
			LM = long.Parse(line[1]);

			var W = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var V = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var MAX_V = V.Sum();
			long INF = long.MaxValue;

			var dp = new long[MAX_V];
			Array.Fill(dp, INF);
			dp[0] = 0;

			for (var i = 0; i < N; i++)
			{
				// 同じ要素を複数回使わないため、逆順更新
				for (var v = MAX_V; v >= 0; v--)
				{
					if (dp[v] == INF) continue;
					int nv = v + V[i];
					dp[nv] = Math.Min(
						dp[nv],
						dp[v] + W[i]
					);
				}
			}

			int ans = 0;
			for (var v = 0; v < MAX_V; v++)
			{
				if (dp[v] <= M)
				{
					ans = Math.Max(ans, v);
				}
			}
			Console.WriteLine(ans);
        }

		public void Q12()
		{
			;
		}

		public void Q13()
		{
			;
		}

		public void Q14()
		{

			long MOD = 1000000000 + 7;

			var line = Console.ReadLine().Split();
			N = int.Parse(line[0]);
            K = int.Parse(line[1]);

			char[] S = Console.ReadLine().ToArray();

			var dp = new long[N + 1, K];
			dp[0, 0] = 1;

			for (var i = 0; i < N; i++)
			{
				int d = S[i] - '0';

				for (var r = 0; r < K; r++)
				{
					dp[i + 1, r] += dp[i, r];
					dp[i + 1, r] %= MOD;

					int nr = (r * 10 + d) % K;
					dp[i + 1, nr] += dp[i, r];
					dp[i + 1, nr] %= MOD;
				}
			}
			Console.WriteLine(dp[N, 0] - 1);
        }

		// 桁和DP
		public void Q15()
		{
			var line = Console.ReadLine().Split();
			string N = line[0];
			int A = int.Parse(line[1]);
			int L = N.Length;
			var dp = new long[L + 1, 2, A];
			dp[0, 0, 0] = 1; // 何も桁を選んでないためNと一致が1通り

			// 左からN以下の数を0〜L桁作りながら、
			// 桁和％Aの作れる個数を管理
			for (var i = 0; i < L; i++)
			{
				int d = N[i] - '0';
				// 0:Nと完全一致
				// 1:N未満確定
				for (var smaller = 0; smaller < 2; smaller++)
				{
					for (var r = 0; r < A; r++)
					{
						// 現在の桁和％Aが何個作れるか
						long cur = dp[i, smaller, r];
						if (cur == 0) continue;

						// 次の桁における数字を決める
						int mxDigit = smaller == 1 ? 9 : d;

						for (var digit = 0; digit <= mxDigit; digit++)
						{
							int nextSmaller = smaller;

							// 桁の余り更新
							if (smaller == 0 && digit < d)
							{
								int nextR = (r + digit) % A;
								dp[i + 1, nextSmaller, nextR] += cur;
							}
						}
					}
				}
			}
			Console.WriteLine(dp[L, 0, 0] + dp[L, 1, 0] - 1);
		}
	}
}

