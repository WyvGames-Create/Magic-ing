using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializedField] private Rigidbody2D rb;
    [SerializedField] private Transform groundCheck;
    [SerializedField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity - new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }
    private void FixedUpdate(){
        rb.velocity = new Velocity2(horizontal * speed ,rb.velocity.y);
    }
    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f ,groundLayer);
    } 
    private void Flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight * horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
