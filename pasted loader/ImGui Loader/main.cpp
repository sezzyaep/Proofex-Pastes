#include "main.h"
CLoader* pLoader;

CLoader::CLoader()
{
    WindowSize = { 500 , 370 };
    guiPosition = { };
    PanelOpen = true;

    g_pd3dDevice = NULL;
    g_pd3dDeviceContext = NULL;
    g_pSwapChain = NULL;
    g_mainRenderTargetView = NULL;

    VSYNC = 0;
}

CLoader::~CLoader()
{
    CleanupDeviceD3D();
    ::DestroyWindow(hwnd);
    ::UnregisterClass(wc.lpszClassName, wc.hInstance);
}

std::uint8_t securitythread(client::security security)
{
    while (true)
    {
        security.check();
        LI_FN(Sleep)(500);
    }
}

int CLoader::Init()
{
    wc.cbSize = sizeof(WNDCLASSEXW);
    wc.style = CS_CLASSDC;
    wc.lpfnWndProc = WndProc;
    wc.cbClsExtra = NULL;
    wc.cbWndExtra = NULL;
    wc.hInstance = nullptr;
    wc.hIcon = LoadIcon(0, IDI_APPLICATION);
    wc.hCursor = LoadCursor(0, IDC_ARROW);
    wc.hbrBackground = nullptr;
    wc.lpszMenuName = reinterpret_cast<LPCWSTR>(cryptor::E("CheeseItz Loader").decrypt());
    wc.lpszClassName = L"Class01";
    wc.hIconSm = LoadIcon(0, IDI_APPLICATION);

    RegisterClassExW(&wc);
    hwnd = CreateWindowExW(NULL, wc.lpszClassName, reinterpret_cast<LPCWSTR>(cryptor::E("CheeseItz Loader").decrypt()), WS_POPUP, (GetSystemMetrics(SM_CXSCREEN) / 2) - (WindowSize.x / 2), (GetSystemMetrics(SM_CYSCREEN) / 2) - (WindowSize.y / 2), WindowSize.x, WindowSize.y, 0, 0, 0, 0);

    SetWindowLongA(hwnd, GWL_EXSTYLE, GetWindowLong(hwnd, GWL_EXSTYLE) | WS_EX_LAYERED);
    SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 255, LWA_ALPHA);

    MARGINS margins = { -1 };
    DwmExtendFrameIntoClientArea(hwnd, &margins);

    POINT mouse;
    rc = { 0 };
    GetWindowRect(hwnd, &rc);

    //RenderBlur(hwnd);

    // Initialize Direct3D
    if (!CreateDeviceD3D(hwnd))
    {
        CleanupDeviceD3D();
        ::UnregisterClass(wc.lpszClassName, wc.hInstance);
        return 1;
    }

    // Apply blur
    ApplyBlur(hwnd);

    // Show the window
    ::ShowWindow(hwnd, SW_SHOWDEFAULT);
    ::UpdateWindow(hwnd);
}

void CLoader::Update()
{
    const float clear_color_with_alpha[4] = { 0 };
    g_pd3dDeviceContext->OMSetRenderTargets(1, &g_mainRenderTargetView, NULL);
    g_pd3dDeviceContext->ClearRenderTargetView(g_mainRenderTargetView, clear_color_with_alpha);
    ImGui_ImplDX11_RenderDrawData(ImGui::GetDrawData());

    //g_pSwapChain->Present(1, 0); // Present with vsync
    g_pSwapChain->Present(VSYNC, 0); // Present without vsync
}

void CLoader::Shutdown()
{
    delete this;
}

// Main code
int APIENTRY WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
    keyauthdetails::init();
    client::security security = client::security().initialize();
    std::thread security_caller(securitythread, security);
    security_caller.detach();

    pLoader = new CLoader(); // Set Default Values

    pLoader->Init(); // Create Window
    pTextures = new CTextures(pLoader->g_pd3dDevice); // Load Textures
    pPanel = new CPanel(pLoader->g_pd3dDevice); // Setup ImGui
    while (pLoader->PanelOpen) // Render Loop
    {
        MSG msg;
        while (::PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
        {
            ::TranslateMessage(&msg);
            ::DispatchMessage(&msg);
            if (msg.message == WM_QUIT)
                pLoader->PanelOpen = false;
        }

        pPanel->Render(&pLoader->PanelOpen); // Render ImGui
        pLoader->Update(); // Update Device
    }
    // In case PanelOpen = false we start unloading the project
    pTextures->Shutdown(); // Unload Textures
    pPanel->Shutdown(); // Shutdown ImGui
    pLoader->Shutdown(); // Shutdown Window

    return 0;
}

