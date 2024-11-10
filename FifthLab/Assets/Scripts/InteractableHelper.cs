using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableHelper : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMesh;

    private void Awake()
    {
        _textMesh.gameObject.SetActive(false);
    }
    

    public void Show()
    {
        _textMesh.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _textMesh.gameObject.SetActive(false);
    }
}
