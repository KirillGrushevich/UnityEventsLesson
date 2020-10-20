using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private CustomItem currentItem;
    [SerializeField] private Image image;
    [SerializeField] private Text itemPriceText;
    private Camera _camera;
    
    private Vector3 _startPosition;
    private Vector3 _offset;
    
    private readonly Vector3 _onHoverSize = new Vector3(0.8f, 0.8f, 1);
    private readonly Vector3 _normalSize = new Vector3(1f, 1f, 1);
    private readonly Vector3 _dragSize = new Vector3(1.2f, 1.2f, 1);
    private bool _isDrag = false;

    public event Action OnItemPicked;
    public event Action OnItemDroped;
    private void Start()
    {
        image.sprite = baseSprite;
        if (!(currentItem is null))
        {
            image.sprite = currentItem.image;
        }
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_isDrag)
        {
            MouseDrag();
        }

        int price = (currentItem is null) ? 0 : currentItem.price;
        itemPriceText.text = price.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.transform.DOScale(_onHoverSize, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.transform.DOScale(_normalSize, 0.3f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnItemPicked?.Invoke();
        
        _startPosition = transform.position;
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _offset = transform.position - pos;

        image.transform.DOScale(_dragSize, 0.3f);
        _isDrag = true;
    }

    private void MouseDrag()
    {
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos += _offset;

        transform.position = pos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnItemDroped?.Invoke();
        
        image.transform.DOScale(_normalSize, 0.3f);
        _isDrag = false;
        transform.position = _startPosition;
    }

    public void OffRaycast()
    {
        
    }
    
    public void OnRaycast()
    {
        
    }

}
