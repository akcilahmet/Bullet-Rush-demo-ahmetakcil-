using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    //fire points
    public Transform aimpos1;
    public Transform aimpos;
    //bullet
    public GameObject bullet;

    private GameObject currentTarget;
    public GameObject currentGun;

    public float distance = 500f;
    private bool isAiming;

    [SerializeField] LayerMask layermask;

    RaycastHit hit;

    void Start()
    {
        currentGun.transform.position = aimpos.position;
    }


    private void FixedUpdate()
    {
        CheckTarget();

        if (isAiming)
        {
            AutoAiming();
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    void CheckTarget()
    {
        if (Physics.Raycast(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)), out hit, distance, layermask))
        {
            Debug.DrawRay(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)) * hit.distance, Color.red);

            if (hit.transform.gameObject.tag == "Enemy")
            {


                if (!isAiming)
                {
                    Fire();
                    Fire1();

                    currentTarget = hit.transform.gameObject;
                    isAiming = true;


                }
                else
                {
                    currentTarget = null;
                    isAiming = false;
                }
            }
        }
        else
        {
            Debug.DrawRay(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)) * 1000, Color.white);
            currentTarget = null;
            isAiming = false;

        }
    }
   
    private void AutoAiming()
    {

        currentGun.transform.LookAt(currentTarget.transform);

    }
    void Fire()
    {
        GameObject bulletGO = Instantiate(bullet, aimpos.position, aimpos.rotation);
    }
    void Fire1()
    {
        GameObject bulletGO = Instantiate(bullet, aimpos1.position, aimpos1.rotation);
    }
}
