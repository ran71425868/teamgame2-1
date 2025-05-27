using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class StageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public int stageselect = 0;

    public void ClickstartButton()
    {
        switch (stageselect)
        {
            case 0:
                SceneManager.LoadScene("Stage_1");
                break;

            case 1:
               
                SceneManager.LoadScene("Stage_2");
                break;
            case 2:
                
                SceneManager.LoadScene("Title");
                break;

        }

        

    }
}