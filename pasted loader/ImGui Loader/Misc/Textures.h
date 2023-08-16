#pragma once

#include <d3d11.h>
#include <D3DX11tex.h>

#include <windows.h>
#include <string> 

#include "imgui.h"

#include "Avatar.h"
#include "Banner.h"
#include "Character.h"

#include "Valorant.h"
#include "Rush.h"
#include "CSGO.h"
#include "CS2.h"
#include "AmongUs.h"
#include "Minecraft.h"

class CTextures
{
public:
	CTextures(ID3D11Device* pDevice);
	~CTextures();

	ImVec2 GetImageSizeFromTexture(ID3D11ShaderResourceView* texture);


	void Shutdown()
	{
		delete this;
	};
	ID3D11ShaderResourceView* tBanner;
	ID3D11ShaderResourceView* tAvatar;
	ID3D11ShaderResourceView* tCharacter;

	ID3D11ShaderResourceView* tValorant;
	ID3D11ShaderResourceView* tRust;
	ID3D11ShaderResourceView* tCSGO;
	ID3D11ShaderResourceView* tApex;
	ID3D11ShaderResourceView* tFortnite;
	ID3D11ShaderResourceView* tMinecraft;
private:
	D3DX11_IMAGE_LOAD_INFO info0; 
	ID3DX11ThreadPump* pump0;
};

extern CTextures* pTextures;