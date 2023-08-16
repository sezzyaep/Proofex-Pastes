#pragma once

#include "imgui_impl_dx11.h"
#include "imgui_impl_win32.h"
#include "imgui.h"
#define IMGUI_DEFINE_MATH_OPERATORS
#include "imgui_internal.h"

#include "IconsFontAwesome6.h"
#include "IconsFontAwesome6Brands.h"

#include <map>
#include <string>
#include <d3d11.h>

class CImAdd
{
public:
    IMGUI_API ImVec4        Hex2RGBA(int hexValue, float alpha);
    IMGUI_API bool          AnimButton(const char* label, const ImVec2& size_arg, float speed = 6.f, ImGuiButtonFlags flags = 0, ImDrawFlags drawflag = 0);
    IMGUI_API void          GameIcon(ID3D11ShaderResourceView* texture, const char* label, ImVec2 size, int id, int* ids);
    IMGUI_API void          InputText(const char* label,const char* icon, char* buf, ImGuiInputTextFlags flags = ImGuiInputTextFlags_None);
    IMGUI_API void          TextSide(const char* text1, const char* text2);

	using ComVec4 = const ImVec4&;
    IMGUI_API void Spinner(float radius, float thickness, int num_segments, ComVec4 color);
};

extern CImAdd* ImAdd;