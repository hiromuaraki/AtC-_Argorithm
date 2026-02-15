using System;
namespace P.アルゴ式.中級.データ構造
{
	public class DataStruct
	{
		public DataStruct()
		{
		}

        public void Q1()
		{
			int n = int.Parse(Console.ReadLine());
			var s = Console.ReadLine().Split(' ');
            int q = int.Parse(Console.ReadLine());
			var dict = new Dictionary<string, int>();
			for (var i = 0; i < n; i++)
			{
				if (!dict.TryAdd(s[i], 1)) dict[s[i]]++;
			}
			for (var i = 0; i < q; i++)
			{
				string t = Console.ReadLine();
				int ans = dict.ContainsKey(t) ? dict[t] : 0;
				Console.WriteLine(ans);
			}
		}

		public void Q2()
		{
			int B = 30;
			int M = 1000003;
            int n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Argorithm.Argorithm argo = new Argorithm.Argorithm();
			List<long> hashWord = argo.HashWord(s, B, M);
			var counter = new Dictionary<long, int>();
			int max = 0;
			for (var i = 0; i < hashWord.Count; i++)
			{
				if (!counter.TryAdd(hashWord[i], 1))
					counter[hashWord[i]]++;

				max = Math.Max(max, counter[hashWord[i]]);

			}
			Console.WriteLine(max);
		}

		public void Q3()
		{
			int q = int.Parse(Console.ReadLine());
			var s = new HashSet<string>();
			
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().ToArray();
				int query = int.Parse(line[0]);
				string t = line[1];
				if (query == 0) s.Add(t);
				else if (query == 1) s.Remove(t);
				else Console.WriteLine(s.Contains(t) ? "Yes" : "No");
			}
		}

		// stack（スタック）
		public void Q4()
		{
			int q = int.Parse(Console.ReadLine());
			var stack = new Stack<string>();
			for (var i = 0; i < q; i++)
			{
				var query = Console.ReadLine().Split().ToArray();
				int c = int.Parse(query[0]);
                if (c == 1) stack.Push(query[1]);
                else Console.WriteLine(stack.Pop());
            }
		}

		public void Q5()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], q = line[1];
			int head = 0, tail = 0;
			int[] a = new int[n];
			for (var i = 0; i < n; i++) a[i] = -1;
			for (var i = 0; i < q; i++)
			{
				var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int c = query[0];
				if (c == 0)
				{
					a[tail] = query[1];
					tail = (tail + 1) % n;
				}
				else
				{
					a[head] = -1;
					head = (head + 1) % n;
				}
			}
			foreach (var a_i in a)
			{
				Console.WriteLine(a_i);
			}
		}

		public void Q6()
		{
			int q = int.Parse(Console.ReadLine());
			var tasks = new Queue<string>();
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().ToArray();
				if (line[0] == "0") tasks.Enqueue(line[1]);
				else Console.WriteLine(tasks.Dequeue());
			}
		}

		public void Q7()
		{
			var x = Console.ReadLine();
			int n = int.Parse(Console.ReadLine());
			var s = Console.ReadLine().Split().ToArray();
			var stack = new Stack<int>();
			for (var i = 0; i < n; i++)
			{

				if (s[i] == "+" || s[i] == "-" || s[i] == "*")
				{
					int n1 = stack.Pop();
                    int n2 = stack.Pop();

					int t = 0;
					if (s[i] == "+") t = n1 + n2;
					else if (s[i] == "-") t = n2 - n1;
					else t = n1 * n2;
                    stack.Push(t);
                }
				else
				{
                    stack.Push(int.Parse(s[i]));
				}
			}
			Console.WriteLine($"{x}={stack.Pop()}");
		}

		public void Q8()
		{
			long x = long.Parse(Console.ReadLine());
			int q = int.Parse(Console.ReadLine());
			var tasks = new Queue<long>();
			long count = 0;
			for (var i = 0; i < q; i++)
			{
				var line = Console.ReadLine().Split().Select(long.Parse).ToArray();
				long c = line[0], t = line[1];
				if (c == 0)
				{
					tasks.Enqueue(t + x);
				}
				else
				{
					while (tasks.Count > 0 && tasks.Peek() <= t)
					{
						tasks.Dequeue();
						count++;

					}
					Console.WriteLine(count);
				}
			}
		}
	}
}

