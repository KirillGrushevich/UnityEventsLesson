using System;
using System.Collections.Generic;

public class ShopInventory : Inventory
{
    private void Start() {
        _items = _items ?? new List<Item>();
    }

    public override void Initialize(Action<Item> onDrop) {
        _dropZone.OnDropItem.AddListener(item => onDrop(item));
    }
    
    public override void Add(Item item) {
        if (_items.Contains(item) == false) {
            _items.Add(item);
            item.transform.SetParent(_itemsPlace);
        }
    }

    public override void TryAdd(Item item) {
        if (_items.Contains(item))
            throw new InvalidOperationException("Cannot add item to inventory. Item already exists.");
        else {
            _items.Add(item);
            item.transform.SetParent(_itemsPlace);
        }
    }

    public override void Remove(Item item) {
        if (_items.Contains(item)) {
            _items.Remove(item);
        }
    }

    public override void TryRemove(Item item) {
        if (_items.Contains(item) == false)
            throw new InvalidOperationException("Cannot remove item from inventory. Item does not exists.");
        else _items.Remove(item);
    }
}
