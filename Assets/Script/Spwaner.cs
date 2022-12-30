using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject DestroyCar;
    public GameObject[] spawner;
    public int random;

    public float time;

    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;


        if (time >= 3f)
        {
            spawned = true;
            time = 0;
        }
        else
            spawned = false;
        if (spawned)
        {
            random = Random.Range(0, 3);
            GameObject Car = Instantiate(DestroyCar) as GameObject;
            Car.transform.position = spawner[random].transform.position;
            
        }

        //if (time >= 3f)
        //    time = 0;
    }
}
