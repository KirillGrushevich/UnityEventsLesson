using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerMoney;
    [SerializeField] private int sellerMoney;

    [SerializeField] private Text playerText;
    [SerializeField] private Text sellerText;

    private void Start()
    {
        SetMoneyText();
    }

    void SetMoneyText()
    {
        playerText.text = $"Player: {playerMoney}";
        sellerText.text = $"Seller: {sellerMoney}";
    }

    public bool BuyItem(Item item)
    {
        if (playerMoney - item.cost >= 0)
        {
            playerMoney -= item.cost;
            sellerMoney += item.cost;
            SetMoneyText();
            return true;
        }
        return false;
    }

    public bool SellItem(Item item)
    {
        if (sellerMoney - item.cost >= 0)
        {
            playerMoney += item.cost;
            sellerMoney -= item.cost;
            SetMoneyText();
            return true;
        }

        return false;
    }
}
