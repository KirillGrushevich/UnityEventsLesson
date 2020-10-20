﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IPointerScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        image.DOColor(new Color(1, 0.9f, 0.9f, 1f), 0.3f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.DOColor(Color.white,  0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.3f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
