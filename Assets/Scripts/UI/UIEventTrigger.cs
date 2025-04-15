using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

/// <summary>
/// UI事件
/// </summary>
public class UIEventTrigger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Action<GameObject, PointerEventData> onClick; // 鼠标点击
    public Action<GameObject, PointerEventData> onEnter; // 鼠标进入
    public Action<GameObject, PointerEventData> onExit; // 鼠标离开

    public static UIEventTrigger Get(GameObject obj)
    {
        UIEventTrigger trigger = obj.GetComponent<UIEventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<UIEventTrigger>();
        }
        return trigger;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 缩小按钮
        transform.DOScale(new Vector3(1, 1, 1) * 0.9f, 0.1f)
            .OnComplete(() =>
            {
                // 恢复按钮大小
                transform.DOScale(new Vector3(1, 1, 1), 0.1f)
                    .OnComplete(() =>
                    {
                        // 执行事件
                        onClick?.Invoke(gameObject, eventData);
                    }).SetUpdate(true);
            }).SetUpdate(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter?.Invoke(gameObject, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit?.Invoke(gameObject, eventData);
    }
}
