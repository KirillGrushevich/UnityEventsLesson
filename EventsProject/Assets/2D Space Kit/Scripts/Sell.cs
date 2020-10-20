using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Sell : MonoBehaviour, IDropHandler
{
    private Item item;
    private Image _image;
    [SerializeField] private Owner owner;

    public void SetItem(Item _item)
    {
        item = _item;
    }

    public void RemoveItem()
    {
        item = null;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
        int chance = Random.Range(0, 100);
        if (chance >=40)
        {
            GameObject itemObj = SpriteStorage.instance.item;
            InventoryItem inventoryItem = Instantiate(itemObj, itemObj.transform.parent, false).GetComponent<InventoryItem>();
            inventoryItem.transform.position = transform.position;
            inventoryItem.SetParent(this);
            _image.sprite = SpriteStorage.instance.GetSellSprite(SellType.Full);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            _image.sprite = SpriteStorage.instance.GetSellSprite(SellType.Full);
            Sell parent = eventData.pointerDrag.GetComponent<InventoryItem>().GetParent();
            if (parent != null)
            {
                parent._image.sprite = SpriteStorage.instance.GetSellSprite(SellType.Empty);
            }
            eventData.pointerDrag.GetComponent<InventoryItem>().SetParent(this);
        }
    }
}
