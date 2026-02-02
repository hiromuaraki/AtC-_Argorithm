using System;
namespace P.ABC
{
    public class AtCorderA
    {
        public void Ac443()
        {
            string s = Console.ReadLine();
            Console.WriteLine(s + "s");
        }

        public void Ac442()
        {
            string s = Console.ReadLine();
            int count = 0;
            for (var i = 0; i < s.Length; i++)
            {

                if (s[i] == 'i' || s[i] == 'j') count++;
            }
            Console.WriteLine(count);
        }

        // (x,y)の行列が(p,q)の行列内に収まるか
        public void Ac441()
        {
            var p_q = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x_y = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (p, q) = (p_q[0], p_q[1]);
            var (x, y) = (x_y[0], x_y[1]);
            if ((p <= x && x < p + 100) && (q <= y && y < q + 100)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }

        public void Ac440()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (x, y) = (line[0], line[1]);
            // 2^yをシフト演算で計算
            Console.WriteLine(x << y);
        }

        public void Ac439()
        {
            int n = int.Parse(Console.ReadLine());
            int sq = 2;
            for (var i = 1; i < n; i++) sq *= 2;
            Console.WriteLine(sq - 2 * n);
        }

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

        public void Ac428()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (s, a, b, x) = (line[0], line[1], line[2], line[3]);
            Console.WriteLine(s * a * (x / (a + b)) + Math.Min(a, x % (a + b)) * s);

            int ans = 0;
            for (var time = 0; time < x; time++)
            {
                if (time % (a + b) < a)
                {
                    ans += s;
                }
            }
            Console.WriteLine(ans);
        }


        // シミュレーション（状態管理の問題）
        public void Ac383()
        {
            int n = int.Parse(Console.ReadLine());
            var (water, preT) = (0, 0);

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int t = line[0], v = line[1];
                water = Math.Max(0, water - (t - preT));
                water += v;
                preT = t;
            }
            Console.WriteLine(water);
        }

        // シミュレーション（状態管理の問題）
        public void Ac376()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (n, c) = (line[0], line[1]);
            int preT = 0;
            int candy = 1;

            for (var i = 0; i < n - 1; i++)
            {
                if (t[i + 1] - t[preT] < c) continue;
                preT = i + 1;
                candy++;
            }
            Console.WriteLine(candy);
        }

        public void Ac371()
        {
            var line = Console.ReadLine().Split();
            var (ab, ac, bc) = (line[0], line[1], line[2]);
            string ans = "";
            if (ab != ac) ans = "A";
            else if (ab == ac && ab == bc && ac == bc) ans = "B";
            else ans = "C";
            Console.WriteLine(ans);
        }

        public void Ac369()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (a, b) = (line[0], line[1]);
            int ans = 0;
            if (a == b) ans = 1;
            else if ((a + b) % 2 == 0) ans = 3;
            else ans = 2;
            Console.WriteLine(ans);
        }

        public void Ac367()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (a, b, c) = (line[0], line[1], line[2]);
            string msg = "";
            if (b < c)
            {
                if (c < a || a < b) msg = "Yes";
                else msg = "No";
            }
            else
            {
                if (c < a && a < b) msg = "Yes";
                else msg = "No";
            }
            Console.WriteLine(msg);
        }
        

        public void Ac354()
        {
            long h = long.Parse(Console.ReadLine());
            int c = 0;
            int ans = 0;

            for (var i = 0; i <= h; i++)
            {
                c += 2 << i;
                if (c > h)
                {
                    ans = i + 1;
                    break;
                }
            }
            Console.WriteLine(ans);
        }

        public void Ac349()
        {
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(-a.Sum());
        }

        // 切り上げ処理：(a + b - 1) / b
        public void Ac345()
        {
            long x = long.Parse(Console.ReadLine());
            Console.WriteLine(x >= 0 ? (x + 10 - 1) / 10 : x / 10);
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

        public void Ac270()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (a, b) = (line[0], line[1]);
            Console.WriteLine(a | b);
        }

        public void Ac259()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = line[0];
            int m = line[1];
            int x = line[2];
            int t = line[3];
            int d = line[4];
            int ans = 0;
            if (m >= x) ans = t;
            else ans = t - (x - m) * d;
            Console.WriteLine(ans);
        }

        public void Ac250()
        {
            var line1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var line2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (h, w) = (line1[0], line1[1]);
            var (r, c) = (line2[0], line2[1]);
            int ans = 0;
            r--; c--;
            if (r - 1 >= 0) ans++;
            if (r + 1 < h) ans++;
            if (c - 1 >= 0) ans++;
            if (c + 1 < w) ans++;
            Console.WriteLine(ans);
        }

        public void Ac248()
        {
            var s = Console.ReadLine();
            var b = new int[10];
            for (var i = 0; i < s.Length; i++)
            {
                int si = int.Parse(s[i].ToString());
                b[si]++;
            }
            for (var i = 0; i < 10; i++)
            {
                if (b[i] == 0)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        public void Ac243()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (v, a, b, c) = (line[0], line[1], line[2], line[3]);
            int v2 = v % (a + b + c);
            string ans = "";
            if (v2 < a) ans = "F";
            else if (v2 < a + b) ans = "M";
            else ans = "T";
            Console.WriteLine(ans);
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

        public void Ac213()
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var (a, b) = (line[0], line[1]);
            Console.WriteLine(a ^ b);
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

    