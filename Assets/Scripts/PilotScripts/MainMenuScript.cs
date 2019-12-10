using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject WeaponMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        WeaponMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void creditsMenu()
    {
        gameObject.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


