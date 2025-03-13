using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 暂停UI（ESC）
/// </summary>
public class PauseUI : UIBase
{
    private void Awake()
    {
        // 继续游戏
        Register("bg/continue").onClick = onContinueBtn;
        // 设置
        Register("bg/settings").onClick = onSettingsBtn;
        // 退出至主菜单
        Register("bg/back").onClick = onBackBtn;
    }

    private void onContinueBtn(GameObject @object, PointerEventData data)
    {

        Close();
    }

    private void onSettingsBtn(GameObject @object, PointerEventData data)
    {

        UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    }

    private void onBackBtn(GameObject @object, PointerEventData data)
    {

        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
        BGManager.Instance.CloseBG("StartBG");

        Close();
    }
}
