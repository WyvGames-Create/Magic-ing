using UnityEngine;

public class IndependentMovement : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D _rigidbody;
    private Vector2 _input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        _input.Normalize();

        if (Mathf.Abs(_input.x) > 0) 
        {
            _rigidbody.linearVelocity = new Vector2(_input.x * speed, _rigidbody.linearVelocity.y);
        }
        if (Mathf.Abs(_input.y) > 0) 
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _input.y * speed);
        }
    }
}
