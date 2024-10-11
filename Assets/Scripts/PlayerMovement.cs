
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _velocityVector;
    private Vector2 _inputVector;
    public float powerScalerX = 15f;
    public float powerScalerY = 15f;
    private Rigidbody2D _rb;
    private Vector2 _minBound;
    private Vector2 _maxBound;
    private Camera _mainCamera;
    public float paddingleft;
    public float paddingright;
    public float paddingtop;
    public float paddingbottom;

    private Shooter _shooter;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
        InitBounds();
    }

    private void InitBounds()
    {
        _minBound = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBound = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void FixedUpdate()
    {
        Moving();
    }

    private void Update()
    {
        ClampPosition();
    }

    private void Moving()
    {
        _velocityVector = new Vector2(_inputVector.x * powerScalerX, _inputVector.y * powerScalerY);
        
        _rb.velocity = _velocityVector;
    }

    private void ClampPosition()
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minBound.x + paddingleft, _maxBound.x - paddingright);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minBound.y + paddingbottom, _maxBound.y - paddingtop);
        transform.position = clampedPosition;
    }

    void OnMove(InputValue inputValue)
    {
        _inputVector = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        _shooter.isFiring = value.isPressed;
    }
}