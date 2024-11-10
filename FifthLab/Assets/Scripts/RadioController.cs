using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Stop();
    }

}
