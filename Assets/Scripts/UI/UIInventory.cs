using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInventory : MonoBehaviour
{
    [SerializeField] UIInvetoryItem itemPrefab;
    [SerializeField] RectTransform rectTransform;
    List<UIInvetoryItem> itemsList = new List<UIInvetoryItem>();

    public void GenerateInventory(List<ItemSO> inventoryList)
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            UIInvetoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.InitializeItem(inventoryList[i]);
            uiItem.transform.SetParent(rectTransform);
            uiItem.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            itemsList.Add(uiItem);
        }
    }
}
