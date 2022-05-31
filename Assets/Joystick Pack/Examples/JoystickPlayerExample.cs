using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public float turnSpeed;
    public float maxSpeed;

    public void FixedUpdate()
    {
        float horizontonal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;

        Vector3 directon = new Vector3(horizontonal,0, vertical);
        rb.velocity = Vector3.ClampMagnitude(directon*3 * speed, maxSpeed);
        Vector3 lookRotation = Vector3.forward * vertical + Vector3.right * horizontonal;

        if (rb.velocity.magnitude < .01)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation), turnSpeed * Time.deltaTime);
        }

        GetComponent<Animator>().SetFloat("Speed", rb.velocity.magnitude);

    }

}