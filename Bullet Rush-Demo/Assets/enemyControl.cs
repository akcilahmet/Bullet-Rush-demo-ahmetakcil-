using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControl : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject player;

    //to activate the enemy
    bool enemyMoveActive;
    
    //ray drawing variables
    RaycastHit hit;
    public Transform rayPos;
    [SerializeField] LayerMask layermask;
    public float distance = 500f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyMoveActive = false;
    }

    void Update()
    {
        enemyControlMetod();
        //If true, the enemy moves towards the player.
        if (enemyMoveActive==true)
        {
            agent.SetDestination(player.transform.position);

        }
    }

    public void  enemyControlMetod()
    {
        //Ray drawing was made to the enemyMoveActive object in the player
        if (Physics.Raycast(rayPos.position,rayPos.TransformDirection(Vector3.back),out hit, distance, layermask))
        {
            
            //EnemyMoveActive returns true if there is contact on the ray
            Debug.DrawRay(rayPos.position, rayPos.TransformDirection(Vector3.back) * hit.distance, Color.red);
            enemyMoveActive = true;
            hit.transform.LookAt(transform.position);
        }
        else
        {
            Debug.DrawRay(rayPos.position, rayPos.TransformDirection(Vector3.back) * 1000, Color.white);

        }
    }
}
