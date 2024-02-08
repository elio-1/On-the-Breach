using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueStringSO dialogueStringsSO;
    [SerializeField] private GameObject player;
    [SerializeField] private bool isTriggeredOnStart;
    [SerializeField] private bool canBeTriggeredMultipleTimes;
    public List<Button> buttonsToDisable = new List<Button>() ;
    [SerializeField] private bool hasAlreadyBeenSaid = false;

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
                player.GetComponent<DialogueManager>().DialogueStart(dialogueStringsSO.dialogueStringsList, buttonsToDisable, gameObject);
                hasAlreadyBeenSaid = true;
            }
        
    }
    public void CanBeTriggeredAgain()
    {
        hasAlreadyBeenSaid = !canBeTriggeredMultipleTimes;
    }
}