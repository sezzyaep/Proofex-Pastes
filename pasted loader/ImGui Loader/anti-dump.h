#pragma once

#include <windows.h>
#include <iostream>
#include <winternl.h>


#include <vector>

namespace client
{
    class dump
    {
    private:
    public:
        int null_size() {
            const auto peb = (PPEB)__readgsqword(0x60);

            const auto in_load_order_module_list = (PLIST_ENTRY)peb->Ldr->Reserved2[1];
            const auto table_entry = CONTAINING_RECORD(in_load_order_module_list, LDR_DATA_TABLE_ENTRY, Reserved1[0]);
            const auto p_size_of_image = (PULONG)&table_entry->Reserved3[1];
            *p_size_of_image = (ULONG)((INT_PTR)table_entry->DllBase + 0x100000);

            return 0;
        }
    };
}