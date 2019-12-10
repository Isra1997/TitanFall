using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assaultRifle : MonoBehaviour
{
    public int damage = 10;
    public string firingMode = "automatic";
    public int fireRate = 10;
    public int ammoCount = 35;
    public int range = 65;

    private float nextTimeToFire = 0f;


    // --------------------------------------

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public PilotHealth ph;

    void Start()
    {
       
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 35;
            ph.setAmmo(35, ammoCount);
        }
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && firingMode == "automatic")
        {
            if (ammoCount > 0)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }
    public void setAmmo()
    {
        ph.setAmmo(35, ammoCount);
    }
    void shoot()
    {

        muzzleFlash.Play();
        ammoCount -= 1;
        ph.setAmmo(35, ammoCount);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (hit.transform.CompareTag("EnemyTitan"))
                {
                    target.TakeDamage(damage, 50);
                }
                if (hit.transform.CompareTag("EnemyPilot"))
                {
                    target.gameObject.GetComponent<EnemyPilot>().takeDamage(10);
                    ph.setTitanfall(100, 10);
                }
            }
        }
    }

}


    
