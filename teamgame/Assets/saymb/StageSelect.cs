using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class StageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int stageselect;

    [Header("効果音設定")]
    [SerializeField] private AudioClip clickSE;       // 効果音（インスペクターで設定）
    private AudioSource audioSource;                  // AudioSource（実行時に取得）

    private int timer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSourceがアタッチされていなければ自動で追加
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        timer++;
        Debug.Log(timer%100);
    }
    public void ClickstartButton()
    {
        switch (stageselect)
        {
            case 0:
                SceneManager.LoadScene("Stage1_1");
                PlaySE(); // 効果音を再生
                break;

            case 1:
                SceneManager.LoadScene("Stage_2");
                PlaySE(); // 効果音を再生
                break;
            case 2:
                SceneManager.LoadScene("Stage_3");
                PlaySE(); // 効果音を再生
                break;

            case 3:
                PlaySE(); // 効果音を再生
                if(timer%100>20)
                SceneManager.LoadScene("Tutorial");
                break;

        }
    }
    private void PlaySE()
    {
        if (clickSE != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSE);
        }
    }
}