#include "stdafx.h"
#include "CustomQuestSystem.h"
#include "DSProtocol.h"
#include "MemScript.h"
#include "Notice.h"
#include "NpcTalk.h"
#include "Protocol.h"
#include "ServerInfo.h"
#include "Util.h"

CCustomQuestSystem gCustomQuestSystem;

CCustomQuestSystem::CCustomQuestSystem()
{
	this->m_QuestInfo.clear();
	this->m_KillObjectives.clear();
	this->m_RewardItems.clear();
	this->m_Progress.clear();
}

CCustomQuestSystem::~CCustomQuestSystem()
{

}

void CCustomQuestSystem::Load(char* path)
{
	CMemScript* lpMemScript = new CMemScript;

	if (lpMemScript == 0)
	{
		ErrorMessageBox(MEM_SCRIPT_ALLOC_ERROR, path);
		return;
	}

	if (lpMemScript->SetBuffer(path) == 0)
	{
		ErrorMessageBox(lpMemScript->GetLastError());
		delete lpMemScript;
		return;
	}

	this->m_QuestInfo.clear();
	this->m_KillObjectives.clear();
	this->m_RewardItems.clear();
	this->m_Progress.clear();

	try
	{
		while (true)
		{
			if (lpMemScript->GetToken() == TOKEN_END)
			{
				break;
			}

			int section = lpMemScript->GetNumber();

			while (true)
			{
				if (strcmp("end", lpMemScript->GetAsString()) == 0)
				{
					break;
				}

				if (section == 0)
				{
					CUSTOM_QUEST_INFO info;

					info.QuestIndex = lpMemScript->GetNumber();
					info.NpcClass = lpMemScript->GetAsNumber();
					info.NpcMap = lpMemScript->GetAsNumber();
					info.NpcX = lpMemScript->GetAsNumber();
					info.NpcY = lpMemScript->GetAsNumber();
					info.MinLevel = lpMemScript->GetAsNumber();
					info.MaxLevel = lpMemScript->GetAsNumber();
					info.MinReset = lpMemScript->GetAsNumber();
					info.MaxReset = lpMemScript->GetAsNumber();
					info.RepeatType = lpMemScript->GetAsNumber();

					this->m_QuestInfo.push_back(info);
				}
				else if (section == 1)
				{
					CUSTOM_QUEST_KILL_OBJECTIVE info;

					info.QuestIndex = lpMemScript->GetNumber();
					info.MonsterIndex = lpMemScript->GetAsNumber();
					info.KillCount = lpMemScript->GetAsNumber();

					this->m_KillObjectives.push_back(info);
				}
				else if (section == 2)
				{
					CUSTOM_QUEST_REWARD_ITEM info;

					info.QuestIndex = lpMemScript->GetNumber();
					info.ItemIndex = lpMemScript->GetAsNumber();
					info.ItemLevel = lpMemScript->GetAsNumber();
					info.ItemSkill = lpMemScript->GetAsNumber();
					info.ItemLuck = lpMemScript->GetAsNumber();
					info.ItemOption = lpMemScript->GetAsNumber();
					info.ItemExc = lpMemScript->GetAsNumber();
					info.ItemSet = lpMemScript->GetAsNumber();
					info.ItemQty = lpMemScript->GetAsNumber();

					this->m_RewardItems.push_back(info);
				}
				else
				{
					break;
				}
			}
		}
	}
	catch (...)
	{
		ErrorMessageBox(lpMemScript->GetLastError());
	}

	delete lpMemScript;
}

CUSTOM_QUEST_INFO* CCustomQuestSystem::GetQuestInfoByNpc(LPOBJ lpNpc)
{
	for (std::vector<CUSTOM_QUEST_INFO>::iterator it = this->m_QuestInfo.begin(); it != this->m_QuestInfo.end(); it++)
	{
		if (it->NpcClass == lpNpc->Class && it->NpcMap == lpNpc->Map)
		{
			return &(*it);
		}
	}

	return 0;
}

