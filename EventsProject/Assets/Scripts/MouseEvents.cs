using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseEvents : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private Vector3 offset;

    private void OnMouseEnter()
    {
        transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    private void OnMouseOver()
    {
        transform.DORotate(Time.deltaTime * 90.0f * Vector3.forward, 0.25f, RotateMode.LocalAxisAdd);
    }

    private void OnMouseExit()
    {
        transform.DOScale(Vector3.one, 0.3f);
    }

    private void OnMouseDown()
    {
        var position = camera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0.0f;
        offset = transform.position - position;

        transform.DOScale(Vector3.one * 1.5f, 0.3f);
    }

    private void OnMouseDrag()
    {
        var position = camera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0.0f;
        offset = transform.position - position;
        offset += offset;
        transform.position = position;
    }

    private void OnMouseUp()
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Click");
    }
}
