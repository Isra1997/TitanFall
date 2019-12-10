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
    private RocketLauncher rl;
    private LegionWeapon lw;
    private IonScript ion;
    private bool[] ChoosenWeapons;


    // Start is called before the first frame update
    void Start()
    {

        ChoosenWeapons = GameObject.Find("ChoosenWeapons").GetComponent<WeaponChoose>().getData();
        //SnipperRiffel
        if (ChoosenWeapons[0])
        {
            sr = transform.GetChild(0).GetComponent<sniperRifle>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
        }

        //AssultRiffel
        if (ChoosenWeapons[1])
        {
            ar = transform.GetChild(1).GetComponent<assaultRifle>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(1).gameObject);
        }

        //Shotgun
        if (ChoosenWeapons[2])
        {
            sg = transform.GetChild(2).GetComponent<shotgun>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(2).gameObject);
        }

        //RocketLauncher
        if (ChoosenWeapons[3])
        {
            rl = GetComponent<Transform>().GetChild(3).GetComponent<RocketLauncher>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(3).gameObject);
        }

        //weapon Titan Legon
        if (ChoosenWeapons[4])
        {
            lw = GetComponent<Transform>().GetChild(4).GetComponent<LegionWeapon>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(4).gameObject);
        }

        //weapon Titan Ion
        if (ChoosenWeapons[5])
        {
            ion = GetComponent<Transform>().GetChild(5).GetComponent<IonScript>();
        }
        else
        {
            Destroy(GetComponent<Transform>().GetChild(5).gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 1)
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
                if (w.gameObject.name == "RPG7")
                {
                    rl.setAmmo();
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


