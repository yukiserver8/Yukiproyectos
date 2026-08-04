#pragma once

#include "Protocol.h"

struct PMSG_GOLDEN_ARCHER_COUNT_RECV
{
	PBMSG_HEAD header; // C1:94
	BYTE type;
	DWORD material[2];
};

struct PMSG_GOLDEN_ARCHER_REWARD_SEND
{
	PBMSG_HEAD header; // C1:96
	BYTE type;
};

void InitGoldenArcher();
void DrawGoldenArcher();
void ControlGoldenArcher();
void GoldenArcherButtonPush();
void GoldenArcherMaterialCountRecv(PMSG_GOLDEN_ARCHER_COUNT_RECV* lpMsg);
