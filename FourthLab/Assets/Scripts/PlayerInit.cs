using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _player.transform.position = transform.position;
        Camera.main.transform.position = transform.position;
        GameObject player = Instantiate(_player);
        Camera.main.transform.SetParent(player.transform);
    }

}
