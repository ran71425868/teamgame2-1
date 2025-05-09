using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel; 
    [SerializeField] private Button resumeButton;

    [SerializeField] private Button itemsButton;

    // Start is called before the first frame update
    private void Start()
    {
        pausePanel.SetActive(false);

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        pausePanel?.SetActive(false);
    }
}
