
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
        /// 渡された引数の値numで初期化します
        /// </summary>
        /// <param name="num">初期化する値</param>
        public Number(int? num)
        {
            number = num;
        }

        /// <summary>
        /// フィールド変数numberがnullなら-1、null以外ならnumberを返します
        /// </summary>
        public int? Value
        {
            get
            {
                if (number.HasValue)
                {
                    return this.number;
                }

                return -1;
            }
        }

        /// <summary>
        /// intとNumberで暗黙的な変換をできるようにします
        /// </summary>
        /// <param name="num">値</param>
        public static implicit operator Number(int num)
        {
            return new Number(num);
        }

        /// <summary>
        /// 2つのNumberを比較した結果を返します
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>true or false</returns>
        public static bool operator< (Number lhs,Number rhs)
        {
            return lhs.Value < rhs.Value;
        }

        /// <summary>
        /// 2つのNumberを比較した結果を返します
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">左辺値</param>
        /// <returns>true or false</returns>
        public static bool operator> (Number lhs, Number rhs)
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
        List<Number> numbers;

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
        /// <param name="number">追加する数字(int)</param>
        public void Append(int? number)
        {
            numbers.Add(number);
        }

        /// <summary>
        /// Listに数字を追加します
        /// </summary>
        /// <param name="number">追加する数字(Number)</param>
        public void Append(Number number)
        {
            numbers.Add(number);
        }

        /// <summary>
        /// 数列を全てアウトプットします
        /// </summary>
        public void Output()
        {
            numbers.ForEach
                (
                num => Console.WriteLine(num.Value)
                );
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
                    if (numbers[j] < numbers[j - 1])
                    { 
                        int? temp = numbers[j].Value;
                        numbers[j] = new Number(numbers[j - 1].Value);
                        numbers[j - 1] = new Number(temp);
                    }
                }
            }
        }

        /// <summary>
        /// 引数で渡された番号にある数字を取得します
        /// </summary>
        /// <param name="num">先頭からの番号</param>
        /// <returns>指定した番号の値</returns>
        public int? GetNumber(int num)
        {
            return numbers[num].Value;
        }

        /// <summary>
        /// 引数で渡された番号にあるNumberを取得します
        /// </summary>
        /// <param name="i">先頭からの番号</param>
        /// <returns>指定した番号のNumber</returns>
        public Number this[int i]
        {
            get { return this.numbers[i]; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();

            Random random = new Random();

            for(int i = 0;i < 100;i++)
            {

                numbers.Append(random.Next(0,101));
            }
            numbers.Append(new Number(null));

            numbers.SortValue();

            numbers.Output();

            Console.WriteLine("100番目の番号\n" + numbers.GetNumber(100));
        }
    }   

}
