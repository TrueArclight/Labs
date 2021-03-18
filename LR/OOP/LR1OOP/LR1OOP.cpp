#include <iostream>

using namespace std;

class Calculator {
private:
    int num_one;
    int num_two;
    int num_three;
    double dnum_one;
    double dnum_two;
    double dnum_three;
public:
    void setIntNumbers(int a, int b, int c);
    void setDoubleNumbers(double a, double b, double c);
    void getDoubleNumbers();
    void getIntNumbers();
    int getSum();
    int getSub();
    int getMult();
    double getDoubleSum();
    double getDoubleSub();
    double getDoubleMult();
    void getDiv();
    void getIntDiv();
    void print();
};
void Calculator::setIntNumbers(int a, int b, int c) {
    num_one = a;
    num_two = b;
    num_three = c;
}
void Calculator::setDoubleNumbers(double a, double b, double c) {
    dnum_one = a;
    dnum_two = b;
    dnum_three = c;
}
void Calculator::getIntNumbers() {
    cout << num_one<< " " << num_two << " " << num_three << endl;
}
void Calculator::getDoubleNumbers() {
    cout << dnum_one << " " << dnum_two << " " << dnum_three << endl;
}
int Calculator::getSum() {
    int result = num_one + num_two + num_three;
    return result;
}
int Calculator::getSub() {
    int result = num_one - num_two - num_three;
    return result;
}
int Calculator::getMult() {
    int result = num_one * num_two * num_three;
    return result;
}
double Calculator::getDoubleSum() {
    double res = dnum_one + dnum_two + dnum_three;
    return res;
}
double Calculator::getDoubleSub() {
    double res = dnum_one - dnum_two - dnum_three;
    return res;
}
double Calculator::getDoubleMult() {
    double res = dnum_one * dnum_two * dnum_three;
    return res;
}
void Calculator::getDiv() {
    if (dnum_two != 0) {
        double res = dnum_one / dnum_two;
        cout << "Деление двух чисел с плаващей запятой: " << res << endl;
    } else {
        cerr << "Ошибка. Деление на ноль. " << " (" << dnum_one << "/" << dnum_two << ")"<< endl;
    }
}
void Calculator::getIntDiv() {
    if (num_two != 0) {
        int res = num_one / num_two;
        cout << "Деление двух целых чисел: " << res << endl;
    } else {
        cerr << "Ошибка. Деление на ноль. " << " (" << num_one << "/" << num_two << ")" << endl;
    }
}
void Calculator::print() {
  
    cout << "Введеные целые числа: "; 
    getIntNumbers();
    cout << "Разность трех целых чисел: " << getSub()  << endl;
    cout << "Произведение трех целых чисел: " << getMult() << endl;
    cout << "Сумма трех целых чисел: " << getSum() << endl;
    getIntDiv();
    cout << endl;
    cout << "Введеные числа с плавающей запятой: ";
    getDoubleNumbers();
    cout << "Разность трех чисел с плавающей запятой: " << getDoubleSub() << endl;
    cout << "Произведение трех чисел с плавающей запятой: " << getDoubleMult() << endl;
    cout << "Сумма трех  чисел с плавающей запятой: " << getDoubleSum() << endl;
    getDiv();
}
int main()
{
    setlocale(LC_ALL, "ru");
    Calculator calculator;
    calculator.setIntNumbers(12, 0, 2);
    calculator.setDoubleNumbers(4.2, 1.5, 0.5);
    calculator.print();
}