#pragma once

#include <windows.h>
#include <vector>
#include <string>
#include <TlHelp32.h>

#include "patch-check.h"
#include "assemblydetect.h"
#include "process-detections.h"
#include "antidbg.h"
#include "anti-dump.h"
#include "anti-vm.h"
#include "enc.h"
#include "lazy.h"

namespace client
{
    class security
    {
    private:
        client::dump* dump;
        client::vm* vm;
        client::debugger* debugger;
        client::assembly* assembly;
        client::processes* processes;
        client::patch* patch;
    public:
        client::security initialize() {
            debugger = new client::debugger;
            assembly = new client::assembly;
            processes = new client::processes;
            vm = new client::vm;
            dump = new client::dump;
            patch = new client::patch;

            patch->dbgbreakpoint_patch();
            patch->dbguiremotebreakin_patch();

            dump->null_size();

            return *this;
        }

        std::uint8_t check() {

            // debugger checks
            if (debugger->is_debugger_present() || debugger->remote_debugger_present() || debugger->peb_being_debugged() || debugger->debug_string() || debugger->process_debug_port() || debugger->process_debug_flags() || debugger->process_debug_object_handle()) {
                LI_FN(exit).safe()(0);
            }

            // virtual machine checks (only vbox is pasted since i have no clue how vbox operates)
            if (vm->sandboxie())
            {
                LI_FN(exit).safe()(0);
            }

            // process checks
            if (processes->find_debugger()) {
                LI_FN(exit).safe()(0);
            }

            // assembly checks
            if (assembly->debug_break()) {
                LI_FN(exit).safe()(0);
            }

            return 0;
        }
    };
}
