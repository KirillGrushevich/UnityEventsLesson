using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemsList", menuName = "Inventory/NewItemsList")]
public class ItemsList : ScriptableObject
{
    public List<Item> items = new List<Item>();
}

[System.Serializable]
public class Item
{
    public Sprite ItemSprite;
    public int ItemPrice;
}
