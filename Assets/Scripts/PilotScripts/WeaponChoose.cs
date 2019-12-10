using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponChoose : MonoBehaviour
{
    public static WeaponChoose Instance;
    public bool isGun=false;
    public bool isSnipper=false;
    public bool isAssault=false;
    public bool isRocket=false;
    public bool isGrenade=false;
    public bool isLegion = false;
    public bool isIon = false;
    private int primaryWeaponcounter=0;
    private int heavyWeapon = 0;
    private int choosenTitan=0;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = null;
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void chooseGun()
    {
        if (primaryWeaponcounter<1)
        {
            isGun = true;
            primaryWeaponcounter++;
        }
        
    }

    public void chooseSnipper()
    {
        if (primaryWeaponcounter < 1)
        {
            isSnipper = true;
            primaryWeaponcounter++;
        }
        
    }

    public void chooseAssault()
    {
        if (primaryWeaponcounter < 1)
        {
            isAssault = true;
            primaryWeaponcounter++;
        }
       
    }

    public void chooseRocket()
    {
        if (heavyWeapon < 1)
        {
            isRocket = true;
            heavyWeapon++;
        }
        
    }

    public void chooseGrenade()
    {
        if(heavyWeapon < 1)
        {
            isGrenade = true;
            heavyWeapon++;
        }
        
    }

    public void play()
    {
       if(primaryWeaponcounter==1 && heavyWeapon == 1 && choosenTitan==1)
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        
    }

    public void chooseTitanIon()
    {
        if (choosenTitan < 1)
        {
            isIon=true;
            choosenTitan++;
        }
    }

    public void chooseLegion()
    {
        if (choosenTitan<1)
        {
            isLegion=true;
            choosenTitan++;
        }
    }

    public bool[] getData()
    {
        bool[] res = new bool[7];
        res[0] = isSnipper;
        res[1] = isAssault;
        res[2] = isGun;
        res[3] = isRocket;
        res[4] = isGrenade;
        res[5] = isIon;
        res[6] = isLegion;
        return res;
    }
}
