#include <iostream>
#include <conio.h>
#include <stdio.h>
#include <ctype.h>
#include <Windows.h>

using namespace std;

int main() {

	setlocale(LC_ALL, "ru");
	srand(time(NULL));
	cout << "\t\t\tСоздание файла\n";
	int size = 20;
	char name[11] = "myfile.bin";
	FILE* f;
	int* buffer = new int[size];
	for (int i = 0; i < size; i++)
		buffer[i] = rand() % 100 + 1;
	fopen_s(&f, name, "wb");
	fwrite(buffer, sizeof(int), size, f);
	delete[]buffer;
	fclose(f);

	HANDLE file = CreateFile(L"myfile.bin", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, 0, 0);
	printf("Дескриптор файла = %d", file);

	DWORD fileSize = GetFileSize(file, NULL);
	printf("\nРазмер файла = %d", fileSize);

	HANDLE fileMapping = CreateFileMapping(file, NULL, PAGE_READWRITE, 0, 0, L"myFileMapping");
	printf("\nДескриптор файлового отображения = %d", fileMapping);

	LPVOID fileMapView = MapViewOfFile(fileMapping, FILE_MAP_WRITE, 0, 0, 0);
	printf("\nОтображенная область памяти = %d", fileMapView);

	cout << "\nНаходим минимально число. . . " << endl;

	int* fileMemory = new int[fileSize / 4];
	int min = INT_MAX;
	CopyMemory(fileMemory, fileMapView, fileSize);
	for (int i = 0; i < fileSize / 4; i++) {
		cout << fileMemory[i] << " ";
		if (fileMemory[i] < min)
			min = fileMemory[i];
	}
	for (int i = 0; i < fileSize / 4; i++) {
		
		if (i == 0)
			fileMemory[i] = min;
		else 
			fileMemory[i] = 0;
	}
	cout << "\nМинимальное число " << endl;
	for (int i = 0; i < fileSize / 4; i++) {
		cout << fileMemory[i] << " ";
	}
	CopyMemory(fileMemory, fileMapView, fileSize);
	cout << "\nОсвобождаем дескрипторы..." <<endl;
	if (UnmapViewOfFile(fileMapView)) {
		cout << "Отображенная память освободилась" << endl;
	}
	else {
		cerr << "Не удалось освободить память " << endl;
	}
	if (CloseHandle(fileMapping)) {
		cout << "Файловое отображение закрыто" << endl;
	}
	else {
		cerr << "Не удалось закрыть файловое отображение" << endl;
	}
	if (CloseHandle(file)) {
		cout << "Файл успешно закрыт " << endl;
	}
	else {
		cerr << "Не удалось закрыть файл " << endl;
	}
	delete[]fileMemory;
	system("pause");
	return 0;
}