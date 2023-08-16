#pragma once

#include <windows.h>
#include <vector>
#include <string>
#include <TlHelp32.h>
#include <winternl.h>

#include "enc.h"
#include "lazy.h"
#include "main.h"

namespace client
{
    class debugger
    {
    private:
        typedef NTSTATUS(__stdcall* _NtQueryInformationProcess)(_In_ HANDLE, _In_  unsigned int, _Out_ PVOID, _In_ ULONG, _Out_ PULONG);
        typedef NTSTATUS(__stdcall* _NtSetInformationThread)(_In_ HANDLE, _In_ THREAD_INFORMATION_CLASS, _In_ PVOID, _In_ ULONG);
    public:

        // there are way too many anti-debug methods added :skull:
        int is_debugger_present()
        {
            if (LI_FN(IsDebuggerPresent).safe()())
                return 1;

            return 0;
        }

        int remote_debugger_present()
        {
            BOOL is_debugger_present;

            LI_FN(CheckRemoteDebuggerPresent).safe()(LI_FN(GetCurrentProcess).safe()(), &is_debugger_present);

            return is_debugger_present;
        }

        int debug_string()
        {
            DWORD dwErrVal = 0x666;
            SetLastError(dwErrVal);
            LI_FN(OutputDebugStringA).safe()(cryptor::E("hello dear reverse engineer").decrypt());
            return GetLastError() != dwErrVal;
        }

        int hide_thread()
        {
            const auto ntdll = LI_FN(LoadLibraryA).safe()(_("ntdll.dll"));


            return 1;
        }

        int peb_being_debugged() {
            PPEB pPeb = (PPEB)__readgsqword(0x60);

            if (pPeb->BeingDebugged)
                return 1;

            return 0;
        }

        int process_debug_port() {
            const auto ntdll = LI_FN(LoadLibraryA).safe()(cryptor::E("ntdll.dll").decrypt());

            if (ntdll)
            {
                auto pfnNtQueryInformationProcess = (_NtQueryInformationProcess)GetProcAddress(
                    ntdll, cryptor::E("NtQueryInformationProcess").decrypt());

                if (pfnNtQueryInformationProcess)
                {
                    DWORD dwProcessDebugPort, dwReturned;
                    NTSTATUS status = pfnNtQueryInformationProcess(
                        GetCurrentProcess(),
                        ProcessDebugPort,
                        &dwProcessDebugPort,
                        sizeof(DWORD),
                        &dwReturned);

                    if (NT_SUCCESS(status) && (-1 == dwProcessDebugPort))
                        return 1;
                }
            }

            return 0;
        }

        int process_debug_flags() {
            const auto ntdll = LI_FN(LoadLibraryA).safe()(cryptor::E("ntdll.dll").decrypt());

            if (ntdll)
            {
                auto pfnNtQueryInformationProcess = (_NtQueryInformationProcess)GetProcAddress(
                    ntdll, cryptor::E("NtQueryInformationProcess").decrypt());

                if (pfnNtQueryInformationProcess)
                {
                    DWORD dwProcessDebugFlags, dwReturned;
                    const DWORD ProcessDebugFlags = 0x1f;
                    NTSTATUS status = pfnNtQueryInformationProcess(
                        GetCurrentProcess(),
                        ProcessDebugFlags,
                        &dwProcessDebugFlags,
                        sizeof(DWORD),
                        &dwReturned);

                    if (NT_SUCCESS(status) && (0 == dwProcessDebugFlags))
                        return 1;
                }
            }

            return 0;
        }

        int process_debug_object_handle() {
            const auto ntdll = LI_FN(LoadLibraryA).safe()(cryptor::E("ntdll.dll").decrypt());

            if (ntdll)
            {
                auto pfnNtQueryInformationProcess = (_NtQueryInformationProcess)GetProcAddress(
                    ntdll, cryptor::E("NtQueryInformationProcess").decrypt());

                if (pfnNtQueryInformationProcess)
                {
                    DWORD dwReturned;
                    HANDLE hProcessDebugObject = 0;
                    const DWORD ProcessDebugObjectHandle = 0x1e;
                    NTSTATUS status = pfnNtQueryInformationProcess(
                        GetCurrentProcess(),
                        ProcessDebugObjectHandle,
                        &hProcessDebugObject,
                        sizeof(HANDLE),
                        &dwReturned);

                    if (NT_SUCCESS(status) && (0 != hProcessDebugObject))
                        return 1;
                }
            }

            return 0;
        }
    };
}