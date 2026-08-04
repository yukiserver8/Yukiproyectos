#include "stdafx.h"
#include "GoldenArcher.h"
#include "DSProtocol.h"
#include "GameMain.h"
#include "ItemManager.h"
#include "Util.h"

namespace
{
	const int GOLDEN_ARCHER_LIFE = GET_ITEM(14,16);
	const int GOLDEN_ARCHER_BLESS = GET_ITEM(14,13);
	const int GOLDEN_ARCHER_SOUL = GET_ITEM(14,14);
	const int GOLDEN_ARCHER_CREATION = GET_ITEM(14,22);
	const int GOLDEN_ARCHER_COST[2] = {5,2};
	const int GOLDEN_ARCHER_MATERIAL[2] = {GOLDEN_ARCHER_LIFE,GOLDEN_ARCHER_CREATION};
	const int GOLDEN_ARCHER_REWARD[2] = {GOLDEN_ARCHER_BLESS,GOLDEN_ARCHER_SOUL};
}

CGoldenArcher gGoldenArcher;

CGoldenArcher::CGoldenArcher()
{
}

CGoldenArcher::~CGoldenArcher()
{
}

void CGoldenArcher::CGGoldenArcherMaterialSend(int aIndex)
{
	LPOBJ lpObj = &gObj[aIndex];

	if(gObjIsConnectedGP(aIndex) == 0 || lpObj->Interface.type != INTERFACE_GOLDEN_ARCHER)
	{
		return;
	}

	PMSG_GOLDEN_ARCHER_MATERIAL_SEND pMsg;
	pMsg.header.set(0x94,sizeof(pMsg));
	pMsg.type = 0;
	pMsg.material[0] = (DWORD)gItemManager.GetInventoryItemCount(lpObj,GOLDEN_ARCHER_LIFE,0);
	pMsg.material[1] = (DWORD)gItemManager.GetInventoryItemCount(lpObj,GOLDEN_ARCHER_CREATION,0);
	DataSend(aIndex,(BYTE*)&pMsg,pMsg.header.size);
}

void CGoldenArcher::CGGoldenArcherExchangeRecv(PMSG_GOLDEN_ARCHER_EXCHANGE_RECV* lpMsg,int aIndex)
{
	LPOBJ lpObj = &gObj[aIndex];

	if(gObjIsConnectedGP(aIndex) == 0 || lpObj->Interface.use == 0 || lpObj->Interface.type != INTERFACE_GOLDEN_ARCHER)
	{
		return;
	}

	if(lpMsg->type >= 2 || lpObj->GoldenArcherTransaction != 0)
	{
		return;
	}

	lpObj->GoldenArcherTransaction = 1;

	if(gItemManager.GetInventoryItemCount(lpObj,GOLDEN_ARCHER_MATERIAL[lpMsg->type],0) >= GOLDEN_ARCHER_COST[lpMsg->type] &&
		gItemManager.CheckItemInventorySpace(lpObj,GOLDEN_ARCHER_REWARD[lpMsg->type]) != 0)
	{
		gItemManager.DeleteInventoryItemCount(lpObj,GOLDEN_ARCHER_MATERIAL[lpMsg->type],0,GOLDEN_ARCHER_COST[lpMsg->type]);
		GDCreateItemSend(aIndex,0xEB,0,0,GOLDEN_ARCHER_REWARD[lpMsg->type],0,0,0,0,0,-1,0,0,0);
	}

	lpObj->GoldenArcherTransaction = 0;
	this->CGGoldenArcherMaterialSend(aIndex);
}

void CGoldenArcher::CGGoldenArcherCloseRecv(int aIndex)
{
	LPOBJ lpObj = &gObj[aIndex];

	if(gObjIsConnectedGP(aIndex) == 0 || lpObj->Interface.type != INTERFACE_GOLDEN_ARCHER)
	{
		return;
	}

	lpObj->Interface.use = 0;
	lpObj->Interface.type = INTERFACE_NONE;
	lpObj->Interface.state = 0;
}
