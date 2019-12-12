using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    //public GameObject[] Enmies;
    public int alive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void check()
    {
        alive = alive - 1;
        if (alive == 0)
        {
            Debug.Log("ALL DEAD!!!!!");
            SceneManager.LoadScene(3);
        }
    }
}
