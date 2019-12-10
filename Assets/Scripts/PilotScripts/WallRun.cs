using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRun : MonoBehaviour
{
    Ray rayR;
    Ray rayL;
    public GameObject Titian;
    private RaycastHit hitR;
    private RaycastHit hitL;
    private bool pausemenuflag = false;
    private CharacterController cc;
    private FirstPersonController fpc;
    private Rigidbody rb;
    
   
    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectOfType<CharacterController>();
        rb = FindObjectOfType<Rigidbody>();
        fpc = FindObjectOfType<FirstPersonController>();

    }

   

    // Update is called once per frame
    void Update()
    {

     
        ////Escape pause menu
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (pausemenuflag == false)
        //    {
        //        fpc.m_MouseLook.setSentivity(0f, 0f);
        //        pausemenuflag = true;
        //        pausemenu.SetActive(true);
        //        Time.timeScale = 0.0f;
        //    }
        //    else
        //    {
        //        resume();
        //    }
        //}
        //WallRun
        if (Input.GetKey(KeyCode.LeftShift) && !cc.isGrounded)
        {
            rayL.origin = transform.position;
            rayL.direction = Vector3.left;
            rayR.origin = transform.position;
            rayR.direction = Vector3.right;
          
            if (Physics.Raycast(rayR, out hitR))
            {
                if (hitR.transform.CompareTag("Wall"))
                {
                    Debug.Log("Right");
                    rb.useGravity = false;
                    fpc.setGravity(0.5f);
                    StartCoroutine(afterRun());
                }
               
            }

            if (Physics.Raycast(rayL, out hitL))
            {
                if (hitL.transform.tag == "Wall")
                {
                    Debug.Log("Left");
                    fpc.setGravity(0.5f);
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                }
            }

            
        }
        
    }

   //public void resume()
   // {
   //     fpc.m_MouseLook.setSentivity(2f, 2f);
   //     pausemenuflag = false;
   //     Time.timeScale = 1.0f;
   //     pausemenu.SetActive(false);
   // }


    IEnumerator afterRun(){
        yield return new WaitForSeconds(2f);
        rb.useGravity = true;
        fpc.setGravity(2f);
    }
}
