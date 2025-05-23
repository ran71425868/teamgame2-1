using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // タッチまたはクリックを検知
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Title");
        }
    }
}
