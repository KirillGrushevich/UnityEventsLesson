using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Planet : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    private event Action OnPlanetClick;

    public void Setup(Sprite sprite, Action onClickCallBack)
    {
        image.sprite = sprite;
        image.color = Color.white;
        OnPlanetClick = onClickCallBack;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnPlanetClick?.Invoke();
        image.DOColor(Color.clear, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
