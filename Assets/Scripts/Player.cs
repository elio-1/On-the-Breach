using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // at what page in the story the player is
    public int storyProgress = 0;


    // record at what the page the player is currently in
    public void ProgressStory()
    {
        storyProgress += 1;
    }
}
