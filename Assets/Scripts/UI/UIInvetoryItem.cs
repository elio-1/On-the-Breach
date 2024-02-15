using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIInvetoryItem : MonoBehaviour
{
[SerializeField] Image itemImage;
[SerializeField] TMP_Text itemQuantity;
public void InitializeItem(ItemSO itemSO)
{
    itemImage.sprite = itemSO.itemSprite;
    itemQuantity.text = itemSO.itemCount.ToString();
}
}
