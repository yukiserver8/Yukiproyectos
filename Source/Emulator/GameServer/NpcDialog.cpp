// NpcDialog.cpp: implementation of the CNpcDialog class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "NpcDialog.h"
#include "MemScript.h"
#include "Util.h"
#include "Path.h"
#include "Notice.h"

CNpcDialog gNpcDialog;

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CNpcDialog::CNpcDialog() // OK
{
	this->m_NpcDialogInfo.clear();
}

CNpcDialog::~CNpcDialog() // OK
{

}

void CNpcDialog::Load(char* path) // OK
{
	CMemScript* lpMemScript = new CMemScript;

	if(lpMemScript == 0)
	{
		ErrorMessageBox(MEM_SCRIPT_ALLOC_ERROR,path);
		return;
	}

	if(lpMemScript->SetBuffer(path) == 0)
	{
		ErrorMessageBox(lpMemScript->GetLastError());
		delete lpMemScript;
		return;
	}

	this->m_NpcDialogInfo.clear();

	try
	{
		while(true)
		{
			if(lpMemScript->GetToken() == TOKEN_END)
			{
				break;
			}

			if(strcmp("end",lpMemScript->GetString()) == 0)
			{
				break;
			}

			NPC_DIALOG_INFO info;

			memset(&info,0,sizeof(info));

			info.MonsterClass = lpMemScript->GetNumber();

			info.MapNumber = lpMemScript->GetAsNumber();

			info.PosX = lpMemScript->GetAsNumber();

			info.PosY = lpMemScript->GetAsNumber();

			strcpy_s(info.Message,lpMemScript->GetAsString());

			this->m_NpcDialogInfo.push_back(info);
		}
	}
	catch(...)
	{
		ErrorMessageBox(lpMemScript->GetLastError());
	}

	delete lpMemScript;
}

bool CNpcDialog::CheckDialog(LPOBJ lpNpc, LPOBJ lpObj) // OK
{
	for(std::vector<NPC_DIALOG_INFO>::iterator it = this->m_NpcDialogInfo.begin(); it != this->m_NpcDialogInfo.end(); it++)
	{
		if(it->MonsterClass == lpNpc->Class && it->MapNumber == lpNpc->Map && it->PosX == lpNpc->X && it->PosY == lpNpc->Y)
		{
			GCChatTargetSend(lpObj,lpNpc->Index,it->Message);
			return 1;
		}
	}

	return 0;
}