﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MainCharacter : Unit
{
    private bool isGrounded = false;
    private bool isDead = false;
    private bool facingRight = true;

    public MainCharacter() : base(5.0f, 15.0f)
    {}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
        }
    }

    private CharacterState State
    {
        get { return (CharacterState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Update()
    {
        ChangeGrounded();

        if (!isDead)
        {
            State = CharacterState.Idle;

            if (Input.GetButton("Horizontal"))
                Run();
            if (isGrounded && Input.GetButtonDown("Jump"))
                Jump();
            if (hp <= 0)
                Die();
        }
    }

    void Run()
    {
        State = CharacterState.Run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        //flip character
        if (Input.GetAxis("Horizontal") < 0.0f && facingRight || Input.GetAxis("Horizontal") > 0.0f && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void ChangeGrounded()
    {       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        isGrounded = colliders.Length > 1;
    }

    public override void ReceiveDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            State = CharacterState.Hurt;
            animator.Play("Base Layer.hurt");
        }
    }

    protected override void Die()
    {
        isDead = true;
        Debug.Log("Died");
        State = CharacterState.Death;

        Destroy(gameObject, 2);
    }

}

public enum CharacterState // стани персонажа
{
    Idle,
    Run,
    Death,
    Hurt
}
