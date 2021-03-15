using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    protected int damage;

    public Enemy(int damage, float speed, float jumpForce) : base(speed, jumpForce)
    {
        this.damage = damage;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        MainCharacter character = collider.GetComponent<MainCharacter>();

        if (character)
        {
            character.ReceiveDamage(damage);
        }
    }
}
