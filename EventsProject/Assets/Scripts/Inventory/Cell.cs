using System;
using System.IO.Pipes;
using UnityEngine;

namespace Inventory
{
    public class Cell : MonoBehaviour
    {
        public int InventoryId
        {
            get => inventoryId;
            set => inventoryId = value;
        }
        [SerializeField] private GameObject cellItem;

        [SerializeField] private bool isCell;
    
        private int inventoryId = 0;
        
        
        public bool SetupCell(Transform item)
        {
            if (isCell) return false;

            item.position = transform.position;
            item.SetParent(transform);
            cellItem = item.gameObject;
            isCell = true;
            if (GetInventoryItemId() == inventoryId)
            {
                SetInventoryItemId(inventoryId);
            }
            else
            {
                
            }

            return true;
        }

        public void RemoveItem()
        {
            cellItem = null;
            isCell = false;
          
        }

        private void SetInventoryItemId(int id)
        {
            cellItem.GetComponent<Item>().ItemInf.inventoryId = id;
        }
        private int GetInventoryItemId()
        {
            return cellItem.GetComponent<Item>().ItemInf.inventoryId ;
        }
        
    
    }
}
