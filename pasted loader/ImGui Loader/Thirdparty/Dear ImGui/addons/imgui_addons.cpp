#include "imgui_addons.h"

CImAdd* ImAdd;

ImVec4 CImAdd::Hex2RGBA(int hexValue, float alpha)
{
    float r = (hexValue >> 16) & 0xFF;
    float g = (hexValue >> 8) & 0xFF;
    float b = hexValue & 0xFF;

    return ImVec4(r / 255, g / 255, b / 255, alpha);
}
struct button_state {

    ImVec4 background_color;

};

bool CImAdd::AnimButton(const char* label, const ImVec2& size_arg, float speed, ImGuiButtonFlags flags, ImDrawFlags drawflag)
{
    using namespace ImGui;

    ImGuiWindow* window = GetCurrentWindow();
    if (window->SkipItems)
        return false;

    ImGuiContext& g = *GImGui;
    const ImGuiStyle& style = g.Style;
    const ImGuiID id = window->GetID(label);
    const ImVec2 label_size = CalcTextSize(label, NULL, true);

    ImVec2 pos = window->DC.CursorPos;
    if ((flags & ImGuiButtonFlags_AlignTextBaseLine) && style.FramePadding.y < window->DC.CurrLineTextBaseOffset) // Try to vertically align buttons that are smaller/have no padding so that text baseline matches (bit hacky, since it shouldn't be a flag)
        pos.y += window->DC.CurrLineTextBaseOffset - style.FramePadding.y;
    ImVec2 size = CalcItemSize(size_arg, label_size.x + style.FramePadding.x * 2.0f, label_size.y + style.FramePadding.y * 2.0f);

    const ImRect bb(pos, { pos.x + size.x , pos.y + size.y });
    ItemSize(size, style.FramePadding.y);
    if (!ItemAdd(bb, id))
        return false;

    if (g.LastItemData.InFlags & ImGuiItemFlags_ButtonRepeat)
        flags |= ImGuiButtonFlags_Repeat;

    bool hovered, held;
    bool pressed = ButtonBehavior(bb, id, &hovered, &held, flags);

    static std::map<ImGuiID, button_state> anim;
    auto it_anim = anim.find(id);

    if (it_anim == anim.end())
    {
        anim.insert({ id, button_state() });
        it_anim = anim.find(id);
    }

    it_anim->second.background_color = ImLerp(it_anim->second.background_color, IsItemActive() ? ImColor(GetColorU32(ImGuiCol_ButtonActive)) : hovered ? ImColor(GetColorU32(ImGuiCol_ButtonHovered)) : ImColor(GetColorU32(ImGuiCol_Button)), g.IO.DeltaTime * speed);

    window->DrawList->AddRectFilled(bb.Min, bb.Max, GetColorU32(it_anim->second.background_color), style.FrameRounding, drawflag);
    const float border_size = g.Style.FrameBorderSize;
    if (border_size > 0.0f)
    {
        window->DrawList->AddRect(bb.Min + ImVec2(1, 1), bb.Max + ImVec2(1, 1), GetColorU32(ImGuiCol_BorderShadow), style.FrameRounding, drawflag, border_size);
        window->DrawList->AddRect(bb.Min, bb.Max, GetColorU32(ImGuiCol_Border), style.FrameRounding, drawflag, border_size);
    }

    RenderTextClipped({ bb.Min.x + style.FramePadding.x , bb.Min.y + style.FramePadding.y }, { bb.Max.x - style.FramePadding.x , bb.Max.y - style.FramePadding.y }, label, NULL, &label_size, style.ButtonTextAlign, &bb);

    IMGUI_TEST_ENGINE_ITEM_INFO(id, label, g.LastItemData.StatusFlags);
    return pressed;
}

