using System;
using System.Text;
namespace P.アルゴ式.上級.グラフ探索
{
	public class Tree
	{
		private static int N,Q, M, X, H, W, ans;
		private static int[] dist;

		public Tree()
		{
		}

		// 箱の中の箱（入れ子構造）
        public void Q1()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; X = line[1];
			var A = Console.ReadLine().Split().Select(int.Parse).ToList();
			A.Insert(0, -1);
			int res = 0;

			while (X != 0)
			{
				res++;
				X = A[X];
			}
			Console.WriteLine(res);
        }

		// 頂点vを根とする部分木を探索
		public StringBuilder Rec(int v, List<int>[] chs, StringBuilder sb)
		{
            sb.Append($"{v.ToString()} ");
			// 頂点vの各子頂点を探索
			foreach (var ch in chs[v])
			{
				// 子頂点をchを根とした部分木を再起的に探索
				Rec(ch, chs, sb);
			}
			return sb;
		}

        // 行きがけ順
        public void Q2()
		{
			N = int.Parse(Console.ReadLine()); // 頂点数の入力
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray(); // 親頂点リスト

			var chs = new List<int>[N]; // 各親の子頂点リスト
			for (var i = 0; i < N; i++) chs[i] = new List<int>();

			// 各親の子頂点リスト作成
            for (var v = 1; v < N; v++)
			{
				// 頂点vの親
				int p = P[v - 1];
				// 親 p の子頂点リストに頂点 v を追加
                chs[p].Add(v);
			}

			var sb = new StringBuilder();
			Console.WriteLine(Rec(0, chs, sb));
		}

		
		public int[] Rec(int v, List<int>[] chs)
		{
			foreach (var ch in chs[v])
			{
				// 子の深さ＝親の深さ＋１
				dist[ch] = dist[v] + 1;
				Rec(ch, chs);
			}
			return dist;
		}

        // 頂点の深さ（頂点chまでの距離）
        public void Q3()
		{
			N = int.Parse(Console.ReadLine());
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();
			for (var v = 1; v < N; v++)
			{
				int p = P[v - 1];
				chs[p].Add(v);
			}
			dist = new int[N];
			var sb = new StringBuilder();
			Console.WriteLine(string.Join("\n", Rec(0, chs)));
		}

        public int Rec2(int v, List<int>[] chs)
        {
            foreach (var ch in chs[v])
            {
                // 子の深さ＝親の深さ＋１
                dist[ch] = dist[v] + 1;
                Rec2(ch, chs);
            }
			ans = Math.Max(ans, dist[v]);
            return ans;
        }

        public void Q4()
		{
			N = int.Parse(Console.ReadLine());
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();
			for (var v = 1; v < N; v++)
			{
				int p = P[v - 1];
				chs[p].Add(v);
			}

			dist = new int[N];
            Console.WriteLine(Rec2(0, chs));
		}

		// 木DP：頂点vの子孫数を事前計算
		public void Dfs(int v, List<int>[] chs, int[] sub)
		{
			foreach (var ch in chs[v])
			{
				Dfs(ch, chs, sub);
				// 帰りがけに順に実行される
				sub[v] += sub[ch];
			}
		}

        public StringBuilder Dfs(int v, List<int>[] chs, StringBuilder sb)
        {
            sb.Append($"{v} ");
            foreach (var ch in chs[v])
            {
                Dfs(ch, chs, sb);
            }
            return sb;
        }

        // 子孫の個数（木DP）
        public void Q5()
		{
			N = int.Parse(Console.ReadLine());
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var chs = new List<int>[N];
            for (var i = 0; i < N; i++) chs[i] = new List<int>();

			for (var v = 1; v < N; v++)
			{
				int p = P[v - 1];
				chs[p].Add(v);
			}

			var sub = new int[N];
			Array.Fill(sub, 1);

			Dfs(0, chs, sub);
			for (var i = 0; i < N; i++)
			{
				Console.WriteLine(sub[i] - 1);
			}
		}

        // 同一の親頂点を持つ子頂点のリスト（１）
        public void Q6()
		{
			N = int.Parse(Console.ReadLine());
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Q = int.Parse(Console.ReadLine());

			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();

			for (var v = 1; v < N; v++)
			{
				int p = P[v - 1];
				chs[p].Add(v);
			}

			var sb = new StringBuilder();
			for (var i = 0; i < Q; i++)
			{
				int v = int.Parse(Console.ReadLine());
				sb.AppendLine(string.Join(" ", chs[P[v - 1]]));
			}

			Console.WriteLine(sb);
		}

