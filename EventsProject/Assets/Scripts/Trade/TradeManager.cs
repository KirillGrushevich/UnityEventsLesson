using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    public static TradeManager instance = null;
    
    public RectTransform playerBag;
    public RectTransform traderBag;
    public List<Cell> traderCells;
    public List<Cell> playerCells;
    public MoneyController moneyController;
    
    void Start () {
        if (instance == null) { 
            instance = this; 
        } else if(instance == this){ 
            Destroy(gameObject); 
        }
    }

    //the worst implementation
    public Cell FindClosestCell(DragItem target)
    {
        Cell closestCell = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = target.Rect.position;

        float distToTrader = Vector3.Distance(traderBag.position, currentPos);
        float distToPlayer = Vector3.Distance(playerBag.position, currentPos);

        var targetCells = distToPlayer<distToTrader ? playerCells : traderCells;
        
        foreach (var cell in targetCells)
        {
            float dist = Vector3.Distance(cell.Rect.position, currentPos);
            if (dist < minDist)
            {
                closestCell = cell;
                minDist = dist;
            }
        }

        if (closestCell!=null && target.Type!=closestCell.ItemType)
        {
            if (moneyController.GetMoneyByType(closestCell.ItemType)>=target.Cost)
            {
                moneyController.AppendMoney(closestCell.ItemType, -target.Cost);
                return closestCell;
            }

            return null;
        }

        return closestCell;

    }
}
