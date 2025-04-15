using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 开始UI
/// </summary>
public class LoginUI : UIBase
{
    private void Awake()
    {
        // 开始游戏
        Register("start").onClick = onStartGameBtn;
        // 继续游戏
        Register("continue").onClick = onContinueBtn;
        // 设置
        Register("settings").onClick = onSettingsBtn;
        // 退出游戏
        Register("quit").onClick = onQuitBtn;
    }

    private void onStartGameBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<GameUI>("GameUI");
        GameManager.Instance.ChangeLevel(Level.Start);
        Close();
    }

    private void onContinueBtn(GameObject @object, PointerEventData data)
    {
        Close();
    }

    private void onSettingsBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<SettingsUI>("SettingsUI");
    }

    private void onQuitBtn(GameObject @object, PointerEventData data)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
