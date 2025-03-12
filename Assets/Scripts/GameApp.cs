using UnityEngine;
using System;

/// <summary>
/// 游戏入口
/// </summary>
public class GameApp : MonoBehaviour
{
    void Start()
    {
        // 初始化AudioManager
        AudioManager.Instance.Init();
        // ...

        // 显示LoginUI
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        // 播放bgm
        // AudioManager.Instance.PlayBGM("");
    }
}
