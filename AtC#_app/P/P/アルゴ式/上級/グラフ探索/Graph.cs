using System;
using System.Text;

namespace P.アルゴ式.上級.グラフ探索
{
	public class Graph
	{
        private static readonly int[] dy = new int[] { -1, 1, 0, 0 };
        private static readonly int[] dx = new int[] { 0, 0, -1, 1 };
		private static int N,M,H, W;
		private static List<char[]> S = new List<char[]>();
        private static bool[,] visited;

        public Graph()
		{

		}

		// BFS：頂点を塗る
		public void Q1()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
			var g = new List<int>[N]; // リストサイズを指定
			var que = new Queue<int>(N);
            // 始点0から各頂点までの最短距離
            var dist = new int[N];
			// 隣接リストを作成
			for (var i = 0; i < N; i++) g[i] = new List<int>();
			for (var i = 0; i < M; i++)
			{
				var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = ab[0], b = ab[1];
				g[a].Add(b);
				g[b].Add(a);
			}
			// 全頂点を未訪問に初期化
			Array.Fill(dist, -1);
			// 頂点vまでの移動回数を保持する配列
			var nodes = new List<int>[N];
			for (var i = 0; i < N; i++) nodes[i] = new List<int>();

			// BFS開始
			dist[0] = 0; // 頂点0は0手で移動できる
			que.Enqueue(0);
			nodes[0].Add(0);
			while (que.Count > 0)
			{
				int v = que.Dequeue();
				foreach (var nv in g[v])
				{
					// 訪問済みの場合は色が塗られている
					if (dist[nv] != -1) continue;
					
					// 頂点nvまでは、dist[v]＋１で移動できる
					dist[nv] = dist[v] + 1;
					nodes[dist[nv]].Add(nv);
					que.Enqueue(nv);
				}
			}
            var sb = new StringBuilder();
            for (var k = 0; k < N; k++)
			{
				nodes[k].Sort();
				sb.AppendLine(string.Join(" ", nodes[k]));
			}
			Console.WriteLine(sb.ToString());
		}

		public void Q2()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
			var G = new List<int>[N];
			for (var i = 0; i < N; i++) G[i] = new List<int>();
			for (var i = 0; i < M; i++)
			{
				var AB = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int A = AB[0], B = AB[1];
				G[A].Add(B);
				G[B].Add(A);
			}

