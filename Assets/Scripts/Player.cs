using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int storyProgress = 0;

    public void ProgressStory()
    {
        storyProgress += 1;
    }
}
