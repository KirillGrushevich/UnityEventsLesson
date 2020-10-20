using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Sprite emptySprite;
    public Sprite currentSprite;
    public bool isEmpty = true;
    public int Cost = default;

    [SerializeField] private SpriteShop spriteShop;
    
    public event Action<Item> OnDragEvent;
    public event Action<Item> OnStartDragEvent;
    public event Action<Item> OnEndDragEvent;

    private void Awake()
    {
        emptySprite = spriteShop.SpriteItems[0];
        currentSprite = GetComponent<Image>().sprite;
        isEmpty = (currentSprite == spriteShop.SpriteItems[0]);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            OnDragEvent?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            OnStartDragEvent?.Invoke(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragEvent?.Invoke(this);
    }
}
