using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Select1 : MonoBehaviour
{
    // Start is called before the first frame update
    private int stageselect = 0;

    public void ClickstartButton()
    {
        SceneManager.LoadScene("Stage_1");

    }
}