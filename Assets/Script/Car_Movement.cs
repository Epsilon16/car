using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10;
    private float RotationSpeed = 1;
    public float time = 1;
    private bool start = false;

    // controle lumière 
    private bool is_light;
    public Light[] lightIntensity;
    private int switching = 1;
    private float LightSceller = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            start = true;
        if (Input.GetKeyDown(KeyCode.T))
            start = false;
        if (start)
            rb.velocity = transform.forward * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            time = time + Time.deltaTime;
            rb.velocity = transform.forward / (time);
        } else
        {
            time = 1;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(Vector3.up * RotationSpeed);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(Vector3.down * RotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.L) && LightSceller <= 0)
        {
            is_light = !is_light;
            LightSwitch(is_light);
            LightSceller = 0.25f;
        }
        LightSceller -= Time.deltaTime;
       
    }

    void LightSwitch(bool lightSwitch)
    {
        foreach (Light light in lightIntensity)
        {
            if (lightSwitch)
            {
                light.intensity = 50;
            }
            else
                light.intensity = 0;
        }
    }
}
