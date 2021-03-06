﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public Rigidbody2D targetRigidBody;
    public PlayerMovement playerMovement;
    public Animator playerAnimator;

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public float missileLastTime = 5f;
    public GameObject explosionEffect;
    public GameObject explosionEffectBlue;

    public SetPlayerFaceShocked setPlayerFaceShocked;
    public HealthTracker healthTracker;
    public DialogManager dialogManager;

    public SpriteRenderer playerBody;
    public SpriteRenderer playerHead;
    public Sprite forwardBody;

    private float directionalOffset;
    private TrailRenderer trailRenderer;
    private AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionalOffset = Random.Range(-0.5f, 0.5f);
        missileLastTime += Random.Range(0f, 4f);
        trailRenderer = GetComponent<TrailRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if(dialogManager.pauseGame){
            trailRenderer.emitting = false;
            trailRenderer.time = Mathf.Infinity;
            return;
        }
        else
        {
            trailRenderer.time = 1.5f;
            trailRenderer.emitting = true;
        }

        if(missileLastTime <= 0)
        {
            Instantiate(explosionEffectBlue, transform.position, transform.rotation);
            audioManager.Play("MissileMiss");
            Destroy(gameObject);
        } else
        {
            missileLastTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (dialogManager.pauseGame)
        {
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            return;
        }

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        direction.x = direction.x + directionalOffset;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogManager.pauseGame)
        {
            return;
        }

        if (collision.gameObject.tag == "PlayerBody" && playerMovement.nonMovingTimer <= 0)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            Instantiate(explosionEffect, transform.position, transform.rotation);
            playerMovement.nonMovingTimer = .75f;
            targetRigidBody.AddForce(direction * 400);

            if(!playerAnimator.GetBool("WalkUp"))
            {
                playerBody.sprite = forwardBody;
                playerHead.sortingOrder = 10;
            }
            setPlayerFaceShocked.setPlayerFaceShocked(false);

            healthTracker.loseHealth();

            audioManager.Play("MissileHit");
            Destroy(gameObject);
        }
    }
}
