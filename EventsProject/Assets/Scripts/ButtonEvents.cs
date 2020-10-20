using DG.Tweening;
using UnityEngine;

public class ButtonEvents : MonoBehaviour {
    
    [SerializeField] private Transform _rotationImage;
    private Sequence _sequence;

    public void Select() {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void Deselect() {
        transform.localScale = Vector3.one;
    }

    public void UpdateSelected() {
        _rotationImage.Rotate(Time.deltaTime * 90f * Vector3.forward);
    }

    public void Move() {
        _sequence?.Kill();
        
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.2f));
        _sequence.Append(transform.DOScale(Vector3.one, 0.2f));
    }

    public void Submit() {
        Debug.Log("Submit");
    }

    public void Cancel() {
        Debug.Log("Cancel");
    }
}