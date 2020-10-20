using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LegacyInputController : MonoBehaviour {
    
    [SerializeField] private Transform _cubeTransform;
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private GameObject _bulletPrefab;

    private bool jump;
    private bool shoot;

    private void Update() {
        var position = _cubeTransform.position;
        position.x = Input.GetAxis("Horizontal");
        _cubeTransform.position = position;

        if (Input.GetButtonDown("Jump") && jump == false) {
            var jumpSequence = DOTween.Sequence();
            jumpSequence.Append(_cubeTransform.DOJump(position, 1f, 1, 0.3f));
            jump = true;
            jumpSequence.OnComplete(() => { jump = false; });
        }

        if (Input.GetKey(KeyCode.W) == false) {
            _aimTransform.gameObject.SetActive(false);
            return;
        }

        _aimTransform.gameObject.SetActive(true);

        var direction = Input.GetAxis("Mouse X");
        position = _aimTransform.position;
        position.x += direction * Time.deltaTime * 5f;

        position.x = Mathf.Clamp(position.x,-1, 1);

        _aimTransform.position = position;

        if (Input.GetMouseButton(0) == false || shoot) {
            return;
        }

        var obj = Instantiate(_bulletPrefab, _aimTransform.position, Quaternion.identity);
        shoot = true;

        var shootSequence = DOTween.Sequence();
        shootSequence.Append(obj.transform.DOMoveZ(10f, 1f));
        shootSequence.OnComplete(() => {
            Destroy(obj);
            shoot = false;
        });
    }
}
