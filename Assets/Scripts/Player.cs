using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.SceneManagement;

// this player is the one attatch to a game object in the sccene
public class Player : MonoBehaviour
{
    // at what page in the story the player is
    public int storyProgress = 0;
    public int currentScene = 0;
    public List<string> inventory = new List<string>(); 
    
    private void Awake() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);
    }

    // record at what the page the player is currently in
    public void ProgressStory()
    {
        storyProgress += 1;
    }

    public void AddItem(ItemSO itemSo)
    {
        inventory.Add(itemSo.itemName);
    }
}
