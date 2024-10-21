using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private float _mouseSensivity;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    
    private Rigidbody _rigidbody;
    private Camera _camera;

    private float _xRotation = 0;
    private float _yRotation = 0;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        
        _inputController.shootEvent.AddListener(ShootEventHandler);
        _inputController.jumpEvent.AddListener(JumpEventHandler);
    }


    public void Update()
    {
        UpdateLook();
        UpdateMove();
    }

    private void UpdateLook()
    {
        _xRotation -= _inputController.mouse.y;
        _xRotation = Mathf.Clamp(_xRotation, -30f, 30f);

        _yRotation += _inputController.mouse.x;

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
    
    
    private void UpdateMove()
    {
        _rigidbody.AddRelativeForce(new Vector3(_inputController.move.x, 0, _inputController.move.y) * _speed);
    }

    
    private void JumpEventHandler()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForse, ForceMode.Impulse);
    }

    private void ShootEventHandler()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position + _camera.transform.forward, transform.rotation);
    }
    
}
