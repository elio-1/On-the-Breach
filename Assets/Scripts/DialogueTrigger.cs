using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<DialogueString> dialogueStrings = new List<DialogueString>();
    [SerializeField] private GameObject player;
    [SerializeField] private bool isTriggeredOnStart;
    private bool hasAlreadyBeenSaid = false;
    public void OnButtonPress()
    {
        StartTheDialogue();
    }
    void Start()
    {
        if(isTriggeredOnStart)
        {
            StartTheDialogue();
        }
    }
    private void StartTheDialogue()
    {
        if(!hasAlreadyBeenSaid)
            {
                player.GetComponent<DialogueManager>().DialogueStart(dialogueStrings);
                hasAlreadyBeenSaid = true;
            }
        
    }
}
// scriptable objects!!!!
[System.Serializable]
public class DialogueString
{
    public string text;
    public bool isEndOfDialogue; 

    [Header("Branch")]
    public bool isQuestion; 
    // change to an empty list where you can add answer in the editor with 4 max options
    public string answerOption1;
    public string answerOption2;
    public int option1IsSelectedJumpToIndex;
    public int option2IsSelectedJumpToIndex;

    // Events
    [Header("Trigger Events")]
    public UnityEvent startEvent;
    public UnityEvent endEvent;
}