		// 同一の親頂点を持つ子頂点のリスト（２）
		public void Q7()
		{
			N = int.Parse(Console.ReadLine());
			var P = new int[N];
			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();
			for (var i = 0; i < N - 1; i++)
			{
				var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = ab[0], b = ab[1];
				chs[a].Add(b);
				P[b] = a;
			}
			Q = int.Parse(Console.ReadLine());
			for (var i = 0; i < N; i++)
			{
				chs[i].Sort();
			}
			var sb = new StringBuilder();
			for (var i = 0; i < Q; i++)
			{
				int v = int.Parse(Console.ReadLine());
				sb.AppendLine(string.Join(" ", chs[P[v]]));
			}
			Console.WriteLine(sb);
		}

		// 葉の個数
		public void Q8()
		{
			N = int.Parse(Console.ReadLine());
			var P = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();

			for (var v = 1; v < N; v++)
			{
				chs[P[v - 1]].Add(v);
			}

			int cnt = 0;
			for (var i = 0; i < N; i++)
			{
				if (chs[i].Count == 0) cnt++;
			}
			Console.WriteLine(cnt);
		}


		// 行きがけ順
		public void Q9()
		{
			N = int.Parse(Console.ReadLine());
			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();
			for (var i = 0; i < N - 1; i++)
			{
				chs[A[i]].Add(i + 1);
			}
			var sb = new StringBuilder();
            Console.WriteLine(Dfs(0, chs, sb));

        }

        // 木の 2 頂点間の距離
        public void Q10()
		{
			N = int.Parse(Console.ReadLine());
			var adj = new List<int>[N];

			for (var i = 0; i < N; i++) adj[i] = new List<int>();

			// 隣接リスト作成
			for (var i = 0; i < N - 1; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = line[0], b = line[1];
				adj[a].Add(b);
                adj[b].Add(a);
            }

			var uv = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int u = uv[0], v = uv[1];

			dist = new int[N];
			Array.Fill(dist, -1);
			dist[u] = 0;

			var todo = new Queue<int>();
			todo.Enqueue(u);

			while (todo.Count > 0)
			{
				int s = todo.Dequeue();
				foreach (var ns in adj[s])
				{
					if (dist[ns] != -1) continue;
					dist[ns] = dist[s] + 1;
                    todo.Enqueue(ns);
                }
			}
			Console.WriteLine(dist[v]);
		}

		public void Q11()
		{
			N = int.Parse(Console.ReadLine());
			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int v = int.Parse(Console.ReadLine());

			var adj = new List<int>[N];
			for (var i = 0; i < N; i++) adj[i] = new List<int>();

			for (var i = 0; i < N - 1; i++)
			{
				adj[A[i]].Add(i + 1);
			}

			dist = new int[N];
			Array.Fill(dist, -1);
			dist[v] = 0;

			var todo = new Queue<int>();
			todo.Enqueue(v);

			int res = 0;
			while (todo.Count > 0)
			{
				int s = todo.Dequeue();
				foreach (var ns in adj[s])
				{
					if (dist[ns] != -1) continue;
					dist[ns] = dist[s] + 1;
					todo.Enqueue(ns);
					res++;
				}
			}
			Console.WriteLine(res);
		}

		public void Q12()
		{
			N = int.Parse(Console.ReadLine());
			var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Q = int.Parse(Console.ReadLine());
			var chs = new List<int>[N];
			for (var i = 0; i < N; i++) chs[i] = new List<int>();
			for (var i = 0; i < N - 1; i++)
			{
				chs[A[i]].Add(i + 1);
			}
			var sub = new int[N];
			Array.Fill(sub, 1);

			Dfs(0, chs, sub);
			var sb = new StringBuilder();
			for (var i = 0; i < Q; i++)
			{
				int v = int.Parse(Console.ReadLine());
				sb.AppendLine(string.Join("", sub[v] - 1));
			}
			Console.WriteLine(sb);
		}

		public void Q13()
		{
			N = int.Parse(Console.ReadLine());
			var G = new List<int>[N];
			var chs = new List<int>[N];
			var parent = new int[N];

			for (var i = 0; i < N; i++)
			{
				G[i] = new List<int>();
				chs[i] = new List<int>();
				parent[i] = -1;
			}

			for (var i = 0; i < N - 1; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = line[0], b = line[1];
				G[a].Add(b);
				G[b].Add(a);
			}

			Q = int.Parse(Console.ReadLine());

			var todo = new Queue<int>();
			parent[0] = 0;
			todo.Enqueue(0);

			while (todo.Count > 0)
			{
				int v = todo.Dequeue();
				foreach (var nv in G[v])
				{
					if (parent[nv] != -1) continue;
					parent[nv] = v;
					todo.Enqueue(nv);
				}
			}

			for (var i = 1; i < N; i++)
			{
				chs[parent[i]].Add(i);
			}

			var sb = new StringBuilder();
			for (var i = 0; i < Q; i++)
			{
				int v = int.Parse(Console.ReadLine());
				sb.AppendLine(string.Join(" ", chs[parent[v]]));
			}
			Console.WriteLine(sb);
		}
    }

}

