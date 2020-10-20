using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetCkiker : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private Image _image;
    private Action OnPlanetClick;

    public void Setup(Sprite sprite, Action onClickCallBack)
    {
        _image.color = Color.white;
        _image.sprite = sprite;
        OnPlanetClick = onClickCallBack;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnPlanetClick?.Invoke();
        _image.DOColor(Color.clear, 0.3f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.transform.DOScale(Vector3.one, 0.3f);
    }
}
