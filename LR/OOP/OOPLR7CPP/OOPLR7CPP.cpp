#include <iostream>
#include <cmath>

using namespace std;

class ZeroDivideException
{
public:
    int idx;
    ZeroDivideException(int i)
    {
        idx = i;
    }
};

class LogException
{
public:
    int idx;
    LogException(int i)
    {
        idx = i;
    }
};

class IndexException
{
public:
    int idx;
    IndexException(int i)
    {
        idx = i;
    }
};

void SetValue(double val, int i, int n, double* ar)
{
    if (val == -1)  
    {
        ar[i] = 0.0;
        throw ZeroDivideException(i);
    }
    if (val < -1) 
    {
        ar[i] = 0.0;
        throw LogException(i);
    }
    if (i >= n)       
        throw IndexException(i);
    ar[i] = log(1 / (val+1) );
}

void SetValue(double* val, double* val2, int i, int n, double* ar)
{
    if (val2[i+1] == 0)
    {
        ar[i] = 0.0;
        throw ZeroDivideException(i);
    }
    if (i >= n)
        throw IndexException(i);

    ar[i] = val[i] / val2[i + 1];
}

void Print(int i, int n, double* ar)
{
    if (i >= n)    
        throw IndexException(i);
    cout<<"Array[" << i << "]" << " = " <<ar[i] << endl;
}
void Print(int i, int n, int n2,int n3 ,double* ar)
{
    if (i >= n)
        throw IndexException(i);
    if (i >= n2)
        throw IndexException(i);
    if (i >= n3)
        throw IndexException(i);
    cout << "Array[" << i << "]" << " = " << ar[i] << endl;
}

int main()
{
    setlocale(LC_ALL, "ru");
    srand(time(NULL));
    int n1 = 16;
    int n2 = 21;
    int n3 = 22;
    double* a = new double[n1];
    double* b = new double[n2];
    double* c = new double[n3];
    double x = -2.0;

    //fill A
    for (int i = 0; x <= 4.0; i++, x += 0.3)
    {
        try
        {
            SetValue(x, i, n1, a);
        }
        catch (ZeroDivideException ex)
        {
            cout << "(Array A)Zero divide errorin index " << ex.idx << endl;
        }
        catch (LogException ex)
        {
            cout << "(Array A)Logarithm error in index " << ex.idx << endl;
        }
        catch (IndexException ex)
        {
            cout << "(Array A)Index out of range in index(set value) " << ex.idx << endl;
        }
    }
    //fill B
    for (int i = 0; i < n2; i++)
    {
        b[i] = rand() % 10 - 5;
    }
    // fill C
    for (int i = 0; i < n3; i++)
    {
        try
        {
            SetValue(a, b, i, n3, c);
        }
        catch (ZeroDivideException ex)
        {
            cout << "(Array C)Zero divide error in index " << ex.idx << endl;
        }
        catch (IndexException ex)
        {
            cout << "(Array C)Index out of range in index(set value) " << ex.idx << endl;
        }
    }


    cout << "-------------Выводим массив a-------------" << endl;
    for (int i = 0; i < n1; i++)
    {
        try
        {
            Print(i, n1, a);
        }
        catch (IndexException ex)
        {
            cout << "(Array A)Index out of range in index " << ex.idx << endl;
        }
    }

    cout << "-------------Выводим массив b-------------" << endl;
    for (int i = 0; i < n2; i++)
    {
        try
        {
            Print(i, n2, b);
        }
        catch (IndexException ex)
        {
            cout << "(Array B)Index out of range in index " << ex.idx << endl;
        }
    }

    cout << "-------------Выводим массив c-------------" << endl;
    for (int i = 0; i < n3; i++)
    {
        try
        {
            Print(i, n1, n2, n3, c);
        }
        catch (IndexException ex)
        {
            cout << "(Array C)Index out of range in index " << ex.idx << endl;
        }
    }
    cout << endl;
    delete[]a;
    delete[]b;
    delete[]c;
    return 0;
}