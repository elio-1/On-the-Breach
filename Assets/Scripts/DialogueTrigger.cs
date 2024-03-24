using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Define the conditions in which a dialogue start
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueStringSO dialogueStringsSO;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private bool isTriggeredOnStart;
    [SerializeField] private bool canBeTriggeredMultipleTimes;
    private GameManager gameManager;
    public List<Button> buttonsToDisable = new List<Button>() ;
    private bool hasAlreadyBeenSaid = false;
    private Player player;
    public AudioSource audioSource;
    // public bool disableAtTheEnd = false;

    public void OnButtonPress()
    {
        StartTheDialogue();
        StoryProgress();
    }
    public void OnButtonPressChangePage(int page)
    {
        StartDialoguePage(page);
        StoryProgress();
    }
    void Start()
    {
        if(isTriggeredOnStart)
        {
            StartTheDialogue();
        }
        player = playerGameObject.GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
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

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}