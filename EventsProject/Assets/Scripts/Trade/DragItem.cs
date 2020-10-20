using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Camera camera;
    [SerializeField] private RectTransform rect;
    [SerializeField] private ItemType type;
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI _costText;

    public RectTransform Rect => rect;
    public ItemType Type => type;
    public int Cost => cost;
    
    private Vector2 lastMousePosition;
    private Vector2 startItemPosition;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        _costText.text = cost.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startItemPosition = rect.position;
        lastMousePosition = eventData.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
 
        Vector3 newPosition = rect.position +  new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        lastMousePosition = currentMousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        var result = TradeManager.instance.FindClosestCell(this);
        if (result!=null)
        {
            type = result.ItemType;

            transform.DOMove(result.Rect.position, 0.05f).OnComplete(() =>
            {
                transform.DOScale(Vector3.one * 1.3f, 0.1f).OnComplete(() =>
                {
                    transform.DOScale(Vector3.one, 0.1f);
                });
            });
        }
        else
        {
            transform.DOMove(startItemPosition, 0.05f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.1f, 0.05f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.05f);
    }
}
