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

    private void onCloseBtn(GameObject @object, PointerEventData data)
    {
        Close();
    }
}
