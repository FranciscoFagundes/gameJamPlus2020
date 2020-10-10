using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcStats : MonoBehaviour
{

    public float health;
    public float startHealth;
    public float attackForce;
    public float armor;
    public float range;

    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / startHealth;
        
        if(gameObject.tag == "Enemy" || gameObject.tag == "Player") {
            if(health <= 0) {
                Destroy(this.gameObject);
            }
        }
        
    }
}
