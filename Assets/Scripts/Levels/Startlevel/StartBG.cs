using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 教程关卡
/// </summary>
public class StartBG : LevelBase
{
    // private Transform mirror;
    // private Transform light1;
    // private Transform light2;
    // private Transform light3;
    private Transform door;
    private Transform gas;

    private void Awake()
    {
        // light1 = transform.Find("light/light1");
        // light2 = transform.Find("light/light2");
        // light3 = transform.Find("light/light3");
        door = transform.Find("door");
        // gas = transform.Find("gas");
        // mirror = transform.Find("mirror");
    }
}
