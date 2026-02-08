using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.ABC;
// Programクラスを定義
class Program
{
    // Mainメソッド
    // プログラムをコンパイル（PCが理解できる0,1に変換）＝ビルド＝.objが作成
    public static void Main()　// void：戻り値なしのエントリポイント
    {
        ENTRY.Study study = new ENTRY.Study();
        AtCorderA acA = new AtCorderA();
        JOI.Joi joi = new JOI.Joi();
        MATH.MathAlgo math = new MATH.MathAlgo();
        PG鉄則.ProgramingTessoku pg = new PG鉄則.ProgramingTessoku();
        アルゴ式.中級.計算量の工夫.Calculation calc = new アルゴ式.中級.計算量の工夫.Calculation();
        AtCorderB acB = new AtCorderB();
        AtCorderC acC = new AtCorderC();
        AtCorderD acD = new AtCorderD();
        //acA.Ac444();
        //acB.Ac444();
        //pg.Q2();
        //calc.Q10();
        //math.Math_091();
        //joi.Q13();
        acC.Ac444();
        //acD.Ac437_2();
        //Solve();
    }

    public static void Solve()
    {
        //var alg = new Argorithm.Argorithm();
        //var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //int n = line[0], s = line[1];
        //var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //alg.IsPartialSum(n,s,a);
    }

    // 頂点・辺を受け取る
    public static void G()
    {
        var alg = new Argorithm.Argorithm();
        var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = line[0], m = line[1];
        var list = new List<(int, int)>();
        for (var i = 0; i < n; i++)
        {
            var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
            list.Add((v[0], v[1]));
        }
        var gList = alg.AdjGraph(n, m, list);
        Console.Write(gList);

    }
}