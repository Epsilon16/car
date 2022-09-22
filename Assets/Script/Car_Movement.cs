using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10;
    private float RotationSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.forward * 0;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(Vector3.up * RotationSpeed);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(Vector3.down * RotationSpeed);
        }
    }
}
