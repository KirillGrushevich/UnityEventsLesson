using System;
using UnityEngine;

namespace Inventory
{
    public static class EventManager
    {
        public static Action<int, int> OnBuy;

        public static void Buy(int id, int price)
        {
            OnBuy?.Invoke(id,price);
        }

    }
}
