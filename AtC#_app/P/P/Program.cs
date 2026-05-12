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
        アルゴ式.中級.二分探索.BinarySearch2 binary = new アルゴ式.中級.二分探索.BinarySearch2();
        アルゴ式.中級.データ構造.DataStruct data = new アルゴ式.中級.データ構造.DataStruct();
        アルゴ式.中級.貪欲法.Greedy greedy = new アルゴ式.中級.貪欲法.Greedy();
        アルゴ式.中級.動的計画法.DynamicPrograming dp = new アルゴ式.中級.動的計画法.DynamicPrograming();
        アルゴ式.中級.メモ化再帰.Memo memo = new アルゴ式.中級.メモ化再帰.Memo();
        アルゴ式.中級.ビット.Bit bit = new アルゴ式.中級.ビット.Bit();
        アルゴ式.上級.配列の応用.DataArr dataArr = new アルゴ式.上級.配列の応用.DataArr();
        アルゴ式.上級.ビット全探索.S s = new アルゴ式.上級.ビット全探索.S();
        アルゴ式.上級.グラフ探索.Graph g = new アルゴ式.上級.グラフ探索.Graph();
        AtCorderB acB = new AtCorderB();
        AtCorderC acC = new AtCorderC();
        AtCorderD acD = new AtCorderD();
        //acA.Ac444();
        //acB.Ac444();
        //pg.Q2();
        //math.Math_091();
        //joi.Q13();
        //acC.Ac444();
        //acD.Ac437_2();
        //Solve();
        //calc.Q10();
        //binary.Q9();
        //data.Q8();
        //greedy.Q12();
        //dp.Q11();
        //memo.Q10();
        //bit.Q14();
        //dataArr.Q6();
        //s.Q3();
        g.Q3();
    }

    public static int[] ReadInts()
        => Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

    public static long[] ReadLongs()
        => Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

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