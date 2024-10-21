using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _elapsedTime = 0f;
    
    
    [SerializeField] private GameObject _bullet;
    
        
    void Awake()
    {
        _bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * 30, ForceMode.VelocityChange);
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > 5.0f)
        {
            Destroy(_bullet);
            Destroy(this);
        }
    }
}
