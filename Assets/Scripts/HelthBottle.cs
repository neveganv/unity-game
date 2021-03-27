using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthBottle : MonoBehaviour
{
    [SerializeField]
    protected int heal;

    public HelthBottle(int heal)
    {
        this.heal = heal;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MainCharacter character = other.GetComponent<MainCharacter>();
            character.ReceiveHeal(heal);
        }
    }


    void Start()
    {

    }
    void Update()
    {

    }
}
