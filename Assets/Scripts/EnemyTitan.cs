using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTitan : MonoBehaviour
{
    const float maxHealth = 400;
    float currentHealth = maxHealth;
    public Slider healthBar;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("walking"))
        {
            transform.Translate(0, 0, 0.05f);
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
        }
    }
}
