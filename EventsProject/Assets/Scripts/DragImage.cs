using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Image image;
    
    private void PotentialDrag()
    {
        image.color = Color.red;
    }

    private void BeginDrag()
    {
        transform.localScale = Vector3.one * 1.3f;
    }

    private void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;
        transform.position = pos;
    }
}
