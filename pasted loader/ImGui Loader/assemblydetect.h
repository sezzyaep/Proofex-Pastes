#pragma once

#include <windows.h>
#include <vector>
#include <string>
#include <TlHelp32.h>
#include <winternl.h>

#include "enc.h"
#include "lazy.h"

namespace client
{
    class assembly {
    private:
    public:
        bool debug_break() {
            __try
            {
                LI_FN(DebugBreak).safe()();
            }
            __except (EXCEPTION_BREAKPOINT)
            {
                return false;
            }

            return true;
        }
    };
}