using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _velocityVector;
    private Vector2 _inputVector;
    public float powerScaler;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }
    private void Run()
        {
            _velocityVector = new Vector2(_inputVector.x * powerScaler , _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = _velocityVector;
        }
        void OnMove(InputValue inputValue)
        {
            _inputVector = inputValue.Get<Vector2>();
        }
}
