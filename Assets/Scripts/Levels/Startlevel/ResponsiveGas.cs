using UnityEngine;

public class ResponsiveGas : MonoBehaviour, ILightInteractable
{
    public float refractionIndex = 1.5f; // 折射率
    public float density = 0.5f; // 气体密度
    
    public Vector3 CalculateRefraction(Vector3 incomingDir, Vector3 hitNormal)
    {
        // 斯涅尔定律计算折射方向
        float ratio = 1.0f / refractionIndex;
        float cosI = Mathf.Clamp(Vector3.Dot(hitNormal, incomingDir), -1.0f, 1.0f);
        float sinT2 = ratio * ratio * (1.0f - cosI * cosI);
        
        if (sinT2 > 1.0f) return Vector3.zero; // 全反射
        
        float cosT = Mathf.Sqrt(1.0f - sinT2);
        return ratio * incomingDir + (ratio * cosI - cosT) * hitNormal;
    }
    
    public void OnLightHit(Vector3 hitPoint, Vector3 hitNormal)
    {
        // 可以在这里添加气体被光线照射时的特效
    }

    public void OnLightStay(Vector3 hitPoint, Vector3 hitNormal)
    {
        
    }

    public void OnLightExit()
    {
        
    }
}