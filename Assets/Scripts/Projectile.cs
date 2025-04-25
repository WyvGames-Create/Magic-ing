using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public int bounceCount = 0;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Getting Components
        _rigidbody = GetComponent<Rigidbody2D>();
        // Setting Values
        _direction = transform.right;
        _rigidbody.linearVelocity = _direction * speed;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounceCount > 0)
        {
            // Bounce by reflecting over the normal vector of the collided object
            _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
            // Setting new values
            _rigidbody.linearVelocity = _direction * speed;
            transform.rotation = Util.FacingDirection(_direction);
            // Decrementing count
            bounceCount--;
        } 
        else
        {
            Destroy(gameObject);
        }
        Debug.Log($"{collision.gameObject.name} was hit!");
    }
}
