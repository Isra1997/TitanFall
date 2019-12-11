using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject[] Enmies;
    private bool Parkour = false;

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
        for (int i = 0; i < Enmies.Length; i++)
        {
            if (Enmies[i] != null)
            {
                
            }
               
        }
    }
}
