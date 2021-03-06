using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    protected int coinValue = 1;

    public Coin(int coinValue)
    {
        this.coinValue = coinValue;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinManager.instance.ChangeScore(coinValue);
        }
    }
}
