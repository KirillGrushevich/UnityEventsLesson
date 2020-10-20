using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DraggableItem : MonoBehaviour
{
    public Image ItemIcon;

    private void Reset()
    {
        ItemIcon = GetComponent<Image>();
    }
}
