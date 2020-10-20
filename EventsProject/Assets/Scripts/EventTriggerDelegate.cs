using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class EventTriggerDelegate : MonoBehaviour {
    
    [SerializeField] private EventTrigger _eventTrigger;

    public void Reset() {
        _eventTrigger = GetComponent<EventTrigger>();
    }

    private void Start() {
        var entry = new EventTrigger.Entry {
            eventID = EventTriggerType.PointerDown
        };
        entry.callback.AddListener((data) => {
            OnPointerDownDelegate((PointerEventData)data);
        });
        
        _eventTrigger.triggers.Add(entry);
    }

    private void OnPointerDownDelegate(PointerEventData data) {
        transform.localScale = Vector3.one * 1.3f;
    }

    private void Update() {
        if (EventSystem.current.IsPointerOverGameObject())
            Debug.Log("Pointer is over gameobject.");
    }
}
