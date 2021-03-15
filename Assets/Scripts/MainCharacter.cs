using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Unit
{
    public MainCharacter() : base(5.0f, 15.0f)
    {
    }

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //changeGrounded();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

        if (hp < 1) Die();
    }

    private void FixedUpdate()
    {
        changeGrounded();
    }

    void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void changeGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        isGrounded = colliders.Length > 1;
    }

}
