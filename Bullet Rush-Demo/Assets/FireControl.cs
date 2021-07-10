using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    //Variables for Enemy children
    public GameObject enemyParent;
    private float enemyChildCount;
    public Text EnemyCountText;

    //fire points
    public Transform aimpos1;
    public Transform aimpos;

    //bullet
    public GameObject bullet;

    public DynamicJoystick dynamicJoystick;

    //player used to lock enemye
    private GameObject currentTarget;
    public GameObject currentGun;

    //for ray drawing
    RaycastHit hit;
    public float distance = 500f;
    private bool isAiming;
    [SerializeField] LayerMask layermask;


    void Start()
    {

        enemyChildCount = enemyParent.transform.childCount;

        //currentGun.transform.position = aimpos.position;
    }


    private void FixedUpdate()
    {
        // draw ray method
        CheckTarget();

        //If the is aiming bool variable is true, the autoaiming method is requested to run
        if (isAiming)
        {
            AutoAiming();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Made to show the number of enemy on the screen
        enemyChildCount = enemyParent.transform.childCount;
        EnemyCountText.text = "Enemy:" + enemyChildCount.ToString();

    }

    void CheckTarget()
    {
        //Ray were drawn from aimpos object to objects with forward enemy layer mask.
        if (Physics.Raycast(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)), out hit, distance, layermask))
        {
            //Let the enemy layermask draw a red ray if contact
            Debug.DrawRay(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)) * hit.distance, Color.red);

            if (hit.transform.gameObject.tag == "Enemy")
            {
                //Fired when the beam touched the enemy
                if (!isAiming)
                {
                    Fire();
                    Fire1();
                    //the enemy position, current target is thrown.
                    currentTarget = hit.transform.gameObject;
                    isAiming = true;


                }
                else
                {
                    //Null value is assigned to enemy if there is no beam contact (current target)
                    currentTarget = null;
                    isAiming = false;
                }
            }
        }
        else
        {
            //white ray drawn if there is no ray contact to the enemy
            Debug.DrawRay(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)) * 1000, Color.white);
            currentTarget = null;
            isAiming = false;

            //player rotation control released.
            float targetAngle = Mathf.Atan2(dynamicJoystick.Horizontal * 300 * Time.fixedDeltaTime, dynamicJoystick.Vertical * 200 * Time.fixedDeltaTime) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        }
    }
   
    private void AutoAiming()
    {
        //made to look at current target
        currentGun.transform.LookAt(currentTarget.transform);

    }

    //Bullet was created to shoot from right and left handed weapons
    void Fire()
    {
        GameObject bulletGO = Instantiate(bullet, aimpos.position, aimpos.rotation);
    }
    void Fire1()
    {
        GameObject bulletGO = Instantiate(bullet, aimpos1.position, aimpos1.rotation);
    }
}
