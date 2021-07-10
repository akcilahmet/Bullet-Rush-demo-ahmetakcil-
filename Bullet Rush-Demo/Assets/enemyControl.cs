using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControl : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    bool enemyMoveActive;

    [SerializeField] LayerMask layermask;
    public float distance = 500f;
    public Transform rayPos;
    RaycastHit hit;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyMoveActive = false;
    }

    void Update()
    {
        Debug.Log("EnemyActiveBool:" + enemyMoveActive);
        enemyControlMetod();
        if (enemyMoveActive==true)
        {
            agent.SetDestination(player.transform.position);

        }
    }

    public void  enemyControlMetod()
    {
        if(Physics.Raycast(rayPos.position,rayPos.TransformDirection(Vector3.back),out hit, distance, layermask))
        {
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
