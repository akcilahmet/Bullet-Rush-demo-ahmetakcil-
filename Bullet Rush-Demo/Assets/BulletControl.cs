using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float bulletSpeed = 5f;
    Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rg.velocity = (transform.forward * bulletSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Enemy temas oldu");
            //Destroy(other.gameObject, .3f);
        }
        else
        {
            Destroy(gameObject, 1.5f);
        }
    }
}
