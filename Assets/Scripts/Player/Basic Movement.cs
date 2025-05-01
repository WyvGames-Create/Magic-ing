using UnityEngine;

public class BasicMovement : MonoBehaviour
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

        // Makes all diagonal movements the same speed
        _input.Normalize();
    }

    void FixedUpdate()
    {
        _rigidbody.linearVelocity = _input * speed;
    }
}
