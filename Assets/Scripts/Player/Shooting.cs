using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    // public GameObject projectile;
    public SpellManagerSO spellBook;
    public Transform projectileTransform;
    public int projectileCount = 3;
    public float coneRadius = 30f;

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
            spellBook.CastSpell("Fire", "Ball", projectileTransform.position, Util.FacingDirection(_direction));
        }
        if (_playerInput.actions["Secondary Fire"].WasPressedThisFrame()) {
            ShootCone(projectileCount, coneRadius);
        }
    }

    public void ShootCone(int projectileCount, float coneRadius)
    {
        // Split cone into 2 parts, with 0 at its center
        int split = projectileCount/2;
        // Degrees apart from each projectile
        float degree = coneRadius/(projectileCount - 1);

        for (int i = -split; i < projectileCount - split; i++)
        {
            // offset of Projectile ; Math is different depending on if the Count is Even or Odd
            float offset = (projectileCount % 2 == 0) ? degree * (i + 0.5f): degree * i;
            spellBook.CastSpell("Water", "Bolt", projectileTransform.position, Util.FacingDirection(_direction, offset));
        }
    }

    // private GameObject Shoot(GameObject projectile, float rotationOffset = 0)
    // {
    //     return Instantiate(projectile, projectileTransform.position, Util.FacingDirection(_direction, rotationOffset));
    // }
}
