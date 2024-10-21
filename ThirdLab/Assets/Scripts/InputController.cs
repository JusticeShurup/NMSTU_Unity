using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour
{
    public UnityEvent shootEvent = new();
    public UnityEvent jumpEvent = new();

    public Vector2 move;
    public Vector2 mouse;
    public bool shoot;
    public bool jump;

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        mouse = value.Get<Vector2>();
    }

    public void OnShoot(InputValue value)
    {
        shoot = value.isPressed;
        shootEvent?.Invoke();
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
        jumpEvent?.Invoke();
    }
}
