using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{

    public GameObject enemyParent;
    private float enemyChildCount;
    public Text EnemyCountText;

    //fire points
    public Transform aimpos1;
    public Transform aimpos;
    //bullet
    public GameObject bullet;

    public DynamicJoystick dynamicJoystick;


    private GameObject currentTarget;
    public GameObject currentGun;

    public float distance = 500f;
    private bool isAiming;
    public bool lookedOnTarget = false;

    [SerializeField] LayerMask layermask;

    RaycastHit hit;

    void Start()
    {
        enemyChildCount = enemyParent.transform.childCount;
        Debug.Log(enemyChildCount);

        currentGun.transform.position = aimpos.position;
        lookedOnTarget = false;
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
        enemyChildCount = enemyParent.transform.childCount;
        EnemyCountText.text = "Enemy:" + enemyChildCount.ToString();

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
                    lookedOnTarget = true;
                    currentTarget = hit.transform.gameObject;
                    isAiming = true;


                }
                else
                {
                    currentTarget = null;
                    isAiming = false;
                    lookedOnTarget = false;
                }
            }
        }
        else
        {
            Debug.DrawRay(aimpos.position, aimpos.TransformDirection(new Vector3(0, 0, 1)) * 1000, Color.white);
            currentTarget = null;
            isAiming = false;
            lookedOnTarget = false;
            float targetAngle = Mathf.Atan2(dynamicJoystick.Horizontal * 300 * Time.fixedDeltaTime, dynamicJoystick.Vertical * 200 * Time.fixedDeltaTime) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

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
