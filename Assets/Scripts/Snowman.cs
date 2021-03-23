using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snowman : Enemy
{
    private Vector3 direction;
    Snowman() : base(25, 3.0f, 10.0f)
    { }


    protected void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected void Start()
    {
        direction = transform.right;
    }

    public void Update()
    {
        Move();
    }
    public void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.5F, 0.1F);
        if (colliders.Length > 1 && colliders.All(x => !x.GetComponent<MainCharacter>())) direction *= -1.0F;

        sprite.flipX = direction.x < 0.0F;

        //if (colliders.All(x => !x.GetComponent<MainCharacter>()))
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
