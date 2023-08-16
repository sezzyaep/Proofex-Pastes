#pragma once



#include <d3d11.h>
#include <D3DX11tex.h>

#include "keyauthdetail.h"
#include "auth.hpp"
#include "lazy.h"
#include <fstream>
#include <filesystem>
#include "stringenc.h"
#include <iostream>
#include <chrono>
#include <windows.h>
#include <string> 
#include <stdio.h>
#include <tchar.h>
#include <dwmapi.h>

#include "modules.h"

// Dear ImGui
#include "imgui_impl_dx11.h"
#include "imgui_impl_win32.h"
#include "imgui.h"
#define IMGUI_DEFINE_MATH_OPERATORS
#include "imgui_internal.h"
// ImGui Addons
#include "imgui_addons.h"

// Panel
#include "Panel.h"
// Misc
#include "Textures.h"
// Font
#include "IconsFontAwesome6.h"
#include "IconsFontAwesome6Brands.h"
#include "MuseoSansCyrl500.h"

LRESULT WINAPI WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
extern IMGUI_IMPL_API LRESULT ImGui_ImplWin32_WndProcHandler(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam); // Forward declare message handler from imgui_impl_win32.cpp

class CLoader
{
public:
	CLoader();
	~CLoader();

	int Init();
	void Update();
	void Shutdown();

	POINTS WindowSize;
	POINTS guiPosition;
	bool PanelOpen = true;
	int VSYNC;

	ID3D11Device* g_pd3dDevice;
	ID3D11DeviceContext* g_pd3dDeviceContext;
	IDXGISwapChain* g_pSwapChain;
	ID3D11RenderTargetView* g_mainRenderTargetView;

	HWND hwnd;
	RECT rc;
	WNDCLASSEXW wc;

	// Forward declarations of helper functions
	bool CreateDeviceD3D(HWND hWnd);
	void CleanupDeviceD3D();
	void CreateRenderTarget();
	void CleanupRenderTarget();
};

extern CLoader* pLoader;

static void ApplyBlur(HWND hwnd)
{
    struct ACCENTPOLICY
    {
        int na;
        int nf;
        int nc;
        int nA;
    };
    struct WINCOMPATTRDATA
    {
        int na;
        PVOID pd;
        ULONG ul;
    };

    const HINSTANCE hm = LoadLibrary(L"user32.dll");
    if (hm)
    {
        typedef BOOL(WINAPI* pSetWindowCompositionAttribute)(HWND, WINCOMPATTRDATA*);

        const pSetWindowCompositionAttribute SetWindowCompositionAttribute = (pSetWindowCompositionAttribute)GetProcAddress(hm, cryptor::E("SetWindowCompositionAttribute").decrypt());
        if (SetWindowCompositionAttribute)
        {
            ACCENTPOLICY policy = { 3, 0, 0, 0 };
            WINCOMPATTRDATA data = { 19, &policy,sizeof(ACCENTPOLICY) };
            SetWindowCompositionAttribute(hwnd, &data);
        }
        FreeLibrary(hm);
    }
}