using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamestart : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickstartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
