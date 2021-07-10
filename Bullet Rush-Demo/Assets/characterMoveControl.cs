using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class characterMoveControl : MonoBehaviour
{
    //movement speed variables
    public float Horspeed = 300;
    public float walkingSpeed = 200;
    public DynamicJoystick dynamicJoystick;

    float tempSpeed;

    public Rigidbody rb;
    Animator anim;


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
        //Added joystick values ​​to vector3
        Vector3 move = new Vector3(dynamicJoystick.Horizontal * Horspeed * Time.fixedDeltaTime, rb.velocity.y, dynamicJoystick.Vertical * walkingSpeed * Time.fixedDeltaTime);
        rb.velocity = move;

        //animations that should work while moving
        anim.SetFloat("horprm", dynamicJoystick.Horizontal);
        anim.SetFloat("verprm", dynamicJoystick.Vertical);

    }




}
