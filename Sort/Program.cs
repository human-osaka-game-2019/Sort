
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sort
{
    /// <summary>
    /// 数字を格納するクラス
    /// </summary>
    public class Number
    {
        /// <summary>
        /// 数字を保存しておく変数
        /// </summary>
        private int? number;

        /// <summary>
        /// 渡された引数の値で初期化します
        /// </summary>
        /// <param name="num">初期化する値</param>
        public Number(int? num = null)
        {
            number = num;
        }

        /// <summary>
        /// フィールド変数<see cref="number"/>を返します
        /// </summary>
        /// <remark>
        /// <see cref="number"/>がnullなら-1、null以外なら<see cref="number"/>を返します
        /// </remark>
        public int Value => number ?? -1;

        /// <summary>
        /// <see cref="int"/>と<see cref="Number"/>で暗黙的な変換をできるようにします
        /// </summary>
        /// <param name="num">値</param>
        public static implicit operator Number(int num)
        {
            return new Number(num);
        }

        /// <summary>
        /// 2つの<see cref="Number"/>を比較した結果を返します
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>左辺値が右辺値以下かどうか</returns>
        public static bool operator <=(Number lhs, Number rhs)
        {
            return lhs.Value < rhs.Value;
        }

        /// <summary>
        /// 2つの<see cref="Number"/>を比較した結果を返します
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>左辺値が右辺値以上かどうか</returns>
        public static bool operator >=(Number lhs, Number rhs)
        {
            return lhs.Value > rhs.Value;
        }
    }

    /// <summary>
    /// 数列を作るクラス
    /// </summary>
    public class Numbers
    {
        /// <summary>
        /// 数字を保持しておく変数
        /// </summary>
        private List<Number> numbers;

        /// <summary>
        /// インスタンス生成時にListを初期化します
        /// </summary>
        public Numbers()
        {
            numbers = new List<Number>();
        }

        /// <summary>
        /// Listに数字を追加します
        /// </summary>
        /// <param name="number">追加する数字(<see cref="int"/>)</param>
        public void Append(int? number)
        {
            numbers.Add(number);
        }

        /// <summary>
        /// Listに数字を追加します
        /// </summary>
        /// <param name="number">追加する数字(<see cref="Number"/>)</param>
        public void Append(Number number)
        {
            numbers.Add(number);
        }

        /// <summary>
        /// 数列を全てアウトプットします
        /// </summary>
        public void Output()
        {
            numbers.ForEach(
                    num => Console.WriteLine(num.Value));
        }

        /// <summary>
        /// 数列の数字をソートします
        /// </summary>
        public void SortValue()
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = numbers.Count - 1; j >= i + 1; j--)
                {
                    if (numbers[j - 1] <= numbers[j]) continue;
                    
                    Number smaller = numbers[j];
                    Number bigger = numbers[j - 1];
                    numbers[j - 1] = smaller;
                    numbers[j] = bigger;
                    
                }
            }
        }

        /// <summary>
        /// 引数で渡された番号にある<see cref="Number"/>を取得します
        /// </summary>
        /// <param name="index">要素番号(zero-based)</param>
        /// <returns>指定した番号の<see cref="Number"/></returns>
        public Number this[int index]
        {
            get => numbers[index];
            private set => numbers[index] = value;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {

                numbers.Append(random.Next(0, 101));
            }
            numbers.Append(new Number());

            numbers.SortValue();

            numbers.Output();

            Console.WriteLine("100番目の番号" + Environment.NewLine + numbers[100].Value);
        }
    }

}
