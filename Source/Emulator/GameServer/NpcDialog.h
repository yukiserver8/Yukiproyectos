// NpcDialog.h: interface for the CNpcDialog class.
//
//////////////////////////////////////////////////////////////////////

#pragma once

#include "Protocol.h"
#include "User.h"

struct NPC_DIALOG_INFO
{
	int MonsterClass;
	int MapNumber;
	int PosX;
	int PosY;
	char Message[128];
};

class CNpcDialog
{
public:
	CNpcDialog();
	virtual ~CNpcDialog();
	void Load(char* path);
	bool CheckDialog(LPOBJ lpNpc, LPOBJ lpObj);
private:
	std::vector<NPC_DIALOG_INFO> m_NpcDialogInfo;
};

extern CNpcDialog gNpcDialog;