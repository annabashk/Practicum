using System;
using System.Security.Cryptography.X509Certificates;

class Program
{

    static void Main(string[] args)
    {
        NumberRead numberRead = new NumberRead();
        numberRead.NumberEnterEvent += ShowNumber;

            try
            {
                numberRead.NumRead();
            }
            catch (FormatException)
            {
                Console.WriteLine("Значение некорректно");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Возникло исключение ArgumentException");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Возникло исключение InvalidCastException");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Возникло исключение NullReferenceException");
            }

        Console.ReadKey();

        static void ShowNumber(int num, string[] array)
        {
            switch (num)
            {
                case 1:
                    Console.WriteLine("Сортировка А-Я:");
                    SortArray1(array);
                    break;
                case 2:
                    Console.WriteLine("Сортировка Я-А:");
                    SortArray2(array);
                    break;
            }
        }

        static void SortArray1(string[] array)
        {
            Array.Sort(array);
            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
        }
        static void SortArray2(string[] array)
        {
            Array.Sort(array, (x, y) => -x.CompareTo(y)); ;
            foreach (string s in array)
            {
                Console.WriteLine(s);
            }
        }
    }
}

class NumberRead
{
    public delegate void NumberEnterDelegate(int num, string[] array);
    public event NumberEnterDelegate NumberEnterEvent;

    public void NumRead()
    {
        string[] array = new string[5];
        Console.WriteLine("Введите фамилию:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        Console.WriteLine("Введите число 1 для сортировки А-Я, введите число 2 для сортировки Я-А");

        int num = Convert.ToInt32(Console.ReadLine());

        if (num != 1 && num != 2) throw new FormatException();

        NumberEnter(num,array);
    }

    protected virtual void NumberEnter(int num, string[] array)
    {
        NumberEnterEvent?.Invoke(num, array);
    }
}
