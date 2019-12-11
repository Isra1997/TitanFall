using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class TitanScript : MonoBehaviour
{
    //Disenabling scripts
    private FirstPersonController fpc;
    private CharacterController cc;
    private Crouch crouch;
    private WallRun wallrun;

    //Titian embark variables
    private float original_height;
    private float Titan_height = 3;
    private bool isdeployed = false;
    bool inTitan = false;
    private bool inrange;

    //GameObjects needed
    public PilotHealth ph;
    public GameObject PilotHelth;

    public GameObject Titan;
    public GameObject TitanHealth;
    public TitanHealth th;
    
    

    void Start()
    {
        fpc = this.gameObject.GetComponent<FirstPersonController>();
        crouch = this.gameObject.GetComponent<Crouch>();
        cc = this.gameObject.GetComponent<CharacterController>();
        wallrun = this.gameObject.GetComponent<WallRun>();
        original_height = cc.height;
    }

   


    // Update is called once per frame
    void Update(){
        //Start the dodging
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A))
        {
            Debug.Log("dodge the A");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            Debug.Log("dodge the S");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            Debug.Log("dodge the D");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            Debug.Log("dodge the W");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("dodge the down");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("dodge the up");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("dodge the left");
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("dodge the right");
        }
        //End the dodging
        //Check if titan died
        if (th.isdestroyed)
        {
            Disembark();
        }
        //Disabling the jump
        if (Input.GetKeyDown(KeyCode.Space) && inTitan)
        {
            fpc.m_Jump = false;
        }

        //Deploying the Titan
        if (ph.getTitanfallMeter() == 100)
        {
            Titan.SetActive(true);
            Titan.GetComponent<Animator>().Play("Titianall");
        }

        //Titan embark and disembark
        if (Input.GetKeyDown(KeyCode.E) && inrange)
        {
            if (isdeployed)
            {
                Debug.Log("Disembarking");
                Disembark();
            }
            else
            {
                Debug.Log("Embarking");
                embarking();
                inTitan = true;
            }
            
        }
    

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        inrange = true;
    }

    void embarking()
    {
        //Disabling Weapon switching,Crouch,pilothealth and wallrun
        transform.GetChild(0).GetChild(0).GetComponent<weaponSwitching>().enabled = false;
        ph.enabled = false;
        crouch.enabled = false;
        wallrun.enabled = false;
        //Enabling Titan Weapon
        transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        //Resting titanFall meter
        ph.resetTitanfall();
        cc.height = Titan_height;
        Titan.SetActive(false);
        //Disabling Pilot health
        PilotHelth.SetActive(false);
        //Enabling Titan health
        TitanHealth.SetActive(true);
        isdeployed = true;
    }


    void Disembark()
    {

        transform.GetChild(0).GetChild(0).GetComponent<weaponSwitching>().enabled = true;
        transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        cc.height = original_height;
        fpc.m_Jump = true;
        ph.enabled = true;
        crouch.enabled = true;
        wallrun.enabled = true;
        isdeployed = false;
        inrange = false;
        inTitan = false;
        PilotHelth.SetActive(true);
        TitanHealth.SetActive(false);
    }

   
}
