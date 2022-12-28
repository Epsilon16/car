using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car_Controller : MonoBehaviour
{
    public Text txtSpeed;
    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider back_left;
    public WheelCollider back_right;

    public float Torque;
    public float Speed;
    
    public int Brake = 10000;
    public float CoefAccelerator = 10f;
    
    public float MaxSpeed = 100f;

    public float WheelAngleMax = 5f;

    public bool freinage = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, -0.9f, -0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        //son moteur 
        float Val_Pitch = Speed / MaxSpeed + 2f;
        GetComponent<AudioSource>().pitch = Mathf.Clamp(Val_Pitch, 1f, 3f); 

        // Affichage vitesse 
        Speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        txtSpeed.text = "Speed :" + (int)Speed;

        //Accélération 
        if (Input.GetKey(KeyCode.UpArrow) && Speed < MaxSpeed)
        {
            if (!freinage)
            {
                front_left.brakeTorque = 0;
                front_right.brakeTorque = 0;
                back_left.brakeTorque = 0;
                back_right.brakeTorque = 0;
                back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAccelerator * Time.deltaTime;
                back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAccelerator * Time.deltaTime;
            }
        }

        //Décélération
        if (!Input.GetKey(KeyCode.UpArrow) && !freinage || Speed > MaxSpeed)
        {
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
            back_left.brakeTorque = Brake * CoefAccelerator * Time.deltaTime;
            back_right.brakeTorque = Brake * CoefAccelerator * Time.deltaTime;
        }

        //Direction véhicule 
        front_left.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;
        front_right.steerAngle = Input.GetAxis("Horizontal") * WheelAngleMax;

        //freinage
        if (Input.GetKey(KeyCode.Space))
        {
            freinage = true;
            back_left.brakeTorque = Mathf.Infinity;
            back_right.brakeTorque = Mathf.Infinity;
            front_left.brakeTorque = Mathf.Infinity;
            front_right.brakeTorque = Mathf.Infinity;
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
        }
        else
            freinage = false;

        //marche arrière
        if (Input.GetKey(KeyCode.DownArrow))
        {
            front_left.brakeTorque = 0;
            front_right.brakeTorque = 0;
            back_left.brakeTorque = 0;
            back_right.brakeTorque = 0;
            back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAccelerator * Time.deltaTime;
            back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAccelerator * Time.deltaTime;
        }
    }
}
