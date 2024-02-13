using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public List<DialogueStringSO> dialogueStringList = new List<DialogueStringSO>();
    
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

    // change the page number of the player
    // if you want to go the the next page you'll need to get the current page + 1 
    public void ChangePageNumber(int page)
    {
        player.storyProgress = page;
    }
    public DialogueStringSO ChangeDialogueStringSO(int page){
        ChangePageNumber(page);
        return dialogueStringList[page];
    }
}
