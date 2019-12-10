using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class TitanScript : MonoBehaviour
{
    // Start is called before the first frame update
    private FirstPersonController fpc;
    private CharacterController cc;
    private Crouch crouch;
    private WallRun wallrun;

    public int Health;
    public int DashMeter = 3;
    bool dash = false;
    int dashtime;
    bool invincible = false;
    bool isHitable = true;
    float RegenrateDashtime = 5.0f;
    int CoreAbilityMeter = 0;
    bool activeCoreAbility = false;

    //Titian embark variables

    private float original_height;
    private float Titan_height = 3;
    private bool isdeployed = false;
    public PilotHealth ph;
    public GameObject Titan;
    private bool inrange;

    void Start()
    {
        fpc= this.gameObject.GetComponent<FirstPersonController>();
        crouch = this.gameObject.GetComponent<Crouch>();
        cc= this.gameObject.GetComponent<CharacterController>();
        wallrun= this.gameObject.GetComponent<WallRun>();
        original_height = cc.height;
        ph.setHealth(400);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        inrange = true;
    }

    void embarking()
    {
        transform.GetChild(0).GetChild(0).GetComponent<weaponSwitching>().enabled = false;
        transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        ph.resetTitanfall();
        cc.height = Titan_height;   
        crouch.enabled = false;
        wallrun.enabled = false;
        Titan.SetActive(false);
        inrange = false;
    }



    // Update is called once per frame
    void Update()
        
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fpc.m_Jump = false;
        }
        //if (RegenrateDashtime != 0.0f && RegenrateDashtime < 5.0)
        //{
        //    RegenrateDashtime -= Time.deltaTime;
        //}
        //else {
        //    RegenrateDashtime = 5.0f;
        //}
       

        //if (DashMeter < 3&& DashMeter>0 && RegenrateDashtime==0.0f) {
            
        //   DashMeter += 1;
        //}

        //if(CrossPlatformInputManager.GetButtonDown("Jump"))
        //    {
        //    fpc.m_Jump = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Space)&& Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    if (DashMeter >= 1) {

        //        Dash(2);
        //    } 
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (DashMeter >= 1)
        //    {
        //        Dash(0);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (DashMeter >= 1)
        //    {
        //        Dash(1);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (DashMeter >= 1)
        //    {
        //        Dash(3);
        //    }
        //}

        if (ph.getTitanfallMeter() == 100 && !isdeployed)
        {
            isdeployed = true;
            Titan.SetActive(true);
            Titan.GetComponent<Animator>().Play("Titianall");
        }

        //TitanFall Meter
        if (Input.GetKeyDown(KeyCode.E)  && inrange && isdeployed)
        {
            Debug.Log("Embarking");
            embarking();
        }
        if (Input.GetKeyDown(KeyCode.E) && isdeployed && !inrange)
        {
            Debug.Log("Disembarking");
            Disembark();
        }

        /////Core Ability
        //if (Input.GetKeyDown(KeyCode.V) && CoreAbilityMeter == 100) {
        //    activeCoreAbility = true;
        //    CoreAbilityMeter = 0;
        //}

    }
    void Dash( int di) {
        invincible = true;
        isHitable = false;
        if (di == 0) { }
        if (di == 1) { }
        if (di == 2) { }
        if (di == 3) { }

    }

    void healthdamage() {
        
    }
    void Disembark()
    {
        
        transform.GetChild(0).GetChild(0).GetComponent<weaponSwitching>().enabled = true;
        transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
        original_height = cc.height;
        fpc.m_Jump = true;
        crouch.enabled = true;
        wallrun.enabled = true;
        isdeployed = false;
        inrange = false;
        //Destroy(Titan);
    }

    void Invincible() {
        
    }
    void coreAbility(string a) {
        if (CoreAbilityMeter < 100  && activeCoreAbility==false)
        {
            if (a.Equals("EnemyTitan"))
            {
                CoreAbilityMeter += 50;
            }
            if (a.Equals("EnemyPilot"))
            {
                CoreAbilityMeter += 10;
            }
        }
    }
}
