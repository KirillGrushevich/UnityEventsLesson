using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Sprite emptySprite;
    public Sprite currentSprite;
    public bool isEmpty = true;

    [SerializeField] private SpriteShop spriteShop;
    
    public event Action<Item> OnDrag;

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

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!isEmpty)
        {
            OnDrag?.Invoke(this);
        }
    }
}
