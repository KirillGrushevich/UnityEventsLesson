using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] slots;
    [SerializeField] private int money = 500;
    [SerializeField] private Text moneyText;
    
    void Start()
    {
       
        foreach (var slot in slots)
        {
            slot.OnItemPicked += OnItemPicked;
            slot.OnItemDroped += OnItemUnPicked;
        }
    }

    public void OnItemPicked()
    {

        foreach (var slot in slots)
        {
            slot.OffRaycast();
        }
    }
    
    public void OnItemUnPicked()
    {
        foreach (var slot in slots)
        {
            slot.OnRaycast();
        }
    }
    
    void Update()
    {
        moneyText.text = $"Money: {money.ToString()}";
    }
}
