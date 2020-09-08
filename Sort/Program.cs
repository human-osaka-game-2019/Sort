
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sort
{
    public class Number
    {
        private int? number;

        public Number(int? num)
        {
            number = num;
        }

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

        public static implicit operator Number(int num)
        {
            return new Number(num);
        }

        public static bool operator< (Number lhs,Number rhs)
        {
            return lhs.Value < rhs.Value;
        }

        public static bool operator> (Number lhs, Number rhs)
        {
            return lhs.Value > rhs.Value;
        }

    }


    public class Numbers
    {

        List<Number> numbers;

        public Numbers()
        {
            numbers = new List<Number>();
        }

        public void Append(int? number)
        {
            numbers.Add(number);
        }

        public void Append(Number number)
        {
            numbers.Add(number);
        }

        public void Output()
        {
            numbers.ForEach
                (
                num => Console.WriteLine(num.Value)
                );
        }

        public void SortValue()
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = numbers.Count - 1; j >= i + 1; j--)
                {                
                    if (numbers[j] < numbers[j - 1])
                    { 
                        int? temp;
                        temp = numbers[j].Value;
                        numbers[j] = new Number(numbers[j - 1].Value);
                        numbers[j - 1] = new Number(temp);
                    }
                }
            }
        }
        public int? GetNumber(int num)
        {
            return numbers[num].Value;
        }

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
