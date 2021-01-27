using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header ("Variables:")]
    [SerializeField]
    private float speed = 5f;

    private Vector2 movement;
  
    [Header ("Components:")]
    public Rigidbody2D rigidbody;
    public Animator animator;

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        
       // movement.x = Input.GetAxisRaw("Horizontal");
       // movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero){
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }
}
