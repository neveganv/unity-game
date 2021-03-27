using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlyingCoin : Coin
{
    private Vector3 direction;

    FlyingCoin() : base(5)
    { }
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {

    }
}
