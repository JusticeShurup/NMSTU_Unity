using UnityEngine;

namespace Interactables
{
    public class SizeInteraction : MonoBehaviour, IInteractable
    {
        private bool _isInteracted;
    

        public void Interact()
        {
            _isInteracted = !_isInteracted;
            transform.localScale = _isInteracted ? new Vector3(1, 1, 1) : new Vector3(2, 2, 2);

        }
    }
}
