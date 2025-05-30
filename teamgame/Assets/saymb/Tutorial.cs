using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public int Tutorialnum;
    public void ClickstartButton()
    {
        switch (Tutorialnum)
        {
            case 0:
                SceneManager.LoadScene("Tutorial_Menu");
                break;

            case 1:

                SceneManager.LoadScene("Tutorial_Camera");
                break;

            case 2:
                SceneManager.LoadScene("StageSelect");
                break;
        }
    }
}
