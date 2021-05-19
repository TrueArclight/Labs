#include <iostream>
#include <Windows.h>
#include <ctype.h>
using namespace std;

int main()
{
	HANDLE hFileMap;
	BOOL bResult;
	PINT lpBuffer = NULL;
	//1
	hFileMap = OpenFileMapping(
		FILE_MAP_ALL_ACCESS,
		FALSE,
		L"Local\\MyFileMap");
	if (hFileMap == FALSE) {
		cout << "Open file Mapping Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Open file Mapping" << endl;
	//2 MapViewOfFile
	lpBuffer = (PINT)MapViewOfFile(
		hFileMap,
		FILE_MAP_ALL_ACCESS,
		0,
		0,
		256);
	if (lpBuffer == NULL) {
		cout << "Map View of File Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Map View " << endl;

	//3 Reading
	cout << "Reading Data: " << endl;
	for (int i = 0; i < 2; i++) {
		cout << lpBuffer[i] << endl;
	}

	//4 Unmap
	bResult = UnmapViewOfFile(lpBuffer);
	if (bResult == FALSE) {
		cout << "Unmap View of File Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Unmap " << endl;
	//5
	CloseHandle(hFileMap);

	system("pause");
	return 0;
}
