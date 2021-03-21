using System;

namespace LR6._1OOP
{
    class MyArray
    {
        private int[,] _data;

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
        public static MyArray operator -(MyArray arr, int del)
        {
            MyArray a1 = new MyArray(arr);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                a1[i, del] = 123;
            }
            return a1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyArray arr = new MyArray(10, 10);
            arr -= 1;

        }
    }
}
