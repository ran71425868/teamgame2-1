using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newStage1_2 : MonoBehaviour
{
    [SerializeField] private int stagenum;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (stagenum)
            {
              case 0:
                    SceneManager.LoadScene("Stage_2");
                    break;

                case 1:
                    SceneManager.LoadScene("Stage_3");
                    break;

                case 2:
                    SceneManager.LoadScene("Result");
                    break;
            }

        }
    }
}