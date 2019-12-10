using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPilotSniper : MonoBehaviour
{
    const int sniperRange = 100000;
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

            muzzleFlash.Play();
            ph.setHealth(ph.GetHealth() - 5);
            StartCoroutine(attack());
        }
    }
    bool playerInScope()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("player");
        float diff = (player[0].transform.position - gameObject.transform.position).sqrMagnitude;
        return (diff <= sniperRange);
    }
    IEnumerator attack()
    {
        routineFinished = false;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        routineFinished = true;
    }
}
