using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景管理器(测试)
/// </summary>
public class BGManager : MonoBehaviour
{
    public static BGManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // 显示BG
    public void ShowBG(string BGName)
    {
        GameObject obj = Instantiate(Resources.Load("BG/" + BGName)) as GameObject;
    }

    // 关闭某个BG
    public void CloseBG(string BGName)
    {
        GameObject bg = GameObject.Find(BGName + "(Clone)");
        if (bg != null)
            Destroy(bg);
    }
}
