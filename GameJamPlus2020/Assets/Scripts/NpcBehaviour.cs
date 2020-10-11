using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NpcBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float startPositionY;
    public float finalPositionY;
    public bool goToDownBridge;
    public bool goToUPBridge;


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

            if (transform.position.x < 5.8f)
            {
                rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);

            }


            if(transform.position.y >= -2.0f && transform.position.y <= -0.6f )
            {

                goToDownBridge = true;
                goToUPBridge = false;
                
            }

            if(transform.position.y >= 0.1f && transform.position.y <= 2.5f )
            {

                goToDownBridge = false;
                goToUPBridge = true;
                
            }


            if(goToUPBridge) 
            {
                if (transform.position.y < 1.55f)
                {
                    rb.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * speed);
                }
            }
        

            if(goToDownBridge) 
            {
                if (transform.position.y < -1.5f)
                {
                    rb.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * speed);
                }
            }
        }


        if(isAttacking) {
            enemyScript = enemy.GetComponent<NpcStats>();
            enemyScript.health += -1 * Time.deltaTime;
        }
    }


   
    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Base" ) {
            isMoving = false;
            isAttacking = true;
            enemy = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
         if(other.gameObject.tag == "Enemy") {
            isMoving = true;
            isAttacking = false;
        }
    }
}
