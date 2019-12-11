using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float weaponForce;
    public PilotHealth ph;
    private bool shooted = false;
    private int count = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            count = 100;
            ph.setAmmo(100, count);
            shooted = false;
        }

        if (Input.GetMouseButtonDown(0) && shooted == false)
        {
            ShootGrenade();
            shooted = true;
        }
    }
    public void setAmmo()
    {
        ph.setAmmo(100, count);
    }

    void ShootGrenade()
    {
        count = 0;
        ph.setAmmo(100, count);
        GameObject grenade = Instantiate(grenadePrefab, transform.TransformPoint(0, 0.1f, 0.05f), transform.rotation);
        //grenade.transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
        Debug.Log(grenade.transform.position);
        Debug.Log(transform.rotation);
        grenade.GetComponent<Rigidbody>().useGravity = true;
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * weaponForce, ForceMode.Impulse);
        //destroy grenade if touched enemy, otherwise destroy grenade after specific time
        Destroy(grenade, 3);
    }
}
