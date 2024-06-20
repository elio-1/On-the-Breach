using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemSO> inventory = new List<ItemSO>();
    public UIInventory inventoryUI;
    void Start()
    {
        inventoryUI.GenerateInventory(inventory);
    }
    public void ClearInventory()
    {
        // Debug.Log("Attempting to clear inventory...");
        inventory.Clear();
        inventoryUI.itemsList.Clear();
        // Debug.Log("You have : " + inventory.Count + " -- ui -- " + inventoryUI.itemsList.Count + "in your inventory");
    }
    public void AddItem(ItemSO itemSO)
    {
        inventory.Add(itemSO);
    }
}
