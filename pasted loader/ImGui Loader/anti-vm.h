#pragma once

#include <windows.h>
#include <iostream>
#include <winternl.h>
#include <vector>
#include <tchar.h>

#include "lazy.h"
#include "enc.h"
#include <TlHelp32.h>
#include "main.h"

namespace client
{
    class vm
    {
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

        void to_lower(unsigned char* input)
        {
            char* p = (char*)input;
            unsigned long length = strlen(p);
            for (unsigned long i = 0; i < length; i++) p[i] = tolower(p[i]);
        }
    public:
        int sandboxie() {
            // check if sandboxie dll is loaded onto exe
            if (LI_FN(LoadLibraryA).safe()(cryptor::E("SbieDll.dll").decrypt()))
                return 1;

            return 0;
        }
    };
}