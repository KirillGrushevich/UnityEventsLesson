using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LegacyInputController : MonoBehaviour
{
    [SerializeField]
    private Transform cubeTransform;
    [SerializeField]
    private Transform aimTransform;
    [SerializeField]
    private GameObject bulletPrefab;

    private bool jump;
    private bool shot;

    private void Update()
    {
        var pos = cubeTransform.position;
        pos.x = Input.GetAxis("Horizontal");
        cubeTransform.position = pos;

        if (Input.GetButtonDown("Jump"))
        {
            var jumpSequence = DOTween.Sequence();
            jumpSequence.Append(cubeTransform.DOJump(pos, 1.0f, 1, 0.3f));
            jump = true;
            jumpSequence.OnComplete(() => { jump = false; });
        }

        if (!Input.GetKey(KeyCode.W))
        {
            aimTransform.gameObject.SetActive(false);
            return;
        }

        aimTransform.gameObject.SetActive(true);
        
        var direction = Input.GetAxis("Mouse X");
        pos = aimTransform.position;
        pos.x += direction * Time.deltaTime * 5.0f;
        pos.x = Mathf.Clamp(pos.x, -1.0f, 1.0f);
        aimTransform.position = pos;

        if (!Input.GetMouseButtonDown(0) || shot)
        {
            return;
        }

        var bullet = Instantiate(bulletPrefab, aimTransform.position, Quaternion.identity);
        shot = true;
        var shotSequence = DOTween.Sequence();
        shotSequence.Append(bullet.transform.DOMoveZ(10.0f, 1.0f));
        shotSequence.OnComplete(() => 
            { 
                Destroy(bullet);
                shot = false; 
            });
    }
}
