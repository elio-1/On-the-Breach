using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Tilemaps;
public class UIInvetoryItem : MonoBehaviour
{
[SerializeField] Image itemImage;
[SerializeField] TMP_Text itemQuantity;
[SerializeField] UIInvetoryDescription uIInvetoryDescription;

public ItemSO item;

    public void InitializeItem(ItemSO itemSO)
    {
        item = itemSO;
        uIInvetoryDescription = GameObject.FindWithTag("InventoryDescription").GetComponent<UIInvetoryDescription>();
        itemImage.sprite = itemSO.itemSprite;
        itemQuantity.text = itemSO.itemCount.ToString();
    }
    public void OnClickButton()
    {
        uIInvetoryDescription.ChangeDescriptionContent(item);
    }
}
