using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
 
    // FOR TESTS ONLY
    public int StartItemsAmount = 5;
    
    private void Start()
    {
        SetInventoryOwner();
        FillInventory();   
    }

    private void SetInventoryOwner()
    {
        foreach (var slot in inventorySlots)
        {
            slot.SlotOwner = InventoryOwner.Player;
        }
    }
    
    private void FillInventory()
    {
        for (int i = 0; i < StartItemsAmount; i++)
        {
            inventorySlots[i].SetItem(ItemsSystem.Instance.GetRandomItem());
        }
    }
}
