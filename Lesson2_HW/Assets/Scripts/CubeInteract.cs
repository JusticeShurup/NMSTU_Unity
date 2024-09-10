using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeInteract : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Здарова, я куб!");
    }
}
