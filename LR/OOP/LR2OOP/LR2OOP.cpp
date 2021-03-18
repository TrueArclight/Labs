#define _USE_MATH_DEFINES
#include <iostream>
#include <cmath>

using namespace std;

class Sphere {

private:
	double diameter;
	double radius;
	double fullArea;
	double volume;
	string name;

public:
	Sphere(double radius, string name) {
		this->radius = radius;
		this->diameter = 2 * radius;
		fullArea = NULL;
		volume = NULL;
		this->name = name;
	}
	Sphere(double radius) {
		this->radius = radius;
		this->diameter = 2*radius;
		fullArea = NULL;
		volume = NULL;
		name = "Figure without name";
	}
	Sphere() {
		diameter = NULL;
		radius = NULL;
		fullArea = NULL;
		volume = NULL;
		name = "Figure without name";
	}
	void setRadius(double radius) {
		this->radius = radius;
		this->diameter = 2*radius;
	}
	double getDiameter() {
		return diameter;
	}
	double getRadius() {
		return radius;
	}
	double getVolume() {
		volume = (4 *M_PI*pow(radius,3)) / 3;
		return volume;
	}
	double getFullArea() {
		fullArea = 4 * M_PI * pow(radius, 2);
		return fullArea;
	}
	void setName(string name) {
		this->name = name;
	}
	string getName() {
		return name;
	}
	void printInfo() {
		cout << "���������� � ����" << endl;
		cout << "�������� ������: " << getName() << endl;
		cout << "������ ����: " << getRadius() <<" ��" << endl;
		cout << "������� ����: " << getDiameter() << " ��" << endl;
		cout << "����� ����: " << getVolume() << " ��^3" << endl;
		cout << "������� ������ ����������� ����: " << getFullArea() << " ��^2" << endl;
	}
	
};

int main()
{
	setlocale(LC_ALL, "ru");
	Sphere sphere;
	double radius;
	cout << "����� ������ ����(cm): ";
	cin >> radius;
	sphere.setRadius(radius);
	Sphere sphere1(20);
	Sphere sphere2(30, "Ball");
	system("cls");
	sphere.printInfo();
	sphere1.printInfo();
	sphere2.printInfo();
}
