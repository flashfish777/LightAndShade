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
        // ...
    }

    private void onStartGameBtn(GameObject obj, PointerEventData pData)
    {
        // 进入...
        UIManager.Instance.ShowUI<NextUI_test_1>("NextUI_test_1");

        // 关闭
        Close();

        // 测试
        // UIManager.Instance.ShowTip("nihao", Color.green);
        // UIManager.Instance.ShowDialogs("nihao0000");
    }
}
