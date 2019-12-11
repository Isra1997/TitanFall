using UnityEngine;
using System.Collections;

public class EnemyPilotRifle : MonoBehaviour
{
    const int rifleRange = 650;
    public ParticleSystem muzzleFlash;
    public PilotHealth ph;
    bool routineFinished = true;
    public TitanHealth th;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInScope() && routineFinished)
        {
            
            this.gameObject.GetComponent<Animator>().SetBool("fire", true);
            transform.LookAt(GameObject.FindGameObjectsWithTag("player")[0].transform);
            muzzleFlash.Play();
            //muzzleFlash.Play();
            if (ph.enabled)
            {
                ph.setHealth(ph.GetHealth() - 10);
                Debug.Log(ph.GetHealth());
            }
            else
            {
                Debug.Log("Titian activated");
                th.setHealth(th.GetHealth() - 10);
            }

            StartCoroutine(attack());
        }
    }
    bool playerInScope()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("player");
        float diff = (player[0].transform.position - gameObject.transform.position).sqrMagnitude;
        return (diff <= rifleRange);
    }
    IEnumerator attack()
    {
        routineFinished = false;
        yield return new WaitForSeconds(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.GetComponent<Animator>().SetBool("fire", false);
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        routineFinished = true;
    }
}
