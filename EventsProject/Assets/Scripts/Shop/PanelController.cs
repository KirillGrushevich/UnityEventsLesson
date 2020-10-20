using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelController : MonoBehaviour
{
    [SerializeField] private Manager manager;

    private Item dragItem;
    private bool isOnPanel;
    
    private void OnMouseEnter()
    {
        isOnPanel = true;
    }

    private void OnMouseExit()
    {
        isOnPanel = false;
    }

    public void StartDrag(Item item)
    {
        dragItem = item;
    }
    
    public void EndDrag()
    {
        if (isOnPanel)
        {
            manager.TryAddItem(dragItem);
        }
        dragItem = null;
    }
}
