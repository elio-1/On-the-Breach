using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
// Define the conditions in which a dialogue start
public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue and player Ref")]
    [SerializeField] private DialogueStringSO dialogueStringsSO;
    [SerializeField] private GameObject playerGameObject;
    [Header("Start and tigger opt")]
    [SerializeField] private bool isTriggeredOnStart;
    [SerializeField] private bool canBeTriggeredMultipleTimes;
    [SerializeField] private bool isActiveAtStart = false;
    private GameManager gameManager;
    public List<Button> buttonsToDisable = new List<Button>() ;
    private bool hasAlreadyBeenSaid = false;
    private Player player;
    public AudioSource audioSource;
    [Header("Events")]
    public UnityEvent startEvent;
    public UnityEvent endEvent;
    [Header("Optional text window")]
    public GameObject textWindow;


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
        audioSource = GetComponent<AudioSource>();
        gameObject.SetActive(isActiveAtStart);
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
                gameObject.SetActive(true);
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
        if(audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}