using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI text;
    public GameObject coin;
    int score;
    void Start()
    {
        coin = GameObject.Find("HealthBar");
        text = coin.GetComponentInChildren<TextMeshProUGUI>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x" + score.ToString();
    }
}
