using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TouchManager : MonoBehaviour
{
    /// <summary>
    /// Manages touch input.
    /// </summary>

    private PlayerInput _playerinput;

    private InputAction _onTouchPressed;
    private InputAction _onTouchPosition;

    public bool IsTouchPressed { get; private set; }
    public Vector2 TouchPosition { get; private set; }

    private void Awake()
    {
        _playerinput = GetComponent<PlayerInput>();
        _onTouchPressed = _playerinput.actions["Press"];
        _onTouchPosition = _playerinput.actions["Position"];
    }


    private void TouchPressed(InputAction.CallbackContext context)
    {     
        IsTouchPressed = context.ReadValueAsButton();
        TouchPosition = _onTouchPosition.ReadValue<Vector2>();
        //Debug.Log($"Touch pos in Touch Manager: {TouchPosition}");
        EventManager.current.ScreenPressed();
    }


    private void OnEnable()
    {
        _onTouchPressed.performed += TouchPressed;
    }
    private void OnDisable()
    {
        _onTouchPressed.performed -= TouchPressed;
    }
}
