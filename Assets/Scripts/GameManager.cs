using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        player.inventory = playerData.inventory;
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

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        LoadPlayer();
    }
}
