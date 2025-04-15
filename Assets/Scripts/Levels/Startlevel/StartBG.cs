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
    private Transform gas;

    private void Awake()
    {
        door = transform.Find("door");
    }
}
