using System;
using UnityEngine;

public class ResponsiveLight : MonoBehaviour, ILightInteractable
{
    private Light lightComponent;
    public float maxIntensity = 2f;
    
    private void Start()
    {
        lightComponent = GetComponent<Light>();
        lightComponent.intensity = 0;
    }

    public void OnLightHit(Vector3 hitPoint, Vector3 hitNormal)
    {
        if (lightComponent.intensity == 0)
            lightComponent.intensity = maxIntensity;
        else lightComponent.intensity = 0;
    }

    public void OnLightStay(Vector3 hitPoint, Vector3 hitNormal)
    {
        
    }

    public void OnLightExit()
    {
        
    }
}