using UnityEngine;
using UnityEngine.InputSystem;

public class IndependentMovement : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets components from the GameObject instead of needing to reference it in the editor
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // Uses PlayerInput Componet for controls
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();

        // Moves on each axis independantly, allowing friction physics instead of just stopping when button is released
        if (Mathf.Abs(input.x) > 0) 
        {
            _rigidbody.linearVelocity = new Vector2(input.x * speed, _rigidbody.linearVelocity.y);
        }
        if (Mathf.Abs(input.y) > 0) 
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, input.y * speed);
        }
    }
}
