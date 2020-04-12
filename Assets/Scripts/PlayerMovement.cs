﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject objectState1;
    public GameObject objectState2;

    Vector2 movement;
    Vector2 LastMove;
    // Update is called once per frame

    private void Awake()
    {
        objectState1.SetActive(true);
        objectState2.SetActive(false);
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("LastMoveX", LastMove.x);
        animator.SetFloat("LastMoveY", LastMove.y);


        if (CoinManager.coinCount == 6)
        {
            Destroy(objectState1);
            objectState2.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

    }

}
