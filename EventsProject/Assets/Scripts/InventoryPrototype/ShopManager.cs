using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventorySlot[] shopSlots;

    private void Start()
    {
        FillShop();   
        SetInventoryOwner();
    }
    
    private void SetInventoryOwner()
    {
        foreach (var slot in shopSlots)
        {
            slot.SlotOwner = InventoryOwner.Shop;
        }
    }

    private void FillShop()
    {
        for (int i = 0; i < ItemsSystem.Instance.GetItemsCount; i++)
        {
            shopSlots[i].SetItem(ItemsSystem.Instance.GetRandomItem());
        }
    }
}
