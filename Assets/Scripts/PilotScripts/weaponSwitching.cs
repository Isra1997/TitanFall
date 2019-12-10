using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    public Text WeaponName;

    public Image ammo;
    public Text ammoTxt;

    private assaultRifle ar;
    private sniperRifle sr;
    private shotgun sg;



    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform w in transform)
        {
            if (w.gameObject.name == "SnipperRiffel")
            {
                sr = w.GetComponent<sniperRifle>();
            }
            if (w.gameObject.name == "AssultRiffel")
            {
                ar = w.GetComponent<assaultRifle>();
            }
            if (w.gameObject.name == "ShotGun")
            {
               sg = w.GetComponent<shotgun>();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 4)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
            selectWeapon();
        }
    }
    void selectWeapon()
    {
        int i = 0;
        foreach (Transform w in transform)
        {
            if (i == selectedWeapon)
            {
                w.gameObject.SetActive(true);
                WeaponName.text = w.gameObject.name;
                if (w.gameObject.name == "SnipperRiffel")
                {
                    sr.setAmmo();
                }
                if (w.gameObject.name == "AssultRiffel")
                {
                    ar.setAmmo();
                }
                if (w.gameObject.name == "ShotGun")
                {
                    sg.setAmmo();
                }
                
            }
            else
            {
                w.gameObject.SetActive(false);
            }
            i++;
        }
    }
}


