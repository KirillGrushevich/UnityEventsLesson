using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public Trader trader;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var item = eventData.pointerDrag.GetComponent<Item>();
            
            if (trader.money - item.cost >= 0)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position =
                    GetComponent<RectTransform>().position;

                eventData.pointerDrag.transform.SetParent(gameObject.transform);
                
                var previousOwner = eventData.pointerDrag.GetComponent<Item>().owner;
                
                trader.Deal(item.cost, previousOwner);
                item.owner = trader;
                item.Bought();
            }
            else
            {
                eventData.pointerDrag.GetComponent<Item>().ReturnToPreviousSlot();
            }
        }
        else
        {
            eventData.pointerDrag.GetComponent<Item>().ReturnToPreviousSlot();
        }
        
        eventData.pointerDrag.GetComponent<Image>().raycastTarget = true;
    }
}
