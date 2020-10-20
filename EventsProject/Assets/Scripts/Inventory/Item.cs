using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, 
    IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler {
    
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _root;

    [SerializeField] private float _cost;

    [SerializeField] public Owner _owner;
    
    public float Cost => _cost;
    
    private Transform _transform;

    private Transform _parent;
    private Image _image;
    
    private Vector3 _offset;

    public Owner Owner {
        get => _owner;
        set {
            if (_owner != null && _owner.Equals(value) == false) {
                _owner = value;
            }
        }
    }
    
    private void Start() {
        _parent = transform.parent;
        _transform = GetComponent<Transform>();
        
        _image = GetComponent<Image>();
        _camera = Camera.main;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.DOScale(Vector3.one, 0.2f);
    }

    public void OnPointerDown(PointerEventData eventData) {
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _offset = transform.position - pos;
    }
    
    public void OnPointerUp(PointerEventData eventData) {
        transform.DOScale(Vector3.one, 0.2f);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        transform.DOScale(Vector3.one * 1.4f, 0.2f);
    }

    public void OnDrag(PointerEventData eventData) {
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos += _offset;
        transform.position = pos;

        _image.DOColor(Color.green, 0.2f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        _image.DOColor(Color.white, 0.2f);
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
    }
}
