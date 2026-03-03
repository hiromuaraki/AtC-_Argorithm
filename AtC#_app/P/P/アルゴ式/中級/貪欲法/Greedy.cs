using System;
namespace P.アルゴ式.中級.貪欲法
{
	public class Greedy
	{
		public Greedy()
		{
		}

		public void Q1()
		{
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine(n / 5 + n % 5);
		}

		public void Q2()
		{
			int n = int.Parse(Console.ReadLine());
			int ans = 0;
			while (n > 0)
			{
				if (n % 2 == 0) n /= 2;
				else n--;
				ans++;
			}
			Console.WriteLine(ans);
		}

		public void Q3()
		{
			int x = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var values = new int[] { 50, 10, 5, 1 };
			int ans = 0;
			for (var i = 0; i < 4; i++)
			{
				int use = Math.Min(a[i], x / values[i]);
				ans += use;
				x -= use * values[i];
			}
			Console.WriteLine(ans);
		}

		public void Q4()
		{
			int n = int.Parse(Console.ReadLine());
			int count = 0;
			while (n > 0)
			{
				count++;
				if (n % 3 == 0) n /= 3;
				else n--;
			}
			Console.WriteLine(count);
		}

		public void Q6()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
			long prev = a[0];
			long ans = 0;
			for (var i = 1; i < n; i++)
			{
				if (a[i] < prev)
				{
					ans += prev - a[i];
				}
				prev = Math.Max(prev, a[i]);
			}
			Console.WriteLine(ans);
		}

		public void Q7()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var s = Console.ReadLine();
			var t = Console.ReadLine();
			int n = line[0], m = line[1];
			int k = 0;
			for (var i = 0; i< n; i++)
			{
				if (k < m && s[i] == t[k])
				{
					k++;
				}
				if (k == m)
				{
					Console.WriteLine("Yes");
					return;
				}
			}
			Console.WriteLine("No");
		}

		public void Q8()
		{
			int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
				.ToList();
			int ret = 0;
			while (a.Count > 0)
			{
				ret++;
				long val = a.Min();
				var b = new List<long>();
                foreach (var a_i in a)
				{
					if (a_i % val != 0) b.Add(a_i);
				}
				a = b;
			}
			Console.WriteLine(ret);
		}

		public void Q9()
		{
			int n = int.Parse(Console.ReadLine());
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
			var groups = new List<long>();
			foreach (var x in a)
			{
				bool placed = false;
				for (var i = 0; i < groups.Count; i++)
				{
					if (groups[i] < x)
					{
						groups[i] = x;
						placed = true;
						break;
					}
				}
				if (!placed)
				{
					groups.Add(x);
				}
			}
			Console.WriteLine(groups.Count);
		}

        // PriorityQueueの練習（heapq）優先度の小さいものから取り出される
        // PriorityQueue<保存する値, 並び替え基準>
        public void Q10()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
			int n = line[0], k = line[1];
			var maxHeap = new PriorityQueue<long, long>();
			for (var i = 0; i < n; i++) maxHeap.Enqueue(a[i], -a[i]);
			while (k > 0)
			{
				long value = maxHeap.Dequeue();
				value /= 2;
				maxHeap.Enqueue(value, -value);
				k--;
			}
			long ret = 0;
			while (maxHeap.Count > 0)
			{
				ret += maxHeap.Dequeue();
			}
			Console.WriteLine(ret);
		}

		public void Q11()
		{
			var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int n = line[0], m = line[1];
			var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
			var box = new bool[m];
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < m; j++)
				{
					if (a[i] <= b[j] && !box[j])
					{
						box[j] = true;
						break;
					}
				}
			}
			Console.WriteLine(box.Count(x => x));
        }

		public void Q12()
		{
			int n = int.Parse(Console.ReadLine());
			var st = new List<(int s, int t)>();
			for (var i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				st.Add((line[0], line[1]));
			}
			var planList = st.OrderBy(x => x.t).ToList();
			int lastTime = 0;
			int count = 0;
			foreach (var plan in planList)
			{
				if (lastTime <= plan.s)
				{
					lastTime = plan.t;
					count++;
				}
			}
			Console.WriteLine(count);
		}
	}
}

