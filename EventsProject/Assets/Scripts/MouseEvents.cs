using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private Vector3 offset;

    private void OnMouseEnter()
    {
        transform.DOScale(1.2f, 0.3f);
    }

    private void OnMouseOver()
    {
        transform.Rotate(Time.deltaTime * 90f * Vector3.forward);
    }

    private void OnMouseExit()
    {
        transform.DOScale(1f, 0.3f);
    }

    private void OnMouseDown()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        offset = transform.position - pos;

        transform.DOScale(1.5f, 0.3f);
    }

    private void OnMouseDrag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        pos += offset;

        transform.position = pos;
    }

    private void OnMouseUp()
    {
        transform.DOScale(1.2f, 0.3f);
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Click");
    }
}
