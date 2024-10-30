using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private float _playerSpeed = 2.0f;

    private void Start()
    {
        _characterController = gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }

        _characterController.Move(movement * Time.deltaTime * _playerSpeed);
        
        _characterController.Move(_playerVelocity * _playerSpeed);
    }

}