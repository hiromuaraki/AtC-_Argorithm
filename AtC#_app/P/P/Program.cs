using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.ABC;
// Programクラスを定義
class Program
{
    const double TAX = 1.1;
    const int POINT_DAY5 = 5;
    // Mainメソッド
    // プログラムをコンパイル（PCが理解できる0,1に変換）＝ビルド＝.objが作成
    static void Main()　// void：戻り値なしのエントリポイント
    {
        Console.WriteLine("商品の価格を入力してください。");
        int price = int.Parse(Console.ReadLine());
        Console.WriteLine((int)(price * TAX));
        int a = 10, b =  2;
        
        Console.WriteLine($"{a} {b}");

        //int c = a;
        //a = b;
        //b = c;
        // タプルの方が可読性が高い
        (a, b) = (b, a);
        Console.WriteLine($"{a} {b}");
        double normalPoint = 0.01;
        int point = (int) (price * normalPoint) * POINT_DAY5;
        Console.WriteLine(point);

        ENTRY.Study study = new ENTRY.Study();
        AtCorderA acA = new AtCorderA();
        JOI.Joi joi = new JOI.Joi();
        //joi.Q7();
        //acA.Ac435();
        //joi.Q5();

        AtCorderB acB = new AtCorderB();
        //acB.Ac435();

        AtCorderC acC = new AtCorderC();
        acC.Ac435();
        //Console.WriteLine(study.Chapter5_5());
        //study.Chapter5_5_2();
    }
}