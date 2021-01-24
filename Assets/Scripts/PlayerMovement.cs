using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Speed settings:")]
    public float speed;
    public float baseSpeed = 5.0f; //use this to augment speed for walking/running

    private Vector2 moveDirection; //could make public to add status aligments like confuse that invert controls??

    [Space]
    [Header("References:")]
    public Rigidbody2D rigidbody;
    public Animator animator;

    void Update()
    {
        ProcessInputs(); 
        Animate();  
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speed = Mathf.Clamp(moveDirection.magnitude, 0.0f, 1.0f);
        moveDirection.Normalize();
    }

    void Move()
    {
        rigidbody.velocity = moveDirection * speed * baseSpeed;
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
    }
}
