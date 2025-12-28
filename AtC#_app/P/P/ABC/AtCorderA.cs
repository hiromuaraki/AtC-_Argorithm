using System;
namespace P.ABC
{
	public class AtCorderA
	{
        // 周期性の問題（難しい）
        public void Ac438()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int d = line[0], f = line[1];
            // コンテスト開始日から7日ずつ進め年を跨いだ直後の位置を求める
            while (f <= d)
            {
                f += 7;
            }
            Console.WriteLine(f - d);
            // 7日周期で何日ズレているか
            // 1年＝D日経つと周期上ではD日分ずれる,そのズレを7で割った余り
            //Console.WriteLine((f - d + 7) % 7);
        }

        public void Ac437()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int a = line[0], b = line[1];
            Console.WriteLine(a * 12 + b);
        }

        public void Ac436()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string t = "";
            for (var i = 0; i < n - s.Length; i++) t += "o";
            Console.Write(t + s);
        }

        // 等差数列
        public void Ac435()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n * (n + 1) / 2);
        }

        public void Ac404()
        {
            var s = Console.ReadLine().ToHashSet();
            
            for (var c = 'a'; c <= 'z'; c++)
            {
                if (!s.Contains(c))
                {
                    Console.WriteLine(c);
                    break;
                }
            }
            
        }


        public void Ac319()
        {
            string[] line = Console.ReadLine().Split().ToArray();
            int v = int.Parse(line[0]);
            int t = int.Parse(line[1]);
            int s = int.Parse(line[2]);
            int d = int.Parse(line[3]);
            t *= v; s *= v;
            // DがVT以上VS以下の範囲なら打てない
            if (t <= d && d <= s) { Console.WriteLine("No"); }
            else { Console.WriteLine("Yes"); }
        }


        public void Ac318()
        {
            // 入力 12 0 1
            string[] line = Console.ReadLine().Split().ToArray();
            int N = int.Parse(line[0]);
            int M = int.Parse(line[1]);
            int P = int.Parse(line[2]);

            int ans = 0;
            // 数学的解法
            if (M > N) { ans = 0; }
            else { ans = (N - M) / P + 1; }
            Console.WriteLine(ans);


            // シミュレーション
            int count = 0;
            while (M <= N)
            {
                count++;
                M += P;
            }
            Console.WriteLine(count);
        }

        // setを使い重複を除く
        public void Ac225()
        {
            var s = Console.ReadLine().ToCharArray();
            var st = s.Distinct().Count();
            int ans = 1;
            if (st == 3) ans = 6;
            else if (st == 2) ans = 3;
            Console.WriteLine(ans);
        }

        public void Ac100()
		{
			string[] line = Console.ReadLine().Split();
			int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
			Console.WriteLine(a <= 8 && b <= 8 ? "Yay!" : ":(");
        }

        public void Ac134()
        {
            string[] line = Console.ReadLine().Split();
            int n = int.Parse(line[0]);
            int d = int.Parse(line[1]);
            // R - L + 1：区間の長さ
            // (i + d) - (i - d) + 1 = 2d + 1に監視員を配置するのが最適
            // (n + w - 1) / wの切り上げ処理 n本の木を監視できる最小値を求める
            int w = 2 * d + 1;
            Console.WriteLine((n + w - 1) / w);
        }


        public void Ac164()
        {
            string[] line = Console.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);
            int d = int.Parse(line[3]);
            int taka = (a + d - 1) / d;
            int aoki = (c + b - 1) / b;
            Console.WriteLine(taka < aoki ? "No" : "Yes");
        }

        // 奇数の個数を数える
        public void Ac142()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((double)((n + 1) / 2) / n);
        }


        // べき乗の計算（3桁のパスワードで1以上N以下の文字で作れるパスワードの個数）   
        public void Ac140()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((int)Math.Pow(n, 3));
        }

        public void Ac108()
        {
            int k = int.Parse(Console.ReadLine());
            int even = k / 2;
            int odd = k - even;
            Console.WriteLine(even * odd);

        }
    }
}

    