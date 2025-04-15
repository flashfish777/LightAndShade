using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 光线事件分发器
/// </summary>
public class LightRayEventDispatcher : MonoBehaviour
{
    private Dictionary<GameObject, ILightInteractable> interactableCache = new Dictionary<GameObject, ILightInteractable>();
    private HashSet<ILightInteractable> currentInteractions = new HashSet<ILightInteractable>();

    void OnEnable()
    {
        LightController.onLightRayHit += HandleLightRayHit;
    }

    void OnDisable()
    {
        LightController.onLightRayHit -= HandleLightRayHit;
    }

    void Update()
    {
        // 处理持续照射逻辑
        foreach (var interactable in currentInteractions)
        {
            // 这里可以添加获取当前命中点的逻辑
            interactable.OnLightStay(Vector3.zero, Vector3.zero);
        }
    }

    void HandleLightRayHit(GameObject hitObject, Vector3 hitPoint, Vector3 hitNormal)
    {
        ILightInteractable interactable = GetInteractable(hitObject);
        if (interactable != null)
        {
            interactable.OnLightHit(hitPoint, hitNormal);
            currentInteractions.Add(interactable);
        }
    }

    ILightInteractable GetInteractable(GameObject obj)
    {
        if (!interactableCache.TryGetValue(obj, out var interactable))
        {
            interactable = obj.GetComponent<ILightInteractable>();
            interactableCache[obj] = interactable;
        }
        return interactable;
    }

    // 在光线消失时调用
    public void ClearCurrentInteractions()
    {
        foreach (var interactable in currentInteractions)
        {
            interactable.OnLightExit();
        }
        currentInteractions.Clear();
    }
}