﻿using System;
using System.Linq;

/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            int[] arr;
            checked
            {
                try
                {
                    // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                    arr = Array.ConvertAll(
                            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                            x => int.Parse(x));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("FormatException");
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowException");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ArgumentException");
                    return;
                }

                // использовать синтаксис методов! SQL-подобные запросы не писать!
                try
                {
                    int arrAggregate = arr.Select((x, ind) => (int)Math.Pow(-1, ind) * x).Aggregate(5, (x, y) => x + y);

                    int arrMyAggregate = MyClass.MyAggregate(arr);

                    Console.WriteLine(arrAggregate);
                    Console.WriteLine(arrMyAggregate);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowException");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ArgumentException");
                    return;
                }
                
            }
        }
    }

    static class MyClass
    {
        public static int MyAggregate(int[] coll)
        {
            return coll.Select((x, ind) => (int)Math.Pow(-1, ind) * x).Aggregate(5, (x, y) => x + y);
        }
    }
}
