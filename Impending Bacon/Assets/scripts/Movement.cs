using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rB;
    public float fForce = 200f; //forward+back force
    public float sForce = 300f; //left+right force

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //+fForce
        if (Input.GetKey("d"))
        {
            rB.AddForce(sForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rB.AddForce(-sForce * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("w"))
        {
            rB.AddForce(0, 0, fForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rB.AddForce(0, 0, -fForce * Time.deltaTime);
        }

    }
}
