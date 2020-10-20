using System;
using System.Linq;
using UnityEngine;

namespace Inventory
{
   public class InventoryController : MonoBehaviour
   {
      public int inventoryId = 0;
      public int money = 500;
      
      [SerializeField] private GameObject[] cells;
      private void OnEnable()
      {
         EventManager.OnBuy += Buy;
      }

      private void OnDisable()
      {
         EventManager.OnBuy -= Buy;
      }
      private void Start()
      {
         SetupInventory();
      }
      private void Buy(int id, int price)
      {
         if (inventoryId != id)
         {
            return;
         }

         money -= price;

      }
      private void SetupInventory()
      {
         for (int i = 0; i < cells.Length; i++)
         {
            cells[i].GetComponent<Cell>().InventoryId = inventoryId;
         }
      }
     
   }
}
