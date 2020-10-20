using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Inventory : MonoBehaviour {

    [SerializeField] protected List<Item> _items;
    [SerializeField] protected ItemDropZone _dropZone;

    [SerializeField] protected Transform _itemsPlace;
    
    public abstract void Initialize(Action<Item> onDrop);
    public abstract void Add(Item item);
    public abstract void TryAdd(Item item);
    public abstract void Remove(Item item);
    public abstract void TryRemove(Item item);
}
