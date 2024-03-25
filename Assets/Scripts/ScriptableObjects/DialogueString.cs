using UnityEngine;
// using UnityEngine.Events;


[System.Serializable]
public class DialogueString 
{
    [TextArea(3,10)]
    public string text;
    public bool isEndOfDialogue; 

    [Header("Branch")]
    public bool isQuestion; 
    // change to an empty list where you can add answer in the editor with 4 max options
    public string answerOption1;
    public string answerOption2;
    public int option1IsSelectedJumpToIndex;
    public int option2IsSelectedJumpToIndex;

    // // Events
    // [Header("Trigger Events")]
    // public UnityEvent startEvent;
    // public UnityEvent endEvent; 
     [Header("Associated Audio")]
    public AudioClip audioClip;
}

