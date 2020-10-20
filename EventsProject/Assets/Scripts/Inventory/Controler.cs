using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeController : MonoBehaviour
{
    public Item[] ItemsArray;
    public int PlayerMoney = 1000;

    public int TraderMoney = 1000;
    private Item _draggedItem;
    private Vector3 offset;
    [SerializeField] Camera camera;

    private void OnEnable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDrag += Drag;
        }
    }

    private void OnDisable()
    {
        foreach (var item in ItemsArray)
        {
            item.OnDrag -= Drag;
        }
    }

    public void Drag (Item draggedItem)
    {
        Debug.Log("dragging");
        _draggedItem = draggedItem;
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        pos += offset;
        
        _draggedItem.transform.position = pos;
    }
}