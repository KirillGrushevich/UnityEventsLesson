using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private float money = 20f;
        [SerializeField] private Text text;

        private void Start()
        {
            ResetText();
        }

        public bool TryAddItem(Item item)
        {
            if (money >= item.Cost)
            {
                item.isSold = true;
                money -= item.Cost;
                ResetText();
                return true;
            }

            item.isSold = false;
            return false;
        }

        private void ResetText()
        {
            text.text = $"Money: {money}";
        }
        
    }
}