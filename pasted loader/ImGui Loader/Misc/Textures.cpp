#include "Textures.h"

CTextures* pTextures;

CTextures::CTextures(ID3D11Device* pDevice)
{
	pump0 = nullptr;
	tCharacter == nullptr;
	tBanner == nullptr;
	tAvatar == nullptr;
	tValorant == nullptr;
	tRust == nullptr;
	tRust == nullptr;
	tCSGO == nullptr;
	tApex == nullptr;
	tFortnite == nullptr;
	tMinecraft == nullptr;

	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteCharacter, sizeof(byteCharacter), &info0, pump0, &tCharacter, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteBanner, sizeof(byteBanner), &info0, pump0, &tBanner, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteAvatar, sizeof(byteAvatar), &info0, pump0, &tAvatar, 0);

	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteValorant, sizeof(byteValorant), &info0, pump0, &tValorant, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteRust, sizeof(byteRust), &info0, pump0, &tRust, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteCSGO, sizeof(byteCSGO), &info0, pump0, &tCSGO, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteCS2, sizeof(byteCS2), &info0, pump0, &tApex, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteAmongUs, sizeof(byteAmongUs), &info0, pump0, &tFortnite, 0);
	D3DX11CreateShaderResourceViewFromMemory(pDevice, byteMinecraft, sizeof(byteMinecraft), &info0, pump0, &tMinecraft, 0);
}

CTextures::~CTextures()
{
	tMinecraft->Release();
	tFortnite->Release();
	tApex->Release();
	tCSGO->Release();
	tRust->Release();
	tValorant->Release();

	tAvatar->Release();
	tBanner->Release();
	tCharacter->Release();
}

ImVec2 CTextures::GetImageSizeFromTexture(ID3D11ShaderResourceView* texture)
{
	ImVec2 imageSize;

	// Get the texture from the shader resource view
	ID3D11Resource* resource = nullptr;
	texture->GetResource(&resource);

	// Query the texture for its description
	D3D11_TEXTURE2D_DESC desc;
	ID3D11Texture2D* texture2D = static_cast<ID3D11Texture2D*>(resource);
	texture2D->GetDesc(&desc);

	// Access the width and height values from the description structure
	UINT width = desc.Width;
	UINT height = desc.Height;

	// Set the image size
	imageSize.x = static_cast<float>(width);
	imageSize.y = static_cast<float>(height);

	return imageSize;
}