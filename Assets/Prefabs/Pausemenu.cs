using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pausemenu;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pause();
                isPaused = true;
            }
            else
            {
                Ourresume();
                isPaused = false;
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);

    }

    public void Ourresume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void quitTomainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}


