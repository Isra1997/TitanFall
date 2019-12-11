using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public int damage = 70;
    public string firingMode = "single shot";
    public int fireRate = 3;
    public int ammoCount = 12;
    public int range = 4;
    public float nextTimeToFire = 0f;

    public int count;

    public PilotHealth ph;
    // --------------------------------------

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 6;
            ph.setAmmo(6, ammoCount);
        }
        if (Input.GetMouseButtonDown(0) && firingMode == "single shot")
        {
            if (ammoCount > 0)
            {
                count = fireRate;
                while (count > 0)
                {
                    shoot();
                    count--;
                }
            }
        }
    }

    public void setAmmo()
    {
        ph.setAmmo(12, ammoCount);
    }

    void shoot()
    {
        muzzleFlash.Play();
        ammoCount -= 1;
        ph.setAmmo(12, ammoCount);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("EnemyTitan"))
            {
                hit.transform.gameObject.GetComponent<EnemyTitan>().takeDamage(70);
                ph.setTitanfall(100, 50);
            }
            if (hit.transform.CompareTag("EnemyPilot"))
            {
                hit.transform.gameObject.GetComponent<EnemyPilot>().takeDamage(70);
                ph.setTitanfall(100, 10);
            }
        }
    }
}