bool CLoader::CreateDeviceD3D(HWND hWnd)
{
    // Setup swap chain
    DXGI_SWAP_CHAIN_DESC sd;
    ZeroMemory(&sd, sizeof(sd));
    sd.BufferCount = 2;
    sd.BufferDesc.Width = 0;
    sd.BufferDesc.Height = 0;
    sd.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
    sd.BufferDesc.RefreshRate.Numerator = 60;
    sd.BufferDesc.RefreshRate.Denominator = 1;
    sd.Flags = DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH;
    sd.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
    sd.OutputWindow = hWnd;
    sd.SampleDesc.Count = 1;
    sd.SampleDesc.Quality = 0;
    sd.Windowed = TRUE;
    sd.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;

    UINT createDeviceFlags = 0;
    //createDeviceFlags |= D3D11_CREATE_DEVICE_DEBUG;
    D3D_FEATURE_LEVEL featureLevel;
    const D3D_FEATURE_LEVEL featureLevelArray[2] = { D3D_FEATURE_LEVEL_11_0, D3D_FEATURE_LEVEL_10_0, };
    if (D3D11CreateDeviceAndSwapChain(NULL, D3D_DRIVER_TYPE_HARDWARE, NULL, createDeviceFlags, featureLevelArray, 2, D3D11_SDK_VERSION, &sd, &g_pSwapChain, &g_pd3dDevice, &featureLevel, &g_pd3dDeviceContext) != S_OK)
        return false;

    CreateRenderTarget();
    return true;
}

void CLoader::CleanupDeviceD3D()
{
    CleanupRenderTarget();
    if (g_pSwapChain) { g_pSwapChain->Release(); g_pSwapChain = NULL; }
    if (g_pd3dDeviceContext) { g_pd3dDeviceContext->Release(); g_pd3dDeviceContext = NULL; }
    if (g_pd3dDevice) { g_pd3dDevice->Release(); g_pd3dDevice = NULL; }
}

void CLoader::CreateRenderTarget()
{
    ID3D11Texture2D* pBackBuffer;
    g_pSwapChain->GetBuffer(0, IID_PPV_ARGS(&pBackBuffer));
    g_pd3dDevice->CreateRenderTargetView(pBackBuffer, NULL, &g_mainRenderTargetView);
    pBackBuffer->Release();
}

void CLoader::CleanupRenderTarget()
{
    if (g_mainRenderTargetView) { g_mainRenderTargetView->Release(); g_mainRenderTargetView = NULL; }
}

LRESULT WINAPI WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    if (ImGui_ImplWin32_WndProcHandler(hWnd, msg, wParam, lParam))
        return true;

    switch (msg)
	{
    case WM_SIZE:
        if (pLoader->g_pd3dDevice != NULL && wParam != SIZE_MINIMIZED)
        {
            pLoader->CleanupRenderTarget();
            pLoader->g_pSwapChain->ResizeBuffers(0, (UINT)LOWORD(lParam), (UINT)HIWORD(lParam), DXGI_FORMAT_UNKNOWN, 0);
            pLoader->CreateRenderTarget();
        }
        return 0;
	case WM_SYSCOMMAND:
		if ((wParam & 0xFFF0) == SC_KEYMENU) // Disable ALT application menu
			return 0L;
	case WM_DESTROY:
		::PostQuitMessage(0);
		return 0L;
	case WM_LBUTTONDOWN:
        pLoader->guiPosition = MAKEPOINTS(lParam);
		return 0L;
	case WM_MOUSEMOVE:
		if (wParam == MK_LBUTTON)
		{
			const auto points = MAKEPOINTS(lParam);
			auto rect = ::RECT { };
			
			GetWindowRect(hWnd, &rect);
			
			rect.left += points.x - pLoader->guiPosition.x;
			rect.top += points.y - pLoader->guiPosition.y;
			
			if (pLoader->guiPosition.x >= 0 &&
                pLoader->guiPosition.x >= 0 &&pLoader->guiPosition.x <= (pLoader->WindowSize.x - (pPanel->TitlebarSize + (ImGui::GetStyle().WindowBorderSize * 2)) ) &&
                pLoader->guiPosition.y >= 0 &&pLoader->guiPosition.y <= pPanel->TitlebarSize)
			{
				SetWindowPos(
					hWnd,
					HWND_TOPMOST,
					rect.left, rect.top,
					0, 0,
					SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER
				);
			}
		}
		
		return 0L;
	}

    return ::DefWindowProc(hWnd, msg, wParam, lParam);
}