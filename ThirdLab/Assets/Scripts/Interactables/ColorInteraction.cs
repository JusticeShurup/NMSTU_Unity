using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInteraction : MonoBehaviour, IInteractable
{
    private Renderer _renderer;
    private bool _isInteracted;
    
    public void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Interact()
    {
        _isInteracted = !_isInteracted;
        _renderer.material.color = _isInteracted ? Color.green : Color.cyan;

    }
}
