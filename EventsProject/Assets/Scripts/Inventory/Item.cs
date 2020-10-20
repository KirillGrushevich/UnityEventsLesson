using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Inventory
{
    public class Item : MonoBehaviour
    {
        public ItemInfo ItemInf
        {
            get => itemInfo;
            set => itemInfo = value;
        }
        
        private ItemInfo itemInfo;
        
        private Camera _camera;
   
        private Vector3 offset;

        private Cell current;
        private void Start()
        {
            _camera = Camera.main;
            ConnectToNear();
        }

        private void OnMouseEnter()
        {
            transform.DOScale(Vector3.one*1.3f, 0.3f);
        }
   
        private void OnMouseOver()
        {
            transform.Rotate(Time.deltaTime*90f*Vector3.forward);
        }
   
        private void OnMouseExit()
        {
            transform.DOScale(Vector3.one, 0.3f);
        }
   
        private void OnMouseDown()
        {
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            offset = transform.position - pos;
            transform.DOScale(Vector3.one *1.6f, 0.3f);
          
            
        }

        
        private void OnMouseDrag()
        {
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            pos += offset;
            transform.position = pos;

        }
   
        private void OnMouseUp()
        {
            transform.DOScale(Vector3.one *1.3f, 0.3f);
            ConnectToNear();
        }
        
        private void ConnectToNear()
        {
            var cells = GameObject.FindGameObjectsWithTag("Cell");
            var dist = cells.OrderBy(x =>
                Vector3.Distance(transform.position, x.transform.position) > 1f).First();
            if (dist != null)
            {
                var cell = dist.gameObject.GetComponent<Cell>();
                if (cell.SetupCell(transform))
                {
                    if(current!=null) current.RemoveItem();
                    current = cell;
                }
                else
                {
                    current.RemoveItem();
                    current.SetupCell(transform);
                }
            }
        }
    }
}
