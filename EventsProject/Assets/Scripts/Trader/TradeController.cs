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
    private RectTransform startingPosition;
    [SerializeField] Camera camera;

    private void OnEnable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDragEvent += DragEvent;
            item.OnStartDragEvent += StartDrag;
            item.OnEndDragEvent += EndDrag;
        }
    }

    private void OnDisable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDragEvent -= DragEvent;
            item.OnStartDragEvent -= StartDrag;
            item.OnEndDragEvent -= EndDrag;
        }
    }

    public void DragEvent (Item draggedItem)
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        pos += offset;
        
        _draggedItem.transform.position = pos;
    }

    public void StartDrag(Item draggedItem)
    {
        _draggedItem = draggedItem;
    }

    public void EndDrag(Item draggedItem)
    {
        
    }
}
