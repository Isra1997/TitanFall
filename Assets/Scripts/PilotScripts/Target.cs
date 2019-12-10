using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    public PilotHealth ph;

    public void TakeDamage(int Damageamount, int titanfall){
        health -= Damageamount;
        if (health<=0){
            Die(titanfall);
        }
    }

    void Die(int amount){
        ph.setTitanfall(100, amount);
        Destroy(this.gameObject);
    }
}
