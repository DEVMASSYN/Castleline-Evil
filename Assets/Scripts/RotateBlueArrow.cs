using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlueArrow : MonoBehaviour
{
    private Vector3 targetRotation;
    private bool rotating = false;
    public void Update()
    {
        if (rotating)
        {
            Vector3 newForward = Vector3.RotateTowards(transform.forward, targetRotation, 180.0f * Time.deltaTime, 0);
            transform.forward = newForward;
            if (newForward.normalized == targetRotation.normalized)
            {
                rotating = false;
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Vision")
        { // check if collided with rope
            rotating = true;
            targetRotation = collision.collider.transform.right;
            targetRotation.y = transform.position.y; // set target Y rotation to current Y
        }
    }
}