			// BFS開始
			int[] dist = new int[N];
			Array.Fill(dist, -1);
			var todo = new Queue<int>();
			todo.Enqueue(0);
			dist[0] = 0;
			int ans = 0;
			while (todo.Count > 0)
			{
				int v = todo.Dequeue();
				foreach (var nv in G[v])
				{
					if (dist[nv] != -1) continue;
					dist[nv] = dist[v] + 1;
					todo.Enqueue(nv);
				}
				ans = Math.Max(ans, dist[v]);
			}
			Console.WriteLine(ans);
		}

		public void Q3()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			H = line[0]; W = line[1];
			var XY = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int X0 = XY[0], Y0 = XY[1];
			int X1 = XY[2], Y1 = XY[3];
			
			for (var i = 0; i < H; i++) S.Add(Console.ReadLine().ToArray());
			
            // BFS開始
            var dist = new int[H, W];
			for (var i = 0; i < H; i++)
			{
				for (var j = 0; j < W; j++)
				{
					dist[i, j] = -1;
				}
			}
			var todo = new Queue<(int row, int col)>();
			dist[X0, Y0] = 0;
			todo.Enqueue((X0, Y0));

			while (todo.Count > 0)
			{
				var (row, col) = todo.Dequeue();
				for (var i = 0; i < 4; i++)
				{
					int ni = dy[i] + row;
					int nj = dx[i] + col;
					if ((0 <= ni && ni < H) && (0 <= nj && nj < W) && S[ni][nj]	== 'W')
					{
						if (dist[ni, nj] != -1) continue;
						dist[ni, nj] = dist[row, col] + 1;
						todo.Enqueue((ni, nj));
                    }
				}
				if (dist[X1, Y1] != -1)
				{
					Console.WriteLine(dist[X1, Y1]);
					return;
				}
			}
		}

		// 有向グラフ＋入次数管理
		public void Q4()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
			var G = new List<int>[N];
			// 隣接リスト作成
			for (var i = 0; i < N; i++) G[i] = new List<int>();
			var depend = new int[N]; // 頂点Sに入る矢印の数（依存数）を管理する配列
			for (var i = 0; i < M; i++)
			{
				var FS = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int F = FS[0], S = FS[1];
				// 頂点Fに頂点Sの辺を張る（一方通行）
				G[F].Add(S);
				depend[S]++;
			}
			// BFS開始
			var todo = new Queue<int>();
			for (var i = 0; i < N; i++)
			{
				// 依存数0の課題はすぐ着手できる
				if (depend[i] == 0) todo.Enqueue(i);
			}
			int done = 0; // 課題完了の記録用
			while (todo.Count > 0)
			{
				int t = todo.Dequeue();
				done++;
				foreach (var i in G[t])
				{
					depend[i]--;
					if (depend[i] == 0)
					{
						todo.Enqueue(i);
					}
				}
			}
			Console.WriteLine(done == N ? "Yes" : "No");
		}

		// DFS（深さ優先探索）
		// すべての頂点を塗る
		public void Rec(int v, List<int>[] G, bool[] seen)
		{
			seen[v] = true;
			Console.Write(v + " ");
			G[v].Sort();
			foreach (var v2 in G[v])
			{
				if (seen[v2]) continue;
				Rec(v2, G, seen);
			}
		}

		public void Q5()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
            var G = new List<int>[N];
            for (var i = 0; i < N; i++) G[i] = new List<int>();
			for (var i = 0; i < M; i++)
			{
				var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = ab[0], b = ab[1];
				G[a].Add(b);
			}
			var seen = new bool[N];
			Rec(0, G, seen);
		}

		public void Rec(List<int>[] G, int v, bool[] visited)
		{
			foreach (var u in G[v])
			{
				if (!visited[u])
				{
					visited[u] = true;
					Rec(G, u, visited);
				}
			}
		}

		public void Q6()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];

			var G = new List<int>[N];
			for (var i = 0; i < N; i++) G[i] = new List<int>();	

			var visited = new bool[N];

			for (var i = 0; i < M; i++)
			{
				var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = ab[0], b = ab[1];
				G[a].Add(b);
			}

			visited[0] = true;
			Rec(G, 0, visited);

			Console.WriteLine(visited.Count(x => x == false));
		}

		public void Q7()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
			var G = new List<int>[N];
			for (var i = 0; i < N; i++) G[i] = new List<int>();
			for (var i = 0; i < M; i++)
			{
                var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int a = ab[0], b = ab[1];
                G[a].Add(b);
				G[b].Add(a);
            }

			// BFS開始
			var todo = new Queue<int>();
			bool[] visited = new bool[N];
			visited[0] = true;
			todo.Enqueue(0);

			while (todo.Count > 0)
			{
				int v = todo.Dequeue();
				foreach (var u in G[v])
				{
					if (!visited[u])
					{
						todo.Enqueue(u);
						visited[u] = true;
					}
				}
			}
			Console.WriteLine(visited.Contains(false) ? "No" : "Yes");
		}

        public void Rec2(List<int>[] G, int v, bool[] visited)
        {
			visited[v] = true;
			// 隣接頂点を訪問する
            foreach (var u in G[v])
            {
                if (!visited[u])
                {
                    Rec2(G, u, visited);
                }
            }
        }

        public void Q8()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			N = line[0]; M = line[1];
			var G = new List<int>[N];
			for (var i = 0; i < N; i++) G[i] = new List<int>();
			for (var i = 0; i < M; i++)
			{
				var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int a = ab[0], b = ab[1];
				G[a].Add(b);
                G[b].Add(a);
            }
			bool[] visited = new bool[N];
			int cnt = 0; // ひとかたまりの島が何個あるか数える
			for (var i = 0; i < N; i++)
			{
				if (!visited[i])
				{
					Rec2(G, i, visited);
					cnt++;
				}
			}
			Console.WriteLine(cnt);
		}

		public void Dfs(int y, int x, bool[,] visited)
		{
			visited[y, x] = true;

			for (var i = 0; i < 4; i++)
			{
				int ny = y + dy[i];
				int nx = x + dx[i];

				if (!((0 <= ny && ny < H) && (0 <= nx && nx < W))) continue;
				if (S[ny][nx] == '#' && !visited[ny, nx])
				{
					Dfs(ny, nx, visited);
				}

			}
		}

		public void Q9()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			H = line[0]; W = line[1];

			for (var i = 0; i < H; i++) S.Add(Console.ReadLine().ToArray());

			visited = new bool[H, W];

			int cnt = 0;
			for (var i = 0; i < H; i++)
			{
				for (var j = 0; j < W; j++)
				{
					if (S[i][j] == '#' && !visited[i, j])
					{
						Dfs(i, j, visited);
						cnt++;
					}
				}
			}
			Console.WriteLine(cnt);
		}
	}
}

