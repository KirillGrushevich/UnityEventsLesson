using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    public float Cost = 10f;
    [SerializeField] private Camera camera;
    [SerializeField] private PanelController Byer2Dobject;
    [SerializeField] private GameObject parentUI;
    
    private Vector3 startPosition;
    private Vector3 startScale;
    
    [HideInInspector]public bool isSold;
    private bool isDrag;

    private void Start()
    {
        startScale = transform.localScale;
    }

    public void Enter()
    {
        transform.DOScale( startScale * 2, 0.3f);
    }

    public void Exit()
    {
        transform.DOScale(startScale, 0.3f);
    }

    public void BeginDrag()
    {
        isDrag = true;
        startPosition = transform.position;
        Byer2Dobject.StartDrag(this);
    }

    public void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
    }

    public void EndDrag()
    {
        Byer2Dobject.EndDrag();

        if (isSold)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(startScale * 2, 1f));
            sequence.Append(transform.DOScale(startScale, 1f));
           transform.SetParent(parentUI.transform);
        }
        else
        {
            transform.DOMove(startPosition, 1f);
        }

        isDrag = false;
    }
}
