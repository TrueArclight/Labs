using System;

namespace LR6._1OOP
{
    class MyArray
    {
        public int[,] _data;
        public MyArray(int m, int n)
        {
            _data = new int[m, n];
        }   
        public MyArray(MyArray other)
        {
            _data = other._data;
        }
        public int GetLength(int d)
        {
            return _data.GetLength(d);
        }
        public int GetValue(int i1, int i2)
        {
            return _data[i1, i2];
        }
        public void SetValue(int i1, int i2, int val)
        {
            _data[i1, i2] = val;
        }
        public static MyArray operator -(MyArray originalArray, int columnToRemove)
        {
            int[,] tempArr = new int[originalArray._data.GetLength(0), originalArray._data.GetLength(1)];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                for (int k = 0, u = 0; k < originalArray._data.GetLength(1); k++)
                {
                    if (k < columnToRemove)
                        continue;

                    tempArr[j, u] = originalArray._data[i, k];
                    u++;
                }
                j++;
            }
            MyArray result = new MyArray(tempArr.GetLength(0), tempArr.GetLength(1) - columnToRemove);
            for(int i = 0; i < result.GetLength(0); i++)
            {
                for(int j = 0; j < result.GetLength(1); j++)
                {
                    result._data[i,j] = tempArr[i, j]; 
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyArray arr = new MyArray(5, 5);
            int min = -10, max = 10;
            Random r = new Random();
            Console.WriteLine("Заполнение массива");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr.SetValue(i, j, r.Next(min, max));
                    Console.Write("{0,3} ", arr.GetValue(i, j));
                }
                Console.WriteLine();
            }
           
            
            bool check = true;
            while (check)
            { 
                Console.Write("Введите количество столбцов, которые нужно удалить: ");
                int colsToDelete = Convert.ToInt32(Console.ReadLine());
                if (colsToDelete < arr.GetLength(1) || colsToDelete < 0)
                {
                    arr -= colsToDelete;
                    Console.WriteLine("Вывод массива");
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr.GetLength(1); j++)
                        {
                            Console.Write("{0,3} ", arr.GetValue(i, j));
                        }
                        Console.WriteLine();
                    }
                    check = false;
                }
                else
                {
                    Console.WriteLine("Неверное количество столбцов для удаления");
                }
            }
        }
    }
}
