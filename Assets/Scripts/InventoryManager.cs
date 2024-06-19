using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemSO> inventory = new List<ItemSO>();
    [SerializeField] private UIInventory inventoryUI;
    void Start()
    {
        inventoryUI.GenerateInventory(inventory);
    }
    
}
