using System;
namespace P.ABC
{
	public class AtCorderC
	{
		public AtCorderC()
		{
		}

		public void Ac440()
		{
            int t = int.Parse(Console.ReadLine());

            while (t-- > 0)
			{
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int n = line[0], w = line[1];
                var c = Console.ReadLine().Split().Select(int.Parse).ToArray();

				// 周期性
				int period = 2*w;
				long[] sumCost = new long[period];

                // 各マスiをi % 2wでグループ化
                for (var i = 0; i < n; i++)
				{
					// 黒くなるのはwの連続区間
                    sumCost[i % period] += c[i];
				}

                // 円環を直線にするため配列の長さを2倍で設定
                long[] arr = new long[period * 2];
				for (var i = 0; i < period; i++)
				{
					arr[i] = sumCost[i];
					arr[i + period] = sumCost[i]; 
				}
				
				long current = 0;
                // 長さ w の区間和の最小値
                for (var i = 0; i < w; i++) current += arr[i];

				long ans = current;
				for (var i = w; i < w + period; i++)
				{
					current += arr[i];
					current -= arr[i - w];
					ans = Math.Min(ans, current);
				}
				Console.WriteLine(ans);
            }
        }

		// 愚直：全探索
		// xを固定し,全(x, i）組を走査しマスを黒に塗る最小コストを求める
		public void Ac440_2()
		{
			int t = int.Parse(Console.ReadLine());
			const long INF = 1000_000_000_000_000_000;
			
			for (var tt = 0; tt < t; tt++)
			{
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int n = line[0], w = line[1];

				long sumCost = INF;
				int period = 2*w;
				for (var x = 1; x <= period; x++)
				{
					int cost = 0;
					for (var i = 0; i < n; i++)
					{
						if ((i + x) % period < w)
						{
							cost += c[i];
						}
					}
					sumCost = Math.Min(sumCost, cost);
				}
				Console.WriteLine(sumCost);
			}
		}

		public void Ac439()
		{
			int n = int.Parse(Console.ReadLine());
			int[] cnt = new int[n + 1];
			int limit = (int)Math.Sqrt(n);

			for (var x = 1; x <= limit; x++)
			{
				for (var y = x + 1; y <= limit; y++)
				{
					long sq = x * x + y * y;
					if (sq > n) break;
					cnt[sq]++;
				}
			}

			var good = new List<int>();	
			for (var i = 0; i < cnt.Length; i++)
			{
				if (cnt[i] == 1)
				{
					good.Add(i);
				}
			}

			Console.WriteLine(good.Count);
			Console.WriteLine(string.Join(" ", good));
		}

		// 貪欲法＋ソート（難しい）
		public void Ac437()
		{
			var t = int.Parse(Console.ReadLine());

			for (var i = 0; i < t; i++)
			{
				var cost = new List<(long, long, long)>();
				long totalPower = 0; 
				var n = int.Parse(Console.ReadLine());

				for (var j = 0; j < n; j++)
				{
					var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
					long w = line[0], p = line[1];
					totalPower += p; // 全員でソリを引く
					cost.Add((p + w, w, p));
				}
				// 小さいコストのトナカイをソリに乗せていくのが
				// ソリに乗せるトナカイの数を最大化させる最適
				cost.Sort();
				long weight = 0;
				long power = totalPower; // 現在のトナカイの力の合計を管理

                int ans = 0;
				for (var k = 0; k < cost.Count; k++)
				{
					var (wp, w, p) = cost[k];
					// このトナカイをソリに乗せられるか
					if (power - p >= w + weight)
					{
						power -= p;
						weight += w;
						ans++;
					}
					else
					{
						// これ以上がトナカイが誰も乗れない場合
						break;
					}
				}
				Console.WriteLine(ans);
			}

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
					return;
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

