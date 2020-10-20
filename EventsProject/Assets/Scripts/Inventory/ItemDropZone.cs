using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemDropZone : MonoBehaviour, IDropHandler {
    
    public UnityEvent<Item> OnDropItem = new UnityEvent<Item>();
    
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            Item item = eventData.pointerDrag.GetComponent<Item>();
            if (item != null) {
                item.Owner.Sell(item);
                OnDropItem.Invoke(item);
            }
        }
    }
}
