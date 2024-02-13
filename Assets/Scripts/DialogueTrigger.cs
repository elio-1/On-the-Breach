using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueStringSO dialogueStringsSO;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private bool isTriggeredOnStart;
    [SerializeField] private bool canBeTriggeredMultipleTimes;
    [SerializeField] private GameManager gameManager;
    public List<Button> buttonsToDisable = new List<Button>() ;
    [SerializeField] private bool hasAlreadyBeenSaid = false;
    private Player player;

    public void OnButtonPress()
    {
        StartTheDialogue();
        StoryProgress();
    }
    void Start()
    {
        if(isTriggeredOnStart)
        {
            StartTheDialogue();
        }
        player = playerGameObject.GetComponent<Player>();
    }
    private void StartTheDialogue()
    {
        if(!hasAlreadyBeenSaid)
            {
                playerGameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStringsSO.dialogueStringsList, buttonsToDisable, gameObject);
                hasAlreadyBeenSaid = true;
            }
        
    }
    public void CanBeTriggeredAgain()
    {
        hasAlreadyBeenSaid = !canBeTriggeredMultipleTimes;
    }
    public void StoryProgress()
    {
        player.ProgressStory();
    }
    private void StartDialoguePage(int page){
        if(!hasAlreadyBeenSaid)
            {
                playerGameObject.GetComponent<DialogueManager>().DialogueStart(gameManager.ChangeDialogueStringSO(page).dialogueStringsList, buttonsToDisable, gameObject);
                hasAlreadyBeenSaid = true;
            }
    }
}