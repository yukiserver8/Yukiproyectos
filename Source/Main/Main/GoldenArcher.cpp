#include "stdafx.h"
#include "GoldenArcher.h"
#include "CustomMessage.h"
#include "Offset.h"
#include "Protect.h"
#include "Util.h"
#include "WindowTime.h"

int GoldenArcherMaterialCount[2] = {0,0};
bool GoldenArcherButtonStatus[2] = {false,false};
DWORD TickCount = GetTickCount();

void InitGoldenArcher()
{
	if(gProtect.m_MainInfo.GoldenArcherRenewalSwitch == 0)
	{
		return;
	}

	SetCompleteHook(0xE9,0x004F46A0,&DrawGoldenArcher);
	SetCompleteHook(0xE9,0x004E7AC0,&ControlGoldenArcher);
}

void DrawGoldenArcher()
{
	if(EventChipDialogEnable)
	{
		if(GetTickCount() >= TickCount)
		{
			GoldenArcherButtonStatus[0] = (GoldenArcherMaterialCount[0] >= 5);
			GoldenArcherButtonStatus[1] = (GoldenArcherMaterialCount[1] >= 2);
		}

		RenderBitmap(260, WINDOW_POSX, WINDOW_POSY, 190.0f, 256.0f, 0.0f, 0.0f, 0.7421875f, 1, 1, 1);
		RenderBitmap(261, WINDOW_POSX, WINDOW_POSY + 256, 190.0f, 177.0f, 0.0f, 0.0f, 0.7421875f, 0.69140625, 1, 1);
		RenderBitmap(280, CLOSE_BT_POSX, CLOSE_BT_POSY, 24.0f, 24.0f, 0.0f, 0.0f, 24.0f / 32.0f, 24.0f / 32.0f, 1, 1);

		WindowRenderText(WINDOW_POSX + 95, 15, g_hFontBold, 1, 0, gCustomMessage.GetMessage(42));
		WindowRenderText(WINDOW_POSX + 95, WINDOW_POSY + 47, g_hFont, 1, 0, gCustomMessage.GetMessage(43));
		WindowRenderText(WINDOW_POSX + 95, WINDOW_POSY + 59, g_hFont, 1, 0, gCustomMessage.GetMessage(44));

		for(int n = 0; n < 2; n++)
		{
			if(!GoldenArcherButtonStatus[n])
			{
				glColor3f(0.4f, 0.4f, 0.4f);
			}

			RenderBitmap(240, WINDOW_POSX + 35.0f, WINDOW_POSY + 82.0f + (float)(n * 42), 120.0f, 24.0f, 0, 0, 0.83203125, 1.0, 1, 1);
			WindowRenderText(WINDOW_POSX + 95, WINDOW_POSY + 94 + (n * 42), g_hFont, 1, 0, gCustomMessage.GetMessage(45+n));
			glColor3f(1.f, 1.f, 1.f);
		}

		WindowRenderText(WINDOW_POSX + 95, WINDOW_POSY + 190, g_hFontBold, 1, 0, gCustomMessage.GetMessage(47), GoldenArcherMaterialCount[0]);
		WindowRenderText(WINDOW_POSX + 95, WINDOW_POSY + 208, g_hFontBold, 1, 0, gCustomMessage.GetMessage(48), GoldenArcherMaterialCount[1]);

		if(pMouseOnZone(CLOSE_BT_POSX, CLOSE_BT_POSY, 24, 24, 1))
		{
			pRenderTipText(CLOSE_BT_POSX + 2, CLOSE_BT_POSY-13, gCustomMessage.GetMessage(39));
		}
	}
}

void ControlGoldenArcher()
{
	if(EventChipDialogEnable == 0)
	{
		return;
	}

	if(pMouseOnZone(WINDOW_POSX, WINDOW_POSY, 190, 433, 1))
	{
		MouseOnWindow = true;

		for(int n = 0; n < 2; n++)
		{
			if(pMouseOnZone(WINDOW_POSX + 35, WINDOW_POSY + 82 + (n * 42), 120, 24, 1) && MouseLButtonPush && GoldenArcherButtonStatus[n])
			{
				PMSG_GOLDEN_ARCHER_REWARD_SEND pMsg;

				pMsg.header.set(0x96,sizeof(pMsg));
				pMsg.type = n;
				DataSend((BYTE*)&pMsg,pMsg.header.size);

				GoldenArcherButtonStatus[n] = false;
				GoldenArcherButtonPush();
				return;
			}
		}

		if(pMouseOnZone(CLOSE_BT_POSX, CLOSE_BT_POSY, 24, 24, 1) && MouseLButtonPush)
		{
			GoldenArcherButtonPush();
			EventChipDialogEnable = 0;

			PBMSG_HEAD pMsg;
			pMsg.set(0x97,sizeof(pMsg));
			DataSend((BYTE*)&pMsg,pMsg.size);
		}
	}
}

void GoldenArcherButtonPush()
{
	TickCount = GetTickCount() + 100;
	MouseLButtonPush = 0;
	MouseUpdateTime = 0;
	MouseUpdateTimeMax = 6;
	PlayBuffer(25, 0, 0);
}

void GoldenArcherMaterialCountRecv(PMSG_GOLDEN_ARCHER_COUNT_RECV* lpMsg)
{
	EventChipDialogEnable = 1;
	GoldenArcherMaterialCount[0] = (int)lpMsg->material[0];
	GoldenArcherMaterialCount[1] = (int)lpMsg->material[1];
}
