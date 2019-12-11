using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPilotGun : MonoBehaviour
{
    const int gunRange = 40;
    public ParticleSystem muzzleFlash;
    public PilotHealth ph;
    bool routineFinished = true;


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInScope() && routineFinished)
        {
            //attack();

            //muzzleFlash.Play();
            //if (ph.enabled)
            //{
            //    ph.setHealth(ph.GetHealth() - 70);
            //}
            //else
            //{
            //    //affect titan
            //}

            //StartCoroutine(attack());
            this.gameObject.GetComponent<Animator>().SetBool("fire", true);
            transform.LookAt(GameObject.FindGameObjectsWithTag("player")[0].transform);
            muzzleFlash.Play();
            ph.setHealth(ph.GetHealth() - 70);
            StartCoroutine(attack());
        }
    }
    bool playerInScope()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("player");
        float diff = (player[0].transform.position - gameObject.transform.position).sqrMagnitude;
        return (diff <= gunRange);
    }
    IEnumerator attack()
    {
        routineFinished = false;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.GetComponent<Animator>().SetBool("fire", false);
        yield return new WaitForSeconds(10);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        routineFinished = true;
    }
}
