using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactables
{
    public class TextInteraction : MonoBehaviour, IInteractable
    {
        private bool _isInteracted; 
        [SerializeField] private TextMeshPro _textMesh;

        private void Awake()
        {
            _textMesh.gameObject.SetActive(false);
        }

        public void Interact()
        {
            _isInteracted = !_isInteracted;
            _textMesh.gameObject.SetActive(_isInteracted);
        }
    }
}
