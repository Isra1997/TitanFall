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
        if (Input.GetKeyDown(KeyCode.Space) &&
            (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Debug.Log("dodge the bullet");
        }
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

        //TitanFall Meter
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
