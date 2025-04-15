using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 教程关卡
/// </summary>
public class StartBG : LevelBase
{
    private Transform door;
    private ResponsiveGas gas;
    private ResponsiveLight light1;
    private ResponsiveLight light2;
    private ResponsiveLight light3;
    
    private bool isPass;

    private void Awake()
    {
        door = transform.Find("door");
        light1 = transform.Find("light/light1").GetComponent<ResponsiveLight>();
        light2 = transform.Find("light/light2").GetComponent<ResponsiveLight>();
        light3 = transform.Find("light/light3").GetComponent<ResponsiveLight>();
        gas = transform.Find("gas").GetComponent<ResponsiveGas>();
        
        isPass = false;
    }

    private void Update()
    {
        CheckLights();
    }

    private void CheckLights()
    {
        if (light1.IsLightOn() && light2.IsLightOn() && light3.IsLightOn() && !isPass)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        isPass = true;
        UIManager.Instance.ShowTip("Door Open!", Color.green);
    }
}
