using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour {

    [SerializeField] private Camera _camera;
    [SerializeField] private Image _image;

    public void PotentialDrag() {
        _image.color = Color.red;
    }

    public void BeginDrag() {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void Drag() {
        var position = _camera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;
    }

    public void EndDrag() {
        transform.localScale = Vector3.one;
    }

    public void Drop() {
        _image.color = Color.white;
    }

    public void Scroll() {
        Debug.Log("Scroll");
    }
}
