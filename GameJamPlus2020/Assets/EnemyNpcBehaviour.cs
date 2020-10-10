using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNpcBehaviour : MonoBehaviour
{
   // Start is called before the first frame update

    public float speed;
    public float startPositionY;
    public float finalPositionY;
   
    public Rigidbody2D rb;

    public bool isMoving;
    public bool isAttacking;
    public GameObject enemy;

    public NpcStats enemyScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        rb.isKinematic = true;

        startPositionY = transform.position.y;

        isMoving = true;
    }

    void FixedUpdate()
    {
        

        if(isMoving) 
        {

            if (transform.position.x > -6.8f)
            {
                rb.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * speed);

            }

        }


        if(isAttacking) {
            enemyScript = enemy.GetComponent<NpcStats>();
            enemyScript.health += -1 * Time.deltaTime;
        }
    }


   
    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player" || other.gameObject.tag == "OwnBase" ) {
            isMoving = false;
            isAttacking = true;
            enemy = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player") {
            isMoving = true;
            isAttacking = false;
        }
    }
}
