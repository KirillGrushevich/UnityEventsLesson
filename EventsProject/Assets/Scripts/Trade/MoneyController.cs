using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int _traderMoney = 10_000;
    private int _playerMoney = 10_000;
    [SerializeField] private TextMeshProUGUI _traderMoneyText;
    [SerializeField] private TextMeshProUGUI _playerMoneyText;

    private void Start()
    {
        UpdateLabels();
    }

    public int TraderMoney
    {
        get => _traderMoney;
        set => _traderMoney = value;
    }

    public int PlayerMoney
    {
        get => _playerMoney;
        set => _playerMoney = value;
    }

    public int GetMoneyByType(ItemType type)
    {
        switch (type)
        {
           case ItemType.Player:
               return _playerMoney;
           case ItemType.Trader:
               return _traderMoney;
           default:
               return 0;
        }

    }

    public void AppendMoney(ItemType type, int count)
    {
        switch (type)
        {
            case ItemType.Player:
                _playerMoney += count;
                _traderMoney -= count;
                break;
            case ItemType.Trader:
                _traderMoney += count;
                _playerMoney -= count;
                break;
        }
        
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        _playerMoneyText.text = _playerMoney.ToString();
        _traderMoneyText.text = _traderMoney.ToString();
    }
}
