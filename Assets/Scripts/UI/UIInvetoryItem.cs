using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIInvetoryItem : MonoBehaviour
{
[SerializeField] Sprite itemImage;
[SerializeField] TMP_Text itemQuantity;
public void InitializeItem(ItemSO itemSO)
{
    itemImage = itemSO.itemSprite;
    itemQuantity.text = itemSO.itemCount.ToString();
}
}
