#pragma once

#include "main.h"
#include "json.hpp"
#include "LiteRegedit.h"

struct stConfig
{
	struct stAimbot
	{
		bool bAimbot = false;
		bool bSilent = false;
		bool bSmooth = false;
		bool bProAim = false;
		bool bTriggerbot = false;

		int iAimbotConfig[36][3];
		bool bAimbotEnabled[36];

		float fSilentAccuracy = 100.f;

		bool bSmoothIsFire = false;
		bool bStopOnBody = false;
		bool bSmoothLockY = false;

		bool bTriggerDelay = false;
		int iTriggerDelay = 0;
		bool bTriggerSync = false;

		bool bTeamProtect = false;
		bool bLockThroughObjects = false;
		bool bIgnoreMaxDistance = false;
		bool bIgnoreAFK = false;
		bool bIgnoreEverything = false;

		int iRangeStyle = 1;
		int iSharedRangeConfig = 0;
		int iSharedSilentConfig = 0;
		int iSharedSmoothConfig = 0;
		bool bDrawRange = false;
		bool bDrawTracer = false;
		float fOutlineThickness = 2.f;
		ImVec4 colorRange = { 1.f, 1.f, 1.f, 0.5f };
	} g_Aimbot;

	struct stCombat
	{
		bool bNoReload = false;
		bool bAllowCBug = false;
		bool bCBugFreeze = false;
		bool bCBugAnim = false;
		bool bCBugText = false;
		bool bCBugWeapon = false;
		bool bRapidFire = false;
		float fRapidFire = 1.f;

		bool bFastCrosshair = false;
		bool bNoRecoil = false;
		bool bWeaponSwitcher = false;
		bool bFastSwitch = false;
		bool bAutoScroll = false;
		bool bAutoCBug = false;
		std::array<int, 2> iCBugDelay{ 25, 55 };
	} g_Combat;

	struct stPlayer
	{
		bool bGodMode = false;
		bool bDamageProof = false;
		bool bBulletProof = true;
		bool bCollisionProof = true;
		bool bExplosionProof = true;
		bool bFireProof = true;
		bool bMeleeProof = true;
		bool bAntiStun = false;
		int iAntiStunChance = 1;
		bool bFastRotation = false;
		int iFastRotation = 15;
		bool bFastSprint = false;
		float fFastSprint = 1.f;
		bool bAirBreak = false;
		int iAirBreak = 10;
		bool bMapRun = false;
		int iMapRun = 10;
		bool bInfiniteRun = false;
		bool bInfiniteOxygen = false;
		bool bNoFall = false;
		bool bMegaJump = false;
		float fMegaJump = 1.f;
		bool bChangeSkin = false;
		int iSkinID = -1;
		bool bFastRespawn = false;
		bool bUpsideMode = false;
		bool bInvertWalk = false;
		bool bShakeMode = false;
		bool bInvalidAimZ = false;
		bool bInvisible = false;
		bool bFakeLag = false;
		int iFakeLag = 1;
	} g_Player;

	struct stVehicles
	{
		bool bStopOnExitVehicle = false;
		int iStopOnExitVehicle = 500;
		bool bAutoBikeSpam = false;
		int iAutoBikeSpamKey = 0;
	} g_Vehicles;

	struct stVisuals
	{
		bool bGameVisualsChanger = false;
		bool bDrawDistanceChanger = false;
		bool bFogDistanceChanger = false;
		bool bLodDistanceChanger = false;
		bool bNameTagsESP = false;
		bool bWeaponESP = false;
		bool bSnipelineESP = false;
		int iSnipelineStyle = 0;
		bool bBoxESP = false;
		int iBoxStyle = 0;
		bool bBoneESP = false;
		bool bDistanceESP = false;
		bool bChamsESP = false;
		float fESPThickness = 1.5f;
		float fDrawDistance = 0.0f;
		float fFogDistance = 0.0f;
		float fLodDistance = 0.0f;
		bool bESPTeammates = false;
		bool bESPCustomColors = false;
		bool bFilledBox = false;
		ImVec4 colorVisible{ 0.f, 1.f, 0.f, 1.f };
		ImVec4 colorNotVisible{ 1.f, 0.f, 0.f, 1.f };

		bool bVehicleNameTagsESP = false;
		bool bVehicleHPESP = false;
		bool bVehicleStatusESP = false;
		bool bVehicleEngineESP = false;
		bool bVehicleDistanceESP = false;
		bool bVehicleBoundingBoxESP = false;

		bool bDMGInformer = false;
		int iFontSize = 13;
		float fDMGTick = 1.5f;
		ImVec4 colorDMG{ 1.f, 1.f, 1.f, 1.f };

		bool bFPSFuncs = false;
		bool bFPSUnlock = false;
		bool bFPSBoost = false;
		bool bFakeFPS = false;
		int iMinFPS = 1;
		int iMaxFPS = 1;

		bool bNoDrugsEffect = false;
		bool bPickupsESP = false;

		bool bAspectRatio = false;
		float fAspectRatio = 1.3333334f;

		bool bWeatherChanger = false;
		int iWeather = 0;
		bool bTimeChanger = false;
		int iTime = 0;
		int iChamsStyle = 0;
		int iESPHeadStyle = 0;
	} g_Visuals;
};

class CConfig
{
public:
	CConfig(const char* szName, const char* regloc);
	~CConfig();

	void Update();

	void Load(size_t index);
	void Save(size_t index);
	void Add(const char* szName);
	void Remove(size_t index);
	void Rename(size_t item, const char* szName);
	void Reset();
	void listConfigs();

	constexpr auto& getConfigs()
	{
		return Configs;
	}

	int		iActiveKey;
	bool	bDarkBackground;
	bool	bBackgroundParticles;

	CLiteRegeditEasy* pReg;
private:
	std::filesystem::path Path;
	std::vector<std::string> Configs;
};

extern CConfig* pConfig;
extern struct stConfig g_Config;