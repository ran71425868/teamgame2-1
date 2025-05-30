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

    public void ClickstartButton()
    {
        switch (stageselect)
        {
            case 0:
                SceneManager.LoadScene("Stage1_1");
                break;

            case 1:
               
                SceneManager.LoadScene("Stage_2");
                break;
            case 2:
                
                SceneManager.LoadScene("Stage_3");
                break;

            case 3:

                SceneManager.LoadScene("Tutorial_Menu");
                break;

        }
    }

    
}