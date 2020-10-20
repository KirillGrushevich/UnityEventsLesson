using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public void PointerEnter()
    {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void PointerExit()
    {
        transform.localScale = Vector3.one;
    }
}
