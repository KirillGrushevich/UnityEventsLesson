using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LagasyInputControler : MonoBehaviour
{
    [SerializeField] private Transform Playertransform;

    [SerializeField] private Transform aimTransform;

    [SerializeField] private GameObject BulletPrefab;
    private bool jump;
    private bool shot;

    // Update is called once per frame
    void Update()
    {
        var pos = Playertransform.position;
        pos.x = Input.GetAxis("Horizontal");
        Playertransform.position = pos;
        if (Input.GetButtonDown("Jump"))
        {
            var jumpSec = DOTween.Sequence();
            jumpSec.Append(Playertransform.DOJump(pos, 1, 1, 0.3f));
            jump = true;
            jumpSec.OnComplete(() => { jump = false; });
        }

        if (!Input.GetKey(KeyCode.W))
        {
            aimTransform.gameObject.SetActive(false);
            return;
        }

        aimTransform.gameObject.SetActive(true);
        var dir = Input.GetAxis("Mouse X");
        pos = aimTransform.position;
        pos.x += dir * Time.deltaTime * 5f;
        pos.x = Mathf.Clamp(pos.x, -1f, 1f);
        aimTransform.position = pos;
        if (!Input.GetMouseButtonDown(0) || shot)
        {
            return;
        }

        var Obj = Instantiate(BulletPrefab, aimTransform.position, Quaternion.identity);
        shot = true;
        var shotSec = DOTween.Sequence();
        shotSec.Append(Obj.transform.DOMoveZ(10f, 1f));
        shotSec.OnComplete(() =>
        {
            Destroy(Obj);
            shot = false;
        });
    }
}
