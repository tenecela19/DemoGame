using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
     Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiderPosition= player.position + offset;
        Vector3 smoothnedPosition = Vector3.SmoothDamp(transform.position, desiderPosition,ref velocity, smoothSpeed);
        transform.position = smoothnedPosition;
        transform.LookAt(player);
    }
}
