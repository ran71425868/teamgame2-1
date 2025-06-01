using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newStage1_2 : MonoBehaviour
{
    [SerializeField] private int stagenum;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (stagenum)
            {
              case 0:
                    SceneManager.LoadScene("Stage2");
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