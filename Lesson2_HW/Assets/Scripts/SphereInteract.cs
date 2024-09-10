using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SphereInteract : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Здарова, я сфера!");
        }
    }
}