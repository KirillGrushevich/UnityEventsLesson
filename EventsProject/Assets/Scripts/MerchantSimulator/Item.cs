using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(EventTrigger))]
public class Item : MonoBehaviour
{
    [SerializeField]
    private Transform rootTransform;
    [SerializeField]
    private EventTrigger eventTrigger;
    [SerializeField]
    private Image image;

    private Camera camera;
    private Transform initialParent;

    private void Reset()
    {
        eventTrigger = GetComponent<EventTrigger>();
        image = GetComponent<Image>();
    }

    private void Start()
    {
        RegisterCallback(EventTriggerType.BeginDrag, OnBeginDrag);
        RegisterCallback(EventTriggerType.Drag, OnDrag);
        RegisterCallback(EventTriggerType.EndDrag, OnEndDrag);
        RegisterCallback(EventTriggerType.InitializePotentialDrag, OnPotentialDrag);
    }

    private void RegisterCallback(EventTriggerType triggerType, 
                                  Action<PointerEventData> action)
    {
        var entry = new EventTrigger.Entry
            {
                eventID = triggerType
            };
        entry.callback.AddListener((data) => 
            { 
                action((PointerEventData)data);
            });
        eventTrigger.triggers.Add(entry);
    }

    private void OnPotentialDrag(PointerEventData data)
    {
        transform.DOScale(Vector3.one * 1.3f, 0.2f);
    }

    private void OnBeginDrag(PointerEventData data)
    {
        initialParent = transform.parent;
        transform.SetParent(rootTransform, true);
        camera = data.enterEventCamera;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one * 1.8f, 0.15f));
        sequence.Join(transform.DOShakeRotation(0.14f, 15.0f, 80, 80.0f, false));
    }

    private void OnDrag(PointerEventData data)
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;
        transform.position = pos;
    }

    private void OnEndDrag(PointerEventData data)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one, 0.15f));
        sequence.Join(transform.DOShakeRotation(0.2f, 10.0f, 25, 50.0f, false));
    }
}
