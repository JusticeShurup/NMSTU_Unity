using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private MagnetField _magnetField;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _magnetField.isMagnetFieldWorking = !_magnetField.isMagnetFieldWorking;
        }
    }
}
