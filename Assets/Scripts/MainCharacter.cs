using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class MainCharacter : Unit
{
    private bool isGrounded = false;
    private bool isDead = false;

    public MainCharacter() : base(5.0f, 15.0f)
    {}

    private CharacterState State
    {
        get { return (CharacterState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Update()
    {
        changeGrounded();
        Debug.Log(hp);
        if (isGrounded && !isDead)
            State = CharacterState.Idle;

        if (!isDead)
        {
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
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;

        State = CharacterState.Run;
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
    Death
}
