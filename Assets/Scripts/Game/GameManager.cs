using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Start,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}

/// <summary>
/// 游戏状态管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Level level; // 关卡
    // 数据...                                                   
    
    void Awake()
    {
        Instance = this;
        level = Level.Start;
    }

    public void InitGame()
    {
        level = Level.Start;
        // 重置数据...
    }

    void Update()
    {
        
    }

    public void ChangeLevel(Level goLevel)
    {
        level = goLevel;
        
        switch (level)
        {
            case Level.Start:
                LevelManager.Instance.ShowLevelBG<StartBG>("StartBG");
                break;
            case Level.Level1:
                break;
            case Level.Level2:
                break;
            case Level.Level3:
                break;
            case Level.Level4:
                break;
            case Level.Level5:
                break;
            default:
                break;
        }
    }
}
