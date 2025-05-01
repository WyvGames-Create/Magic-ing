using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Attributes")]
    public ElementSO element;
    public FormSO form;
    
    [Header("Debug")]
    public bool debugStats = false;
    public bool debugCollision = false;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private int _bounceCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Getting Components
        _rigidbody = GetComponent<Rigidbody2D>();
        GetComponentInChildren<SpriteRenderer>().color = element.color;
        // Setting Values
        _direction = transform.right;
        _rigidbody.linearVelocity = _direction * GetSpeed();
        _bounceCount = form.maxBounce + element.maxBounce;
        // Set a timer to delete the projectile
        Destroy(gameObject, GetRange() / GetSpeed());

        if (debugStats)
        {
            Debug.Log($"Damage: {GetDamage()}");
            Debug.Log($"Speed: {GetSpeed()}");
            Debug.Log($"Range: {GetRange()}");
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision Debug
        if (debugCollision)
        {
            Debug.Log($"{collision.gameObject.name} was hit!");
            Debug.Log($"Bounces: {_bounceCount}");
        } 

        if (_bounceCount > 0)
        {
            // Bounce by reflecting over the normal vector of the collided object
            _direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
            // Setting new values
            _rigidbody.linearVelocity = _direction * GetSpeed();
            transform.rotation = Util.FacingDirection(_direction);
            // Decrementing count
            _bounceCount--;
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

    // Runtime calculations
    public float GetDamage() {
        return form.damage * element.damageModifier;
    }
    public float GetSpeed() {
        return form.speed * element.speedModifier;
    }
    public float GetRange() {
        return form.range * element.speedModifier;
    }
    
}