CUSTOM_QUEST_INFO* CCustomQuestSystem::GetQuestByIndex(int QuestIndex)
{
	for (std::vector<CUSTOM_QUEST_INFO>::iterator it = this->m_QuestInfo.begin(); it != this->m_QuestInfo.end(); it++)
	{
		if (it->QuestIndex == QuestIndex)
		{
			return &(*it);
		}
	}

	return 0;
}

bool CCustomQuestSystem::CheckQuestRequisites(LPOBJ lpObj, CUSTOM_QUEST_INFO* lpInfo)
{
	if (lpInfo->MinLevel != -1 && lpObj->Level < lpInfo->MinLevel)
	{
		return 0;
	}

	if (lpInfo->MaxLevel != -1 && lpObj->Level > lpInfo->MaxLevel)
	{
		return 0;
	}

	if (lpInfo->MinReset != -1 && lpObj->Reset < lpInfo->MinReset)
	{
		return 0;
	}

	if (lpInfo->MaxReset != -1 && lpObj->Reset > lpInfo->MaxReset)
	{
		return 0;
	}

	return 1;
}

int CCustomQuestSystem::GetObjectiveKillCount(LPOBJ lpObj, int QuestIndex, int MonsterIndex)
{
	std::string key = lpObj->Name;

	key += "_";

	key += std::to_string((long long)QuestIndex);

	std::map<std::string, std::vector<CUSTOM_QUEST_PROGRESS>>::iterator it = this->m_Progress.find(key);

	if (it == this->m_Progress.end())
	{
		return 0;
	}

	for (std::vector<CUSTOM_QUEST_PROGRESS>::iterator it2 = it->second.begin(); it2 != it->second.end(); it2++)
	{
		if (it2->MonsterIndex == MonsterIndex)
		{
			return it2->CurrentKillCount;
		}
	}

	return 0;
}

void CCustomQuestSystem::SetObjectiveKillCount(LPOBJ lpObj, int QuestIndex, int MonsterIndex, int Count)
{
	std::string key = lpObj->Name;

	key += "_";

	key += std::to_string((long long)QuestIndex);

	std::map<std::string, std::vector<CUSTOM_QUEST_PROGRESS>>::iterator it = this->m_Progress.find(key);

	if (it == this->m_Progress.end())
	{
		std::vector<CUSTOM_QUEST_PROGRESS> vec;

		CUSTOM_QUEST_PROGRESS prog;

		prog.MonsterIndex = MonsterIndex;

		prog.CurrentKillCount = Count;

		vec.push_back(prog);

		this->m_Progress.insert(std::pair<std::string, std::vector<CUSTOM_QUEST_PROGRESS>>(key, vec));

		return;
	}

	for (std::vector<CUSTOM_QUEST_PROGRESS>::iterator it2 = it->second.begin(); it2 != it->second.end(); it2++)
	{
		if (it2->MonsterIndex == MonsterIndex)
		{
			it2->CurrentKillCount = Count;
			return;
		}
	}

	CUSTOM_QUEST_PROGRESS prog;

	prog.MonsterIndex = MonsterIndex;

	prog.CurrentKillCount = Count;

	it->second.push_back(prog);
}

bool CCustomQuestSystem::CheckKillObjective(LPOBJ lpObj, int QuestIndex)
{
	for (std::vector<CUSTOM_QUEST_KILL_OBJECTIVE>::iterator it = this->m_KillObjectives.begin(); it != this->m_KillObjectives.end(); it++)
	{
		if (it->QuestIndex != QuestIndex)
		{
			continue;
		}

		int current = this->GetObjectiveKillCount(lpObj, QuestIndex, it->MonsterIndex);

		if (current < it->KillCount)
		{
			return 0;
		}
	}

	return 1;
}

