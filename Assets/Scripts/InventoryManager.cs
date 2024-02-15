using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemSO> inventory = new List<ItemSO>();
    [SerializeField] private UIInventory inventoryUI;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        inventoryUI.GenerateInventory(inventory);
    }
}
