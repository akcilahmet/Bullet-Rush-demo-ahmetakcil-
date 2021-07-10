using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    Vector3 distanceBetween;

    void Start()
    {
        distanceBetween = transform.position - player.position;
    }

    void Update()
    {
        transform.position =Vector3.Lerp(transform.position, player.position + distanceBetween,.3f);
    }
}
