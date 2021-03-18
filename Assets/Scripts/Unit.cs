using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;
    [SerializeField]
    protected float speed = 3.0f;
    [SerializeField]
    protected float jumpForce = 7.0f;

    protected Rigidbody2D rigidBody;
    protected Animator animator;
    protected SpriteRenderer sprite;

    public Unit(float speed, float jumpForce)
    {
        this.speed = speed;
        this.jumpForce = jumpForce;
    }

    public virtual void ReceiveDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
