﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour
{
    public GameObject explosionEffect;
    private float grenadeRadius = 4f;
    private Collider[] shootedEnemies;
    private GameObject instantiatedObj;
    public LayerMask explosionLayers;
    public PilotHealth ph;

    void OnCollisionEnter(Collision collision)
    {
        Explosion(collision.contacts[0].point);

    }

    void Explosion(Vector3 centerPoint)
    {
        shootedEnemies = Physics.OverlapSphere(centerPoint, grenadeRadius, explosionLayers);
        foreach (Collider shootedEnemy in shootedEnemies)
        {
            Debug.Log(shootedEnemy.gameObject.name);
            instantiatedObj = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(instantiatedObj, 3f);
            if (shootedEnemy.gameObject.tag == "EnemyTitan")
            {
                shootedEnemy.gameObject.GetComponent<EnemyTitan>().takeDamage(125);
                ph.setTitanfall(100, 50);
            }

            if (shootedEnemy.gameObject.tag == "EnemyPilot")
            {
                //target.TakeDamage(125, 10);
                shootedEnemy.gameObject.GetComponent<EnemyPilot>().takeDamage(125);
                ph.setTitanfall(100, 10);
            }
            Destroy(gameObject);
        }


    }
}
