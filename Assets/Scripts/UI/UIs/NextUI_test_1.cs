using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 测试
/// </summary>
public class NextUI_test_1 : UIBase
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
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        Close();
    }

    private void onNextBtn(GameObject @object, PointerEventData data)
    {
        UIManager.Instance.ShowUI<NextUI_test_2>("NextUI_test_2");

        Close();
    }
}
