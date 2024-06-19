using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHelperStringToSO : MonoBehaviour
{
    public List<ItemSO> AvailableItems = new List<ItemSO>();
    public UIInventory uIInventory;
    public void StringToItemSO(List<string> itemsString)
    {
        Debug.Log("Starting search process");
        for (int i = 0; i < itemsString.Count; i++)
        {
            for (int k = 0; k < AvailableItems.Count; k++)
            {
                if(itemsString[i] == AvailableItems[k].itemName)
                {
                    Debug.Log("Loading", AvailableItems[k]);
                    uIInventory.AddItemToInventory(AvailableItems[k]);
                }
            }
        }
    }
}
