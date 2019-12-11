using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitanHealth : MonoBehaviour
{
    //Titan Health Meter
    public Image ImageHealth;
    public Text TxtHeath;
    private int CurrentHealth;
    private int min = 0;
    private int max = 400;
    private float perecentage;
    public bool isdestroyed = false;

    //Titan Dash Meter text and image 
    public Image DashImg;
    public Text TxtDash;
    private int Maxdashamount = 3;

    

    // Start is called before the first frame update
    void Start()
    {
        setHealth(400);
    }

    //Set the player health
    public void setHealth(int health)
    {
        if (health != CurrentHealth)
        {
            CurrentHealth = health;
            if (CurrentHealth > 0 && CurrentHealth <= 100)
            {
                perecentage = (float)CurrentHealth / (float)(max - min);
                TxtHeath.text = string.Format("{0}", Mathf.RoundToInt(perecentage * 100) + "%");
                ImageHealth.fillAmount = perecentage;
            }
            else
            {
                if (CurrentHealth <= 0)
                {
                    isdestroyed = true;
                }
            }

        }
    }

    public void setDash(int decreaseAmount)
    {
        if (decreaseAmount - decreaseAmount < 0)
        {
            TxtDash.text = string.Format("{0}", Mathf.RoundToInt(0 * 100) + "%");
            DashImg.fillAmount = 0;
        }
        else
        {
            TxtDash.text = string.Format("{0}", Mathf.RoundToInt((decreaseAmount - decreaseAmount) * 100) + "%");
            DashImg.fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
