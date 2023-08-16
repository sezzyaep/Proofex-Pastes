#pragma once

#include <windows.h>
#include <vector>
#include <string>
#include <TlHelp32.h>
#include <winternl.h>
#include <tchar.h>

#include "enc.h"
#include "lazy.h"

namespace client
{
	class processes {
	private:
		DWORD get_process_id_from_name(LPCTSTR ProcessName)
		{
			PROCESSENTRY32 pe32;
			HANDLE hSnapshot = NULL;
			ZeroMemory(&pe32, sizeof(PROCESSENTRY32));

			hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

			if (hSnapshot == INVALID_HANDLE_VALUE)
				return 0;
			pe32.dwSize = sizeof(PROCESSENTRY32);

			if (Process32First(hSnapshot, &pe32) == FALSE)
			{

				CloseHandle(hSnapshot);
				return 0;
			}


			if (_tcsicmp(pe32.szExeFile, ProcessName) == FALSE)
			{

				CloseHandle(hSnapshot);
				return pe32.th32ProcessID;
			}

			while (Process32Next(hSnapshot, &pe32))
			{
				if (_tcsicmp(pe32.szExeFile, ProcessName) == 0)
				{
					// Cleanup the mess
					CloseHandle(hSnapshot);
					return pe32.th32ProcessID;
				}
			}

			CloseHandle(hSnapshot);
			return 0;
		}
	public:
		bool find_debugger()
		{
			if (LI_FN(IsDebuggerPresent)())
			{
				return true;
			}
			else {
				return false;
			}
		}
	};
}