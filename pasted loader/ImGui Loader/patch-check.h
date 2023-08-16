#pragma once

#include <windows.h>
#include <iostream>
#include <winternl.h>
#include <vector>
#include <tchar.h>

#include "enc.h"
#include "lazy.h"

namespace client
{
    class patch
    {
    private:
        struct DbgUiRemoteBreakinPatch
        {
            WORD  push_0;
            BYTE  push;
            DWORD CurrentPorcessHandle;
            BYTE  mov_eax;
            DWORD TerminateProcess;
            WORD  call_eax;
        };
    public:
        int dbgbreakpoint_patch() {
            HMODULE hNtdll = LI_FN(GetModuleHandleA).safe()(cryptor::E("ntdll.dll").decrypt());
            if (!hNtdll)
                return 0;

            FARPROC pDbgBreakPoint = GetProcAddress(hNtdll, cryptor::E("DbgBreakPoint").decrypt());
            if (!pDbgBreakPoint)
                return 0;

            DWORD dwOldProtect;
            if (!VirtualProtect(pDbgBreakPoint, 1, PAGE_EXECUTE_READWRITE, &dwOldProtect))
                return 0;

            *(PBYTE)pDbgBreakPoint = (BYTE)0xC3; // ret

            return 0;
        }

        int dbguiremotebreakin_patch() {
            HMODULE hNtdll = LI_FN(GetModuleHandleA).safe()(cryptor::E("ntdll.dll").decrypt());
            if (!hNtdll)
                return 0;

            FARPROC pDbgUiRemoteBreakin = GetProcAddress(hNtdll, cryptor::E("DbgUiRemoteBreakin").decrypt());
            if (!pDbgUiRemoteBreakin)
                return 0;

            HMODULE hKernel32 = LI_FN(GetModuleHandleA).safe()(cryptor::E("kernel32.dll").decrypt());
            if (!hKernel32)
                return 0;

            FARPROC pTerminateProcess = GetProcAddress(hKernel32, cryptor::E("TerminateProcess").decrypt());
            if (!pTerminateProcess)
                return 0;

            DbgUiRemoteBreakinPatch patch = { 0 };
            patch.push_0 = '\x6A\x00';
            patch.push = '\x68';
            patch.CurrentPorcessHandle = 0xFFFFFFFF;
            patch.mov_eax = '\xB8';
            patch.TerminateProcess = (DWORD)pTerminateProcess;
            patch.call_eax = '\xFF\xD0';

            DWORD dwOldProtect;
            if (!VirtualProtect(pDbgUiRemoteBreakin, sizeof(DbgUiRemoteBreakinPatch), PAGE_READWRITE, &dwOldProtect))
                return 0;

            ::memcpy_s(pDbgUiRemoteBreakin, sizeof(DbgUiRemoteBreakinPatch),
                &patch, sizeof(DbgUiRemoteBreakinPatch));
            VirtualProtect(pDbgUiRemoteBreakin, sizeof(DbgUiRemoteBreakinPatch), dwOldProtect, &dwOldProtect);
            return 0;
        }
    };
}