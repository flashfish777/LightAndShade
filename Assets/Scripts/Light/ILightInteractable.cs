using UnityEngine;

/// <summary>
/// 光线交互接口
/// </summary>
public interface ILightInteractable
{
    void OnLightHit(Vector3 hitPoint, Vector3 hitNormal);
    void OnLightStay(Vector3 hitPoint, Vector3 hitNormal);
    void OnLightExit();
}