using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public Rigidbody2D targetRigidBody;
    public PlayerMovement playerMovement;

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public GameObject explosionEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        direction.x = direction.x + Random.Range(-2.5f, 2.5f);

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBody")
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            Instantiate(explosionEffect, transform.position, transform.rotation);
            playerMovement.nonMovingTimer = .75f;
            targetRigidBody.AddForce(direction * 1000);
            // targetRigidBody.AddTorque(20, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
