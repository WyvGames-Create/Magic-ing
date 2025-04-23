using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
// public Variables
    public float Speed = 10f;
    public float SlowMultiplierValue = 0.5f;
    public Rigidbody2D rb;
// Variables
    private float SlowMultiplier = 1f;
    private float Horizontal;
    private float Vertical;
// void Start()
    void Start()
    {
    }
// void Update()
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        // if (Input.GetButtonDown("Slow"))
        // {
        //     SlowMultiplier = SlowMultiplierValue;
        // } else if (Input.GetButtonUp("Slow"))
        // {
        //     SlowMultiplier = 1f;
        // }
    }
// void FixedUpdate()
    void FixedUpdate()
    {
    //Movement
        Vector3 tempVect = new Vector3(Horizontal, Vertical, 0);
        tempVect = tempVect.normalized * Speed * SlowMultiplier * Time.fixedDeltaTime;

        gameObject.transform.position += tempVect;
    }
}