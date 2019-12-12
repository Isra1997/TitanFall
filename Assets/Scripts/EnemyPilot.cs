using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPilot : MonoBehaviour
{
    const float maxHealth = 100;
    float currentHealth = maxHealth;
    public Slider healthBar;
    Animator anim;
    public GameObject sceneController;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        healthBar.value = maxHealth;
        anim.SetBool("walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("walking"))
        {
            transform.Translate(0, 0, 0.5f);
        }
       
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = (currentHealth / maxHealth);
        anim.SetBool("hit", true);
        anim.SetBool("walking", false);
        if (currentHealth <= 0)
        {
            anim.SetBool("dead", true);
            sceneController.GetComponent<LevelScript>().check();
        }
    }

}
