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

    public override void Show()
    {
        base.Show();
        Time.timeScale = 0;
        OpenEffect();
    }

    public override void Hide()
    {
        Time.timeScale = 1;
        UIManager.Instance.GetUI<SettingsUI>("SettingsUI")?.Hide();
        CloseEffect(base.Hide);
    }

    public override void Close()
    {
        Time.timeScale = 1;
        UIManager.Instance.GetUI<SettingsUI>("SettingsUI")?.Close();
        CloseEffect(base.Close);
    }

    private void onContinueBtn(GameObject @object, PointerEventData data)
    {
        Hide();
    }

    private void onSettingsBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    }

    private void onBackBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
        LevelManager.Instance.DeleteLevelBG("StartBG");
    }
}
