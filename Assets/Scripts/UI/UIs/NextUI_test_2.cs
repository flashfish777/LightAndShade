using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 测试
/// </summary>
public class NextUI_test_2 : UIBase
{
    private void Awake()
    {
        // next
        Register("next").onClick = onNextBtn;
        // 返回
        Register("back").onClick = onBackBtn;
        // ...
    }

    private void onBackBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<NextUI_test_1>("NextUI_test_1");

        Close();
    }

    private void onNextBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowTip("no", Color.red);
    }
}
