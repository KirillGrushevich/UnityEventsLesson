using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Image image;
    [SerializeField] private int Cost;
    [SerializeField] private Text money;

    public void PotentialDrag() { image.color = Color.red; }
    public void BeginDrag() { transform.localScale = Vector3.one * 1.3f; }
    public void EndDrag() { transform.localScale = Vector3.one; }

    public void Drop()
    {
        image.color = Color.white;
        var panel = transform.parent.parent;
        if ((Convert.ToInt32(money.text) - Cost < 0) ||
            (panel.right.x - panel.localScale.x < image.transform.position.x))
            image.transform.localPosition = Vector3.zero;
        else money.text = (Convert.ToInt32(money.text) - Cost).ToString();
    }

    public void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
    }
}
