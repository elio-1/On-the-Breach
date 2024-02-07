using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Event;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<DialogueString> dialogueStrings = new List<DialogueString>;
}
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
    public int answerOption1jumpIndex;
    public int answerOption2jumpIndex;

    // Events
    [Header("Trigger Events")]
    public UnityEvent startEvent;
    public UnityEvent endEvent;
}
