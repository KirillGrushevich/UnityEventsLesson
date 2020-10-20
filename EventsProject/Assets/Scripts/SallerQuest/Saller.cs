using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Saller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image _item;
    [SerializeField] private Camera camera;
    [SerializeField] private SallerManager _manager;

    private Sequence _sequence;
    private Vector3 _defaultPos;
    private string _name;

    public Sprite Img
    {
        get => _item.sprite;
    }
    public void Setup(Sprite sprite, string name)
    {
        _item.sprite = sprite;
        _name = name;
    }

    public void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        _defaultPos = pos;
        pos.z = 0f;
        Debug.Log(pos);
        transform.position = pos;
    }

    public void EndDrag()
    {
        transform.localScale = Vector3.one;
    }

    public void Drop()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        switch (_name)
        {
            case "Player":
            {
                if (pos.x > 0 && _manager.Buy(this, _name))
                {
                    Destroy(gameObject);
                }
                transform.position = _defaultPos;
                break;
            }
            case "Saller":
            {
                if (pos.x < 0 && _manager.Buy(this, _name))
                {
                    Destroy(gameObject);
                }

                transform.position = _defaultPos;
                break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _sequence?.Kill();

        _sequence.Append(transform.DOScale(Vector3.one * 2f, 1f))
            .Append(transform.DOScale(Vector3.one, 1f));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _sequence?.Kill();
        transform.DOScale(Vector3.one, 0.3f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.3f, 0.3f);
    }
}
