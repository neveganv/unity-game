using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    private GameObject character;

    private void Awake()
    {
        fill = GetComponentInChildren<Image>();
        character = GameObject.Find("Character");
    }
    private async void Update()
    {
        MainCharacter mainCharacter = character.GetComponent<MainCharacter>();
        float previousFill = fill.fillAmount;
        for (float i = previousFill; i > (float)mainCharacter.hp/100; i-=0.01f)
        {
            fill.fillAmount = i;
            await Task.Delay(10);
        }
    }
}
