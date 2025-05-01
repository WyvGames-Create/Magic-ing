using UnityEngine;

public class OldProjectile : MonoBehaviour
{
    [Header("Projectile Attributes")]
    public float speed = 10;
    public int bounceCount = 0;
    [Header("Projectile Despawning")]
    public float timeLimit = 2;
    public bool useDistanceLimit = false;
    public float distanceLimit = 20;
    [Header("Debug")]
    public bool debugCollision = false;

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
        // Set a timer to delete the projectile
        Destroy(gameObject, useDistanceLimit ? distanceLimit / speed : timeLimit);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision Debug
        if (debugCollision) Debug.Log($"{collision.gameObject.name} was hit!");

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
            // Delete the projectile early should a collision be detected 
            Destroy(gameObject);
            return;
        }
    }

    // OnDisable is called on destroy
    private void OnDisable()
    {
        
    }
}
