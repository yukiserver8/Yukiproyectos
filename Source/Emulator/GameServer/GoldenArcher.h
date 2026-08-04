#pragma once

#include "Protocol.h"

// Client -> GameServer
struct PMSG_GOLDEN_ARCHER_OPEN_RECV
{
	PBMSG_HEAD header; // C1:95
};

struct PMSG_GOLDEN_ARCHER_EXCHANGE_RECV
{
	PBMSG_HEAD header; // C1:96
	BYTE type;
};

// GameServer -> Client
struct PMSG_GOLDEN_ARCHER_MATERIAL_SEND
{
	PBMSG_HEAD header; // C1:94
	BYTE type;
	DWORD material[2];
};

class CGoldenArcher
{
public:
	CGoldenArcher();
	virtual ~CGoldenArcher();
	void CGGoldenArcherMaterialSend(int aIndex);
	void CGGoldenArcherExchangeRecv(PMSG_GOLDEN_ARCHER_EXCHANGE_RECV* lpMsg,int aIndex);
	void CGGoldenArcherCloseRecv(int aIndex);
};

extern CGoldenArcher gGoldenArcher;