void CImAdd::GameIcon(ID3D11ShaderResourceView* texture, const char* label, ImVec2 size, int id, int* ids)
{
    ImGuiContext& g = *GImGui;
    const ImGuiStyle& style = g.Style;
    auto pos = ImGui::GetCursorPos();
    static std::map<int, bool> isHoveredMap;
    static std::map<int, float> fFadeAlphaMap;

    auto DrawLayer = ImGui::GetWindowDrawList();

    ImGui::BeginChild(label, size, true, ImGuiWindowFlags_NoBackground);
    {
        auto internalPos = ImGui::GetCursorPos();
        DrawLayer->AddImageRounded(texture, ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImVec2(0, 0), ImVec2(1, 1), IM_COL32(255, 255, 255, 255), style.WindowRounding);
        ImVec4 col = ImGui::GetStyleColorVec4(ImGuiCol_TitleBgActive);
        ImVec4 col2 = ImGui::GetStyleColorVec4(ImGuiCol_Text);
        bool& isHovered = isHoveredMap[id]; // Retrieve or create hover state for the current icon
        if (*ids == id)
        {
            DrawLayer->AddRectFilled(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImGui::GetColorU32(ImVec4(col.x, col.y, col.z, 0.5)), style.WindowRounding);
            DrawLayer->AddRect(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImGui::GetColorU32(ImVec4(col2.x, col2.y, col2.z, 0.5)), style.WindowRounding, 0, style.WindowBorderSize);
            ImGui::SetCursorPos((internalPos - style.WindowPadding) + ((ImGui::GetWindowSize() / 2) - (ImGui::CalcTextSize(label) / 2)));
            ImGui::Text(label);
        }
        if (isHovered && *ids != id)
        {
            float& fFadeAlpha = fFadeAlphaMap[id]; // Retrieve or create fade alpha value for the current icon
            DrawLayer->AddRectFilled(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImGui::GetColorU32(ImVec4(col.x, col.y, col.z, fFadeAlpha / 2)), style.WindowRounding);
        }
    }
    ImGui::EndChild();
    bool& isHovered = isHoveredMap[id]; // Retrieve hover state for the current icon
    isHovered = ImGui::IsItemHovered();
    float& fFadeAlpha = fFadeAlphaMap[id]; // Retrieve fade alpha value for the current icon
    if (isHovered)
    {
        fFadeAlpha = min(fFadeAlpha + ImGui::GetIO().DeltaTime * 6.0f, 1.0f);
    }
    else
    {
        fFadeAlpha = 0.f;
    }
    if (ImGui::IsItemHovered() && ImGui::IsMouseReleased(ImGuiMouseButton_Left))
        *ids = id;
}

void CImAdd::InputText(const char* label, const char* icon, char* buf, ImGuiInputTextFlags flags)
{
    ImGuiContext& g = *GImGui;
    const ImGuiStyle& style = g.Style;
    auto width = ImGui::CalcItemWidth();
    auto height = ImGui::GetFrameHeight();
    std::string str1 = "##";
    std::string str2 = label;
    std::string newname = (str1 + str2);
    ImGui::TextDisabled(label);
    ImGui::SetCursorPosY(ImGui::GetCursorPosY() - style.FramePadding.y / 2);
    auto pos = ImGui::GetCursorPos() + ImVec2(width, 0) - ImVec2(height, 0);
    ImGui::InputText(newname.c_str(), buf, IM_ARRAYSIZE(buf), flags);
    ImGui::GetWindowDrawList()->AddRectFilled(pos, pos + ImVec2(height, height), ImGui::GetColorU32(ImGuiCol_Border), style.FrameRounding, ImDrawFlags_RoundCornersRight);
    ImGui::SameLine(pos.x + ((height / 2) - (ImGui::CalcTextSize(icon).x / 2)));
    ImGui::SetCursorPosY(pos.y - style.FramePadding.y + ((height / 2) - (ImGui::CalcTextSize(icon).y / 2)) + 1);
    ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));
    ImGui::Text(icon);
    ImGui::PopStyleColor();
}

void CImAdd::TextSide(const char* text1, const char* text2)
{
    ImGuiContext& g = *GImGui;
    const ImGuiStyle& style = g.Style;

    ImGui::TextDisabled(text1);
    ImGui::SameLine(ImGui::GetWindowSize().x - ImGui::CalcTextSize(text2).x - style.WindowPadding.x);
    ImGui::Text(text2);
}

void CImAdd::Spinner(float radius, float thickness, int num_segments, ComVec4 color)
{
    using namespace ImGui;

    auto window = GetCurrentWindow();
    if (window->SkipItems)
        return;

    auto& g = *GImGui;
    const auto& style = g.Style;
    auto&& pos = ImGui::GetCursorPos();
    ImVec2 size{ radius * 2, radius * 2 };
    const ImRect bb{ pos, pos + size };
    ItemSize(bb);
    if (!ItemAdd(bb, 0))
        return;

    window->DrawList->PathClear();
    int start = static_cast<int>(abs(ImSin(static_cast<float>(g.Time * 1.8f)) * (num_segments - 5)));
    const float a_min = IM_PI * 2.0f * ((float)start) / (float)num_segments;
    const float a_max = IM_PI * 2.0f * ((float)num_segments - 3) / (float)num_segments;
    const auto&& centre = pos + ImVec2(radius, radius);
    for (auto i = 0; i < num_segments; i++) {
        const float a = a_min + ((float)i / (float)num_segments) * (a_max - a_min);
        auto time = static_cast<float>(g.Time);
        window->DrawList->PathLineTo({ centre.x + ImCos(a + time * 8) * radius,
                                      centre.y + ImSin(a + time * 8) * radius });
    }
    window->DrawList->PathStroke(GetColorU32(color), false, thickness);
}