#include <iostream>
#include <Windows.h>

/*
DWORD WINAPI ThreadProc(
_In_ LPVOID lpParameter
);
*/

const char* lib_path;

DWORD WINAPI LoadDll(LPVOID pram)
{
	LoadLibraryA(lib_path);

	return EXIT_SUCCESS;
}

int main()
{
	HANDLE thread_handle;
	lib_path = "C:\\Users\\xmadk\\Documents\\Visual Studio 2017\\Projects\\test_window_proc_thief\\bin\\Win32\\Debug\\window_proc_thief.dll";
	thread_handle = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)LoadDll, NULL, NULL, NULL);
	WaitForSingleObject(thread_handle, INFINITE);
	Sleep(10000);

	return 0;
}