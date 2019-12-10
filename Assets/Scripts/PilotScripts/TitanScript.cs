using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class TitanScript : MonoBehaviour
{
    // Start is called before the first frame update
    private FirstPersonController firstPersonController;
    public int Health;
    public int DashMeter = 3;
    bool dash = false;
    int dashtime;
    bool invincible = false;
    bool isHitable = true;
    float RegenrateDashtime = 5.0f;
    
    void Start()
    {
        this.gameObject.GetComponent<Crouch>().enabled = false;
        this.gameObject.GetComponent<WallRun>().enabled = false;
        //this.gameObject.GetComponent<weaponSwitching>.enabled = false;
        firstPersonController = FindObjectOfType<FirstPersonController>();
        firstPersonController.isTitian = true;
        firstPersonController.m_Jump = false;
    }

    // Update is called once per frame
    void Update()
        
    {
        if (RegenrateDashtime != 0.0f && RegenrateDashtime < 5.0)
        {
            RegenrateDashtime -= Time.deltaTime;
        }
        else {
            RegenrateDashtime = 5.0f;
        }
       

        if (DashMeter < 3&& DashMeter>0 && RegenrateDashtime==0.0f) {
            
           DashMeter += 1;
        }

        if(CrossPlatformInputManager.GetButtonDown("Jump"))
            {
            firstPersonController.m_Jump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (DashMeter >= 1) {

                Dash(2);
            } 
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (DashMeter >= 1)
            {
                Dash(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (DashMeter >= 1)
            {
                Dash(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (DashMeter >= 1)
            {
                Dash(3);
            }
        }

    }
    void Dash( int di) {
        invincible = true;

    }

    void healthdamage() {
        
    }
    void Invincible() {
        
    }
}
