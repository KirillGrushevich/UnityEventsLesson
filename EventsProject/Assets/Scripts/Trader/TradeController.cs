using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeController : MonoBehaviour
{
    public Item[] ItemsArray;
    public int PlayerMoney = 100;

    public int TraderMoney = 100;
    private Item _draggedItem;
    private Vector3 offset;
    [SerializeField] Camera camera;

    private void OnEnable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDragEvent += DragEvent;
        }
    }

    private void OnDisable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDragEvent -= DragEvent;
        }
    }

    public void DragEvent (Item draggedItem)
    {
        _draggedItem = draggedItem;
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        pos += offset;
        
        _draggedItem.transform.position = pos;
    }

    public void StartDrag(Item draggedItem)
    {
        
    }

    public void EndDrag(Item draggedItem)
    {
        
    }
}
