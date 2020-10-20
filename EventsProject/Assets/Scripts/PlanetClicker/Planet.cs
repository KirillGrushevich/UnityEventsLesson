using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Planet : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Image _imgae;

    private event Action OnPlanetClick;

    public void Setup(Sprite sprite, Action onClickCallback) {
        _imgae.color = Color.white;
        _imgae.sprite = sprite;
        OnPlanetClick = onClickCallback;
    }
    
    public void OnPointerClick(PointerEventData eventData) {
        OnPlanetClick?.Invoke();
        _imgae.DOColor(Color.clear, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        _imgae.transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        _imgae.transform.DOScale(Vector3.one, 0.3f);
    }
}
