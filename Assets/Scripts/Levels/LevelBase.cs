using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour
{
    // 显示
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    // 隐藏
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    // 关闭（销毁）
    public virtual void Close()
    {
        LevelManager.Instance.DeleteLevelBG(gameObject.name);
    }
}
