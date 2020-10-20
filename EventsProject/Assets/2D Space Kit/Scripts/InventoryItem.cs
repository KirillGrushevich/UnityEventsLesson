using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Item item;
    private Image _image;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Sell parent = null;
    private Vector3 startDragPosition;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.sprite = SpriteStorage.instance.GetItemSprite(item);
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        startDragPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject currentRaycast = eventData.pointerCurrentRaycast.gameObject;
        if (currentRaycast == null)
        {
            MoveBack();
        }
        else if (currentRaycast.GetComponent<Sell>() == null)
        {
            MoveBack();
        }
        else
        {
            _canvasGroup.blocksRaycasts = true;
        }
    }

    public void MoveBack()
    {
        transform.DOMove(startDragPosition, 0.5f).SetEase(Ease.Linear)
            .OnComplete(() => _canvasGroup.blocksRaycasts = true);
    }

    public Sell GetParent()
    {
        return parent;
    }

    public void SetParent(Sell _parent)
    {
        parent = _parent;
    }

    public Item GetItem()
    {
        return item;
    }
}
