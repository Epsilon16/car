using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCar_movement : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody rb;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * Speed;
        
        
    }



}
