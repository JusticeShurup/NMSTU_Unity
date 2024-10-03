using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(0, 300f, 0);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            _rigidbody.AddForce(-15f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(15f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(15f, 0, 0);
        }
        

        _rigidbody.transform.rotation = Quaternion.identity;
    }
}
