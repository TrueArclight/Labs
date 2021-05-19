#include <iostream>
#include <ctype.h>
#include <Windows.h>

using namespace std;

int main()
{
	HANDLE hFileMap;
	BOOL bResult;
	PINT lpBuffer = NULL;
	int buffer[2]{3,2};
	size_t szBuffer = sizeof(buffer);

	//1 file mapping
	hFileMap = CreateFileMapping(
		INVALID_HANDLE_VALUE,
		NULL,
		PAGE_READWRITE,
		0,
		2 * sizeof(int),
		L"Local\\MyFileMap");
	if (hFileMap == FALSE) {
		cout << "Creating file Mapping Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Creating file Mapping" << endl;
	//2 MapViewOfFile
	lpBuffer = (int*)MapViewOfFile(
		hFileMap,
		FILE_MAP_ALL_ACCESS,
		0,
		0,
		256);
	if (lpBuffer == NULL) {
		cout << "Map View of File Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Map View " << endl;

	//3 CopyMemory
	CopyMemory(
		lpBuffer,
		buffer,
		szBuffer
	);

	//4 Unmap
	bResult = UnmapViewOfFile(lpBuffer);
	if (bResult == FALSE) {
		cout << "Unmap View of File Failed, Error " << GetLastError() << endl;
	}
	cout << "Succes Unmap " << endl;
	system("pause");
	return 0;
}

