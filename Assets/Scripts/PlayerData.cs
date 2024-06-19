using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// store the player data, this class is saved in the save system
[System.Serializable]
public class PlayerData
{
    public int storyProgress;
    public int currentScene;
    public List<string> inventory = new List<string>(); 
    public PlayerData(Player player)
    {
        storyProgress = player.storyProgress;
        currentScene = player.currentScene;
        inventory = player.inventory;
    }
}
