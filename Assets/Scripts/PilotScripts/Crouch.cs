using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    private CharacterController cc;
    private bool m_Crouch=false;
    private bool inTitan = false;
    private float original_height;
    private float crouched_height = 0.5f;
    private float Titan_height = 5;
    private bool isdeployed = false;
    public PilotHealth ph;
    public GameObject Titan;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        original_height = cc.height;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (ph.getTitanfallMeter() == 100 && isdeployed)
        {
            inTitan = true;
            collision.gameObject.SetActive(false);
            embarking();
            ph.resetTitanfall();
            this.gameObject.GetComponent<TitanScript>().enabled = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_Crouch = !m_Crouch;
            checkCrouching();
        }

        if(m_Crouch && Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_Crouch = false;
            checkCrouching();
        }

        if (ph.getTitanfallMeter() == 100 && !isdeployed)
        {
            Titan.SetActive(true);
            Titan.GetComponent<Animator>().Play("Titianall");
        }

        //TitanFall Meter
        if (Input.GetKeyDown(KeyCode.E))
        {
            isdeployed = true;
            Debug.Log(isdeployed);
        }
    }

    void embarking()
    {
        if (!inTitan)
        {
            cc.height = original_height;
        }
        else
        {
            cc.height = Titan_height;
        }
    }

    void checkCrouching()
    {
        if (!m_Crouch)
        {
          cc.height = original_height;
        }
        else
        {
          cc.height = crouched_height;  
        }
    }
}
