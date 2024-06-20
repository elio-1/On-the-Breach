using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public List<DialogueStringSO> dialogueStringList = new List<DialogueStringSO>();
    public InventoryHelperStringToSO inventoryHelperStringToSO;
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
        LoadInventory();
    }
    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        player.storyProgress = playerData.storyProgress;
        // list of string with the item name
        player.inventory = playerData.inventory;
        Debug.Log("Player inv: " + player.inventory.Count + "player inv (in data): " + playerData.inventory.Count);
        
    }
    public void NewGame()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        playerData.storyProgress = 0;
        Debug.Log("clearing inv...");
        player.inventory.Clear();
        playerData.inventory.Clear();
        // Debug.Log(player.inventory.Count);
        playerData.inventory = player.inventory; 
        Debug.Log(playerData.inventory.Count);
        SavePlayer();
        LoadPlayer();
        LoadInventory();
    }

    // change the page number of the player
    // if you want to go the the next page you'll need to get the current page + 1 
    public void ChangePageNumber(int page)
    {
        player.storyProgress = page;
    }

    // take the page number and change the dialogues list that store ALL the dialogues in the game
    public DialogueStringSO ChangeDialogueStringSO(int page){
        ChangePageNumber(page);
        return dialogueStringList[page];
    }

    public void ChangeLevel(string sceneName)
    {
        SavePlayer();
        if (sceneName == "+1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (int.TryParse(sceneName, out int sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex);
        }else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void LoadInventory()
    {
        // i want to give this data playerData.inventory
        // Debug.Log("Loading player data");
        inventoryHelperStringToSO.StringToItemSO(player.inventory);
        
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        LoadPlayer();
        //load inventory from player data!
        LoadInventory();
    }
}
