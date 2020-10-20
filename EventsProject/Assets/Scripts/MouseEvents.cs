using System;
using DG.Tweening;
using UnityEngine;

public class MouseEvents : MonoBehaviour {
    
    [SerializeField] private Camera _camera;
    private Vector3 _offset;

    private void OnMouseEnter() {
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
    }

    private void OnMouseOver() {
        transform.Rotate(Time.deltaTime * 90f * Vector3.forward);
    }

    private void OnMouseExit() {
        transform.DOScale(Vector3.one, 0.2f);   
    }

    private void OnMouseDown() {
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _offset = transform.position - pos;

        transform.DOScale(Vector3.one * 1.4f, 0.2f);
    }

    private void OnMouseDrag() {
        var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos += _offset;

        transform.position = pos;
    }
    
    private void OnMouseUp() {
        transform.DOScale(Vector3.one * 1.2f, 0.2f);
    }

    private void OnMouseUpAsButton() {
        Debug.Log("Click");
    }
}
