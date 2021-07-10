using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class characterMoveControl : MonoBehaviour
{
    public float Horspeed = 300;

    public float walkingSpeed = 200;
    float tempSpeed;

    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;
    Animator anim;


    FireControl fireControl;
    private void Awake()
    {
        fireControl = FindObjectOfType<FireControl>();
    }

    private void Start()
    {
        tempSpeed = walkingSpeed;
        //walkingSpeed = 0;

        anim = GetComponent<Animator>();
        //anim.SetFloat("verticalprm", 0f);

    }

    //public void runStart()
    //{
    //    anim.SetTrigger("idleprm");

    //    walkingSpeed = tempSpeed;
    //    DOTween.To(() => walkingSpeed, x => walkingSpeed = x, tempSpeed, 1);
    //}
    public void FixedUpdate()
    {
        moveControl();
    }
    void moveControl()
    {
       
            Vector3 move = new Vector3(dynamicJoystick.Horizontal * Horspeed * Time.fixedDeltaTime, rb.velocity.y, dynamicJoystick.Vertical * walkingSpeed * Time.fixedDeltaTime);
            
            //float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            rb.velocity = move;
        
        
        

        anim.SetFloat("horprm", dynamicJoystick.Horizontal);
        anim.SetFloat("verprm", dynamicJoystick.Vertical);

    }




}
