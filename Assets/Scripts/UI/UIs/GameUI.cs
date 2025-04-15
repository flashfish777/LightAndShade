using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 游戏UI
/// </summary>
public class GameUI : UIBase
{
    private void Awake()
    {
        // 暂停
        Register("pause").onClick = onPauseBtn;
        // 背包
        Register("bag").onClick = onBagBtn;
        // 历史对话（或者一并放到暂停里）
        Register("dialogs").onClick = onDialogsBtn;
        // 交互按钮
        Register("event").onClick = onEventBtn;
    }

    private void onDialogsBtn(GameObject arg1, PointerEventData arg2)
    {
        // 查看历史对话
    }

    private void onBagBtn(GameObject arg1, PointerEventData arg2)
    {
        // 打开背包
    }

    private void onPauseBtn(GameObject arg1, PointerEventData arg2)
    {
        UIManager.Instance.ShowUI<PauseUI>("PauseUI");
    }

    private void onEventBtn(GameObject arg1, PointerEventData arg2)
    {
        HideIncludeUI("event");
    }

    private void Update()
    {
        CheckESC();
    }
    
    private void CheckESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI ui = UIManager.Instance.GetUI<PauseUI>("PauseUI");
            bool pause = ui?.gameObject.activeSelf ?? false;
            if (!pause)
                UIManager.Instance.ShowUI<PauseUI>("PauseUI");
            else
                ui.Hide();
        }
    }
}
