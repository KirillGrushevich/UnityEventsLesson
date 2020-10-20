using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trader : MonoBehaviour
{
    public int money = 1000;
    
    [SerializeField]
    private Text moneyText;

    public void Deal(int cost, Trader trader2)
    {
        money -= cost;
        trader2.money += cost;
        
        UpdateText();
        trader2.UpdateText();
    }

    public void UpdateText()
    {
        moneyText.text = $"COINS: {money}";
    }
}
