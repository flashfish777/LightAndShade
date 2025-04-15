using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡管理器
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    private List<LevelBase> levelList; // 存储加载过的背景的集合

    private void Awake()
    {
        Instance = this;
        levelList = new List<LevelBase>();
    }

    // 显示关卡BG
    public void ShowLevelBG<T>(string bgName) where T : LevelBase
    {
        LevelBase bg = Find(bgName);
        if (bg == null)
        {
            GameObject obj = Instantiate(Resources.Load("BG/" + bgName)) as GameObject;
        
            obj.name = bgName;
        
            bg = obj.AddComponent<T>();
        
            levelList.Add(obj.GetComponent<T>());
        }
        
        bg.Show();
    }
    
    //隐藏关卡BG
    public void HideLevelBG(string BGName)
    {
        LevelBase bg = Find(BGName);
        if (bg != null)
        {
            bg.Hide();
        }
    }

    // 删除关卡BG
    public void DeleteLevelBG(string BGName)
    {
        LevelBase bg = Find(BGName);
        if (bg != null)
        {
            levelList.Remove(bg);
            Destroy(bg.gameObject);
        }
    }
    
    // 寻找关卡BG
    public LevelBase Find(string BGName)
    {
        foreach (var t in levelList)
        {
            if (t.name == BGName)
                return t;
        }

        return null;
    }
}
