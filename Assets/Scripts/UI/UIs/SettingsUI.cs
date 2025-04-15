using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 设置UI
/// </summary>
public class SettingsUI : UIBase
{
    private void Awake()
    {
        Register("bg/close").onClick = onCloseBtn;
    }

    public override void Show()
    {
        base.Show();
        OpenEffect();
    }

    public override void Hide()
    {
        CloseEffect(base.Hide);
    }

    public override void Close()
    {
        CloseEffect(base.Close);
    }

    private void onCloseBtn(GameObject @object, PointerEventData data)
    {
        Hide();
    }
}
