using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    // public Transform shootPosition;
    public GameObject projectile;
    public Transform projectileTransform;
    public int projectileCount;
    public float coneRadius;

    private Camera _mainCamera;
    private PlayerInput _playerInput;
    private Vector3 _mousePos;
    private Vector3 _direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets Mouse Position and Direction
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePos - transform.position;

        // Apply rotation, affecting ProjectileTransform
        transform.rotation = Util.FacingDirection(_direction, -90);

        // Get Input
        if (_playerInput.actions["Primary Fire"].WasPressedThisFrame()) {
            Shoot();
        }
        if (_playerInput.actions["Secondary Fire"].WasPressedThisFrame()) {
            ShootCone(projectileCount, coneRadius);
        }
    }

    void Shoot()
    {   
        // Instantiate the projectile
        GameObject projectileObj = Instantiate(projectile, projectileTransform.position, Util.FacingDirection(_direction));
        // Set the bounceCount to 2 by getting the script component of the object
        projectileObj.GetComponent<Projectile>().bounceCount = 2;
    }

    void ShootCone(int projectileCount, float coneRadius)
    {
        // Split cone into 2 parts, with 0 at its center
        int split = projectileCount/2;
        // Degrees apart from each projectile
        float degree = coneRadius/(projectileCount - 1);

        for (int i = -split; i < projectileCount - split; i++)
        {
            // offset of Projectile ; Math is different depending on if the Count is Even or Odd
            float offset = (projectileCount % 2 == 0) ? degree * (i + 0.5f): degree * i;
            // Instantiate the projectile
            GameObject projectileObj = Instantiate(projectile, projectileTransform.position, Util.FacingDirection(_direction, offset));
            // Set the speed to 20 by getting the script component of the object
            projectileObj.GetComponent<Projectile>().speed = 20;
        }
    }
}
