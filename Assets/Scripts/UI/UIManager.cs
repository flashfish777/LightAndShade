using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

/// <summary>
/// UI管理器
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf; // 画布的变换组件
    private List<UIBase> uiList; // 存储加载过的界面的集合

    private void Awake()
    {
        Instance = this;
        // 找世界中的画布
        canvasTf = GameObject.Find("Canvas").transform;
        // 初始化集合
        uiList = new List<UIBase>();
    }

    // 显示UI
    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui == null)
        {
            // 集合中没有就需要从其他地方（如 Resources/UI 文件夹中）加载
            GameObject obj = Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;

            // 改名字
            obj.name = uiName;

            // 添加需要的脚本
            ui = obj.AddComponent<T>();

            // 添加到集合进行存储
            uiList.Add(ui);
        }
        else
        {
            // 显示
            ui.Show();
        }

        return ui;
    }

    // 隐藏UI
    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
    }

    // 关闭所有界面
    public void CloseAllUI()
    {
        for (int i = uiList.Count - 1; i >= 0; --i)
        {
            Destroy(uiList[i].gameObject);
        }

        uiList.Clear(); // 清空集合
    }

    // 关闭某个界面
    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    // 从集合中找到名字对应的界面脚本
    public UIBase Find(string uiName)
    {
        for (int i = 0; i < uiList.Count; ++i)
        {
            if (uiList[i].name == uiName)
                return uiList[i];
        }

        return null;
    }

    // 获得某个界面的脚本
    public T GetUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }

    // 提示界面
    public void ShowTip(string msg, Color color, System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        TMP_Text text = obj.transform.Find("bg/text").GetComponent<TMP_Text>();
        text.color = color;
        text.text = msg;
        
        // 动画
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        });
        Destroy(obj, 2);
    }

    // 对话框
    public void ShowDialogs(string msg)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Dialogs"), canvasTf) as GameObject;
        TMP_Text text = obj.transform.Find("bg/text").GetComponent<TMP_Text>();
        text.text = msg;

        // TODO: 可能需要对话框动画、文字动画等

        // TODO: 可能需要点击事件
    }
}
