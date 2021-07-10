using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    //
    public float bulletSpeed = 5f;
    Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
  
    }

    void FixedUpdate()
    {
        //forward velocity applied to bullet
        rg.velocity = (transform.forward * bulletSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the bullet touches the enemy, the enemy will be destroyed.
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);//the bullet will be destroyed upon contact with the enemy
            Destroy(other.gameObject, .3f);

        }
        else
        {
            Destroy(gameObject, 1.5f);//If the bullet doesn't make contact, it will be destroyed after 1.5 seconds.

        }
    }
}
