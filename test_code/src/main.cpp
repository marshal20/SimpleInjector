#include <iostream>
#include <Windows.h>
#include <TlHelp32.h>

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

bool LoadDll(HANDLE process, const char* dllPath)
{
	LPVOID remote_string;
	int path_len;
	HMODULE kernel32;
	LPVOID loadlibraryA_addr;
	HANDLE remote_thread;

	path_len = strlen(dllPath) + 1;
	remote_string = VirtualAllocEx(process, NULL, path_len * 2, MEM_COMMIT, PAGE_EXECUTE);
	WriteProcessMemory(process, remote_string, dllPath, path_len * 2, NULL);

	kernel32 = GetModuleHandleA("kernel32.dll");
	loadlibraryA_addr = GetProcAddress(kernel32, "LoadLibraryA");

	remote_thread = CreateRemoteThread(process, NULL, NULL, 
		(LPTHREAD_START_ROUTINE)loadlibraryA_addr, remote_string, NULL, NULL);

	WaitForSingleObject(remote_thread, INFINITE);
	CloseHandle(remote_thread);
	VirtualFreeEx(process, remote_string, path_len, MEM_COMMIT);
	return true;
}

void print_all_procs()
{
	HANDLE snap_shot;
	PROCESSENTRY32 proc_entry;

	snap_shot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);
	
	proc_entry.dwSize = sizeof(PROCESSENTRY32);
	if (Process32First(snap_shot, &proc_entry) == TRUE)
	{
		while (Process32Next(snap_shot, &proc_entry) == TRUE)
		{
			wprintf(L"-ID: 0x%X, \n\tExe name: %s\n", 
				proc_entry.th32ProcessID, proc_entry.szExeFile);
		}
	}

	CloseHandle(snap_shot);
}

int main()
{
	//HANDLE thread_handle;
	//lib_path = "C:\\Users\\xmadk\\Documents\\Visual Studio 2017\\Projects\\test_window_proc_thief\\bin\\Win32\\Debug\\window_proc_thief.dll";
	//thread_handle = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)LoadDll, NULL, NULL, NULL);
	//WaitForSingleObject(thread_handle, INFINITE);
	//CloseHandle(thread_handle);
	//Sleep(10000);

	print_all_procs();

	LoadDll(GetCurrentProcess(), "C:\\Users\\xmadk\\Documents\\Visual Studio 2017\\Projects\\test_window_proc_thief\\bin\\Win32\\Debug\\window_proc_thief.dll");
	Sleep(10000);

	return 0;
}