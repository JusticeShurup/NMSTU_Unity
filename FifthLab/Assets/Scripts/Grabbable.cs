using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public Color standartColor;

    // Start is called before the first frame update
    void Start()
    {
        standartColor =  GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
