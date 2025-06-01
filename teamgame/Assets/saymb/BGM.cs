using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource bgmSource;

    [SerializeField] private AudioClip bgmClip;

    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
        }

        bgmSource.clip = bgmClip;
        bgmSource.loop = true; // ループ再生
        bgmSource.playOnAwake = false; // Startで再生するのでオフ
        bgmSource.volume = 0.5f; // 音量調整
        bgmSource.Play(); // 再生
    }
}
