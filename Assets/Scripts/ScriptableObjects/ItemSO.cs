using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items", order = 51)]

public class ItemSO : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public int itemCount;
}
