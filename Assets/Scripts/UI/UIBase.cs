using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// UI基类
/// </summary>
public class UIBase : MonoBehaviour
{
    // 注册事件
    public UIEventTrigger Register(string name)
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }

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
        UIManager.Instance.CloseUI(gameObject.name);
    }
    
    // 隐藏子UI
    public void HideIncludeUI(string uiName)
    {
        Transform tf = transform.Find(uiName);
        tf.gameObject.SetActive(false);
    }
    
    // 显示子UI
    public void ShowIncludeUI(string uiName)
    {
        Transform tf = transform.Find(uiName);
        tf.gameObject.SetActive(true);
    }

    // 打开动画
    public void OpenEffect()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).SetUpdate(true);
    }

    // 关闭动画
    public void CloseEffect(Action callback)
    { 
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            callback?.Invoke();
        }).SetUpdate(true);
    }
}
