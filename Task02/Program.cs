using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }


        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr =
                    Array.ConvertAll(
                    Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
                    x => int.Parse(x));

                var filteredCollection = (arr.TakeWhile(x => x != 0)).ToArray();
                double[]filteredCollection1 = Array.ConvertAll(filteredCollection, x => (double)x);

                // использовать статическую форму вызова метода подсчета среднего
                
                double averageUsingStaticForm = 
                    (filteredCollection1.Aggregate((x, y) => (x*x+y*y)))/filteredCollection.Length;
                Console.WriteLine($"{averageUsingStaticForm:f3}".Replace('.', ','));
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = 1.0* filteredCollection.ToList().ConvertAll(x => x*x).Sum()/filteredCollection.Length;
                Console.WriteLine($"{averageUsingInstanceForm:f3}".Replace('.', ','));


                // вывести элементы коллекции в одну строку
                filteredCollection.ToList().ForEach(x => Console.Write(x + " "));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
