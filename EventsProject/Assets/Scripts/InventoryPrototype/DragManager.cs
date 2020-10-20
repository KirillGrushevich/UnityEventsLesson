using UnityEngine;

public class DragManager : MonoBehaviour
{
    public static DragManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static InventorySlot SelectedInventorySlot;
    public static Item CurrentDraggedItem;
    
    public DraggableItem DraggableItem;

    public void OnItemBeginDrag(Item item, InventorySlot slot)
    {
        CurrentDraggedItem = item;
        SelectedInventorySlot = slot;
        DraggableItem.ItemIcon.sprite = item.ItemSprite;
    }
    
    public void OnItemDrag()
    {
        if (!DraggableItem.gameObject.activeSelf)
        {
            DraggableItem.gameObject.SetActive(true);
        }
        DraggableItem.transform.position = Input.mousePosition;
    }

    public void OnItemEndDrag()
    {
        DraggableItem.gameObject.SetActive(false);
    }

    public void OnItemDragged(bool isDragSuccessful)
    {
        if(isDragSuccessful)
            SelectedInventorySlot.RemoveItem();
        SelectedInventorySlot = null;
    }
}
