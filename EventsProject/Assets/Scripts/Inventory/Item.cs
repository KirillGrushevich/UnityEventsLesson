using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, 
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public int cost = 100;

    public Trader owner;
    
    [SerializeField]
    private Transform previousParent;
    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private Image image;
    [SerializeField] 
    private Text costText;

    public void Awake()
    {
        image = GetComponent<Image>();
        costText = GetComponentInChildren<Text>();
        costText.text = cost.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        image.raycastTarget = false;
        transform.SetParent(canvas.transform);

        transform.DOScale(Vector3.one * 1.5f, 0.5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.5f);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOColor(Color.green, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOColor(Color.white, 0.5f);
    }

    public void Bought()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.yellow, 1f));
        sequence.Append(image.DOColor(Color.white, 1f));
    }
    
    public void ReturnToPreviousSlot()
    {
        transform.SetParent(previousParent);
        transform.position = previousParent.position;
    }
}
