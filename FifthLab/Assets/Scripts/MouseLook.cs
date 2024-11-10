using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private float _xRotation = 0;
    private float _yRotation = 0;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y");
        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);

        _yRotation += Input.GetAxis("Mouse X");

        Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }

}