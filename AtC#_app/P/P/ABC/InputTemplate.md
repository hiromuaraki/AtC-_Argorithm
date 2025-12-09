## 入力のテンプレート

## 1行でスペースの区切りの配列に分割して受け取る
入力：12 99 0
// Split()の引数を省略すると" "区切りで配列型で分割
string[] line = Console.readLine().Split();

結果：["12", "99", "0"]

## 1行でスペース区切りの整数型配列で受け取る
入力：12 99 0
int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
結果：[12, 99, 0]

## 1行ノーマル
入力：9
int n = int.Parse(Console.ReadLine());

結果：9

## 文字列を配列で受け取る
入力；abc
var s = Console.ReadLine().ToCharArray();

結果：['a', 'b', 'c']

## 重複を除いたカウント
var st = s.Distinct().Count();