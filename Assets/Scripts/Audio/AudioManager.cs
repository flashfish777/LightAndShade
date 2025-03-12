using UnityEngine;
using System;

/// <summary>
/// 音频管理器
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmSource; // 播放bgm的音频
    private AudioSource effectSource; // 播放音效的音频
    // 其他音频

    public float bgmValue; // bgm的音量
    public float effectValue; // 音效的音量
    // 其他音频音量

    private void Awake()
    {
        Instance = this;
    }

    // 初始化
    public void Init()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();
        // ...

        //TODO: 可能从存档中调取音量
    }

    // 播放bgm
    public void PlayBGM(string name, bool isLoop = true)
    {
        // 加载bgm声音剪辑
        AudioClip clip = Resources.Load<AudioClip>("Sounds/BGM/" + name);

        bgmSource.clip = clip; // 设置音频
        bgmSource.loop = isLoop; // 循环
        bgmSource.volume = bgmValue; // 音量
        bgmSource.Play();
    }

    // 播放音效
    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/Effect/" + name);

        effectSource.clip = clip; // 设置音频
        effectSource.loop = false; // 不循环
        effectSource.volume = effectValue; // 音量
        effectSource.Play();
    }

    // 播放时刷新音量
    public void UpdateVolume()
    {
        bgmSource.volume = bgmValue;
        effectSource.volume = effectValue;
    }
}
