using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int storyProgress;
    public PlayerData(Player player)
    {
        storyProgress = player.storyProgress;
    }
}
