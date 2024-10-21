using UnityEngine;

namespace Interactables
{
    public class RotationInteraction : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            transform.Rotate(new Vector3(0, 1, 0), 10);

        }
    }
}