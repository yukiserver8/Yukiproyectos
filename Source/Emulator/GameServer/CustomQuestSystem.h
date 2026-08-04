#pragma once
#include "User.h"

struct CUSTOM_QUEST_INFO
{
	int QuestIndex;
	int NpcClass;
	int NpcMap;
	int NpcX;
	int NpcY;
	int MinLevel;
	int MaxLevel;
	int MinReset;
	int MaxReset;
	int RepeatType; // 0=unlimited, 1=once per day
};

struct CUSTOM_QUEST_KILL_OBJECTIVE
{
	int QuestIndex;
	int MonsterIndex;
	int KillCount;
};

struct CUSTOM_QUEST_REWARD_ITEM
{
	int QuestIndex;
	int ItemIndex;
	int ItemLevel;
	int ItemSkill;
	int ItemLuck;
	int ItemOption;
	int ItemExc;
	int ItemSet;
	int ItemQty;
};

struct CUSTOM_QUEST_PROGRESS
{
	int MonsterIndex;
	int CurrentKillCount;
};

class CCustomQuestSystem
{
public:
	CCustomQuestSystem();
	virtual ~CCustomQuestSystem();
	void Load(char* path);
	bool CheckKillObjective(LPOBJ lpObj, int QuestIndex);
	void GiveQuestReward(LPOBJ lpObj, int QuestIndex);
	void NpcTalk(LPOBJ lpNpc, LPOBJ lpObj);
	void MonsterDeath(LPOBJ lpMonster, LPOBJ lpObj);
private:
	std::vector<CUSTOM_QUEST_INFO> m_QuestInfo;
	std::vector<CUSTOM_QUEST_KILL_OBJECTIVE> m_KillObjectives;
	std::vector<CUSTOM_QUEST_REWARD_ITEM> m_RewardItems;
	std::map<std::string, std::vector<CUSTOM_QUEST_PROGRESS>> m_Progress;
	CUSTOM_QUEST_INFO* GetQuestInfoByNpc(LPOBJ lpNpc);
	CUSTOM_QUEST_INFO* GetQuestByIndex(int QuestIndex);
	bool CheckQuestRequisites(LPOBJ lpObj, CUSTOM_QUEST_INFO* lpInfo);
	int GetObjectiveKillCount(LPOBJ lpObj, int QuestIndex, int MonsterIndex);
	void SetObjectiveKillCount(LPOBJ lpObj, int QuestIndex, int MonsterIndex, int Count);
	void ClearProgress(LPOBJ lpObj, int QuestIndex);
};

extern CCustomQuestSystem gCustomQuestSystem;
