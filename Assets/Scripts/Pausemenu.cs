using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pausemenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pausemenu;
    public GameObject ourPlayer;
    private GameObject ChoosenWeapons;

    void Start()
    {
        ChoosenWeapons = GameObject.Find("ChoosenWeapons");
    }
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                ourPlayer.GetComponent<FirstPersonController>().enabled = false;
                pausemenu.SetActive(true);
                isPaused = true;
            }
            else
            {
                Ourresume();
                isPaused = false;
            }
        }
    }


    public void Ourresume()
    {
        ourPlayer.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;    
        pausemenu.SetActive(false);
    }

    public void Restart()
    {
        ourPlayer.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void quitTomainMenu()
    {
        ourPlayer.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        Destroy(ChoosenWeapons);
        SceneManager.LoadScene(0);
    }
    
}


