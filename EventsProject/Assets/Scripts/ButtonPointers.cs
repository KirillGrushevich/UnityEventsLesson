using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPointers : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
    
    [SerializeField] private Image _image;
    
    public void OnPointerDown(PointerEventData eventData) {
        _image.DOColor(new Color(1,0.9f,0.9f, 1), 0.3f);
    }

    public void OnPointerUp(PointerEventData eventData) {
        _image.DOColor(Color.white, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        transform.DOScale(Vector3.one * 1.3f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
