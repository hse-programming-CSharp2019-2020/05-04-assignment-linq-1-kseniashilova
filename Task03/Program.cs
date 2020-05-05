﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

/*Все действия по обработке данных выполнять с использованием LINQ
 * 
 * Объявите перечисление Manufacturer, состоящее из элементов
 * Dell (код производителя - 0), Asus (1), Apple (2), Microsoft (3).
 * 
 * Обратите внимание на класс ComputerInfo, он содержит поле типа Manufacturer
 * 
 * На вход подается число N.
 * На следующих N строках через пробел записана информация о компьютере: 
 * фамилия владельца, код производителя (от 0 до 3) и год выпуска (в диапазоне 1970-2020).
 * Затем с помощью средств LINQ двумя разными способами (как запрос или через методы)
 * отсортируйте коллекцию следующим образом:
 * 1. Первоочередно объекты ComputerInfo сортируются по фамилии владельца в убывающем порядке
 * 2. Для объектов, у которых фамилии владельцев сопадают, 
 * сортировка идет по названию компании производителя (НЕ по коду) в возрастающем порядке.
 * 3. Если совпадают и фамилия, и имя производителя, то сортировать по году выпуска в порядке возрастания.
 * 
 * Выведите элементы каждой коллекции на экран в формате:
 * <Фамилия_владельца>: <Имя_производителя> [<Год_производства>]
 * 
 * Пример ввода:
 * 3
 * Ivanov 1970 0
 * Ivanov 1971 0
 * Ivanov 1970 1
 * 
 * Пример вывода:
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * 
 *  * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * При некорректных входных данных (не связанных с созданием объекта) выбрасывайте FormatException
 * При невозможности создать объект класса ComputerInfo выбрасывайте ArgumentException!
 */
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int N = 0;
            List<ComputerInfo> computerInfoList = new List<ComputerInfo>();
            try
            {
                N = int.Parse(Console.ReadLine());
                if (N <= 0) throw new FormatException();
                for (int i = 0; i < N; i++)
                {
                    string[] str = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                    computerInfoList.Add(new ComputerInfo(str[0], int.Parse(str[2]), int.Parse(str[1])));
                }

                var computerInfoQuery = from comp in computerInfoList
                                        orderby comp.year descending
                                        orderby comp.ComputerManufacturer.ToString() ascending
                                        orderby comp.Owner descending
                                        select comp;

                PrintCollectionInOneLine(computerInfoQuery);

                Console.WriteLine();

                // выполните сортировку одним выражением
                var computerInfoMethods = computerInfoList.
                    OrderByDescending(x => x.year)
                    .OrderBy(x => x.ComputerManufacturer.ToString()).OrderByDescending(x => x.Owner);

                PrintCollectionInOneLine(computerInfoMethods);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
        }

        // выведите элементы коллекции на экран с помощью кода, состоящего из одной линии (должна быть одна точка с запятой)
        public static void PrintCollectionInOneLine(IEnumerable<ComputerInfo> collection)
        {
            collection.ToList().ForEach(x => Console.WriteLine(x));
        }
    }

    enum Manufacturer
    {
        Dell = 0,
        Asus = 1,
        Apple = 2,
        Microsoft = 3
    }
    class ComputerInfo
    {
        public string Owner { get; set; }
        public Manufacturer ComputerManufacturer { get; set; }
        public int year;
        public ComputerInfo(string owner, int val, int year)
        {
            Owner = owner;
            if (val < 0 || val > 3) throw new ArgumentException();
            ComputerManufacturer = (Manufacturer)Enum.GetValues(typeof(Manufacturer)).GetValue(val);
            if (year < 1970 || year > 2020) throw new ArgumentException();
            this.year = year;
        }
        public override string ToString()
        {
            return $"{Owner}: {ComputerManufacturer} [{year}]";
        }
    }
}
