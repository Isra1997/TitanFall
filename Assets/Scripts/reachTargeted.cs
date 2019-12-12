using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reachTargeted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("targeted"))
    //    {
    //        SceneManager.LoadScene(4);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("rrrr");
        if (collision.gameObject.CompareTag("targeted"))
        {
            SceneManager.LoadScene(4);
        }
    }
}
