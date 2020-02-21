using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer rightLeg;
    public SpriteRenderer leftLeg;

    Vector2 movement;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.y > 0)
        {
            animator.SetBool("WalkUp", false);
            animator.SetBool("Idle", false);
            animator.SetBool("WalkDown", true);
            
        } else if (movement.y < 0 || (movement.y == 0 && movement.x != 0))
        {
            animator.SetBool("WalkDown", false);
            animator.SetBool("Idle", false);
            animator.SetBool("WalkUp", true);
        } else if (movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("WalkUp", false);
            animator.SetBool("WalkDown", false);
            animator.SetBool("Idle", true);
        }
        if (movement.x > 0)
        {
            leftLeg.flipX = false;
            rightLeg.flipX = false;
        } else if (movement.x < 0)
        {
            rightLeg.flipX = true;
            leftLeg.flipX = true;
        }
    }
    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
