using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickstartButton()
    {
        SceneManager.LoadScene("Stage_1");
    }
}