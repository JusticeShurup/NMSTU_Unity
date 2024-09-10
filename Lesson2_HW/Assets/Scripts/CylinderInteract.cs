using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class CylinderInteract : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Здарова, я цилиндр");
        }
    }
}