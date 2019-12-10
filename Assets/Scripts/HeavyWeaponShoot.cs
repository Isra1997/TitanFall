using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeaponShoot : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject grenadePrefab;
    public float weaponForce;
    public bool rocketLauncher;
    public bool grenadeLauncher;

    // Update is called once per frame
    void Update()
    {
        //set triger here
        if (Input.GetButtonDown("Fire1"))
        {
            if (rocketLauncher)
            {
                ShootRocket();
            }
            else if (grenadeLauncher)
            {
                ShootGrenade();
            }
            
        }
    }

   void ShootRocket()
    {

        GameObject rocket = Instantiate(rocketPrefab, transform.TransformPoint(0, 0, 1f), transform.rotation);
        rocket.GetComponent<Rigidbody>().useGravity = false;
        rocket.GetComponent<Rigidbody>().AddForce(transform.forward * weaponForce, ForceMode.Impulse);
        //destroy grenade if touched enemy, otherwise destroy grenade after specific time
        Destroy(rocket, 3);
    }

    void ShootGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.TransformPoint(0, 0, 1f), transform.rotation);
        grenade.GetComponent<Rigidbody>().useGravity = true;
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * weaponForce, ForceMode.Impulse);
        //destroy grenade if touched enemy, otherwise destroy grenade after specific time
        Destroy(grenade, 3);
    }
}
