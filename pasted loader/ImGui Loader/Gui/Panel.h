#pragma once

#include "main.h"

class CPanel
{
private:
	std::string welcomemsg = cryptor::E("Happy to see you again").decrypt();
	std::string nickname = cryptor::E("CheeseItz Loader").decrypt();
private:
	ImFont* pFont, * FontAwesome, * FontAwesomeBrands, * BiggerFont, * LogoFont;
	int GameID = 0;
public:
	CPanel(ID3D11Device* pDevice);
	~CPanel();

	void Render(bool* PanelOpen);
	void Theme();
	void Shutdown();

public:
	bool IsLogged = false;
	bool IsLogging = false;
	float LoggingTimer = 0.f;
public:
	bool IsInjected = false;
	bool IsInjecting = false;
	float InjectorTimer = 0.f;
	float InjectorWaitTimer = 2.f;
public:
	int TitlebarSize = 90;
	int BannerShadows = 20;
	int GameShadows = 40;
	int CharacterSize = 200;
	char username[128] = "";
	char password[128] = "";
	char key[128] = "";
	bool rme = false;
};

extern CPanel* pPanel;