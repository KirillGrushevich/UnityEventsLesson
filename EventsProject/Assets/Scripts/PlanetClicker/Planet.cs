using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class Planet : 
    MonoBehaviour, 
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField]
    private Image image;

    private event Action OnPlanetClick;

    public void Setup(Sprite sprite, Action onClickCallback)
    {
        image.color = Color.white;
        image.sprite = sprite;
        OnPlanetClick = onClickCallback;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPlanetClick?.Invoke();
        image.DOColor(Color.clear, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
