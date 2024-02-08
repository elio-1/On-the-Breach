using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }
    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        player.storyProgress = playerData.storyProgress;
    }
    public void NewGame()
    {
        player.storyProgress = 0;
    }
}
