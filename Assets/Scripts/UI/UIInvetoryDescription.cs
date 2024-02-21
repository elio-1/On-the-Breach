using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIInvetoryDescription : MonoBehaviour
{
[SerializeField] Image descriptionImage;
[SerializeField] TMP_Text descriptionTitle;
[SerializeField] TMP_Text descriptionTextContent;
ItemSO itemSO;
public void ChangeDescriptionContent(ItemSO item)
{

    itemSO = item;
    descriptionImage.sprite = itemSO.itemSprite;
    descriptionTitle.text = itemSO.itemName;
    descriptionTextContent.text = itemSO.itemDescription;
}
}
