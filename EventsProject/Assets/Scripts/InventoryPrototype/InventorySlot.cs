using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public enum InventoryOwner
{
    Player, Shop
}
public class InventorySlot : MonoBehaviour, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryOwner SlotOwner;
    
    [SerializeField] private Item itemInSlot;
    [SerializeField] private Image slotItem;

    public bool IsSlotEmpty => itemInSlot == null;

    private void Reset()
    {
        slotItem = transform.GetChild(0).GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        slotItem.sprite = item.ItemSprite;
        itemInSlot = item;
    }

    public void RemoveItem()
    {
        slotItem.sprite = null;
        itemInSlot = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsSlotEmpty)
            return;
        
        DragManager.Instance.OnItemBeginDrag(itemInSlot, this);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if(!IsSlotEmpty)
            DragManager.Instance.OnItemDrag();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragManager.Instance.OnItemEndDrag();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (Player.Instance.BuyItem(itemInSlot.ItemPrice))
        {
            SetItem(DragManager.CurrentDraggedItem);
            DragManager.Instance.OnItemDragged(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotItem.transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotItem.transform.DOScale(Vector3.one, 0.3f);
    }
}