void CCustomQuestSystem::GiveQuestReward(LPOBJ lpObj, int QuestIndex)
{
	for (std::vector<CUSTOM_QUEST_REWARD_ITEM>::iterator it = this->m_RewardItems.begin(); it != this->m_RewardItems.end(); it++)
	{
		if (it->QuestIndex != QuestIndex)
		{
			continue;
		}

		for (int i = 0; i < it->ItemQty; i++)
		{
			GDCreateItemSend(lpObj->Index, 0xEB, 0, 0, it->ItemIndex, it->ItemLevel, 0, it->ItemSkill, it->ItemLuck, it->ItemOption, -1, it->ItemExc, it->ItemSet, 0);
		}
	}

	CUSTOM_QUEST_INFO* lpQuestInfo = this->GetQuestByIndex(QuestIndex);

	if (lpQuestInfo != 0 && lpQuestInfo->RepeatType == 0)
	{
		this->ClearProgress(lpObj, QuestIndex);
	}

	gNotice.GCNoticeSend(lpObj->Index, 1, 0, 0, 0, 0, 0, "Mision completada! Has recibido tu recompensa.");
}

void CCustomQuestSystem::ClearProgress(LPOBJ lpObj, int QuestIndex)
{
	std::string key = lpObj->Name;

	key += "_";

	key += std::to_string((long long)QuestIndex);

	std::map<std::string, std::vector<CUSTOM_QUEST_PROGRESS>>::iterator it = this->m_Progress.find(key);

	if (it != this->m_Progress.end())
	{
		this->m_Progress.erase(it);
	}
}

void CCustomQuestSystem::NpcTalk(LPOBJ lpNpc, LPOBJ lpObj)
{
	CUSTOM_QUEST_INFO* lpInfo = this->GetQuestInfoByNpc(lpNpc);

	GCChatTargetSend(lpObj, lpNpc->Index, "Habla con Eo el Artesano! Mata 15 Aranias y 10 Budge Dragons para obtener un Heart of Love!");

	gNotice.GCNoticeSend(lpObj->Index, 1, 0, 0, 0, 0, 0, "Mision personalizada de Eo el Artesano");

	if (lpInfo == 0)
	{
		return;
	}

	if (this->CheckKillObjective(lpObj, lpInfo->QuestIndex) == 0)
	{
		gNotice.GCNoticeSend(lpObj->Index, 1, 0, 0, 0, 0, 0, "Mata 15 Aranias y 10 Budge Dragons en Lorencia para obtener tu recompensa.");

		for (std::vector<CUSTOM_QUEST_KILL_OBJECTIVE>::iterator it = this->m_KillObjectives.begin(); it != this->m_KillObjectives.end(); it++)
		{
			if (it->QuestIndex != lpInfo->QuestIndex)
			{
				continue;
			}

			int current = this->GetObjectiveKillCount(lpObj, lpInfo->QuestIndex, it->MonsterIndex);

			gNotice.GCNoticeSend(lpObj->Index, 1, 0, 0, 0, 0, 0, "%d/%d %s asesinados.", current, it->KillCount, ((it->MonsterIndex==3)?"Arania":"Budge Dragon"));
		}

		return;
	}

	this->GiveQuestReward(lpObj, lpInfo->QuestIndex);
}

void CCustomQuestSystem::MonsterDeath(LPOBJ lpMonster, LPOBJ lpObj)
{
	for (std::vector<CUSTOM_QUEST_INFO>::iterator it = this->m_QuestInfo.begin(); it != this->m_QuestInfo.end(); it++)
	{
		if (this->CheckQuestRequisites(lpObj, &(*it)) == 0)
		{
			continue;
		}

		for (std::vector<CUSTOM_QUEST_KILL_OBJECTIVE>::iterator it2 = this->m_KillObjectives.begin(); it2 != this->m_KillObjectives.end(); it2++)
		{
			if (it2->QuestIndex != it->QuestIndex)
			{
				continue;
			}

			if (it2->MonsterIndex != lpMonster->Class)
			{
				continue;
			}

			int current = this->GetObjectiveKillCount(lpObj, it->QuestIndex, it2->MonsterIndex);

			if (current >= it2->KillCount)
			{
				continue;
			}

			this->SetObjectiveKillCount(lpObj, it->QuestIndex, it2->MonsterIndex, current + 1);

			gNotice.GCNoticeSend(lpObj->Index, 1, 0, 0, 0, 0, 0, "Mision Eo: %s asesinado (%d/%d).", ((it2->MonsterIndex==3)?"Arania":"Budge Dragon"), current+1, it2->KillCount);
		}
	}
}
