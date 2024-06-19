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

    [Header("Optional Dialogues")]
    [Tooltip("Dialogue that will trigger after the main dialogue is over, can be used to cycle new object descriptions")]

    [SerializeField] private List<DialogueStringSO> optionalDialoguesSO = new List<DialogueStringSO>();
    [Tooltip("set to true if you want that the last dialogue to repeat")]
    [SerializeField] private bool lockOnLastOptionalDialogue = false;

    [Header("Start and tigger opt")]
    [SerializeField] private bool isTriggeredOnStart;
    // can be triggered multiple time only repeat the first dialoguestring not the optional one
    [SerializeField] private bool canBeTriggeredMultipleTimes;
    [SerializeField] private bool isActiveAtStart = false;
    private GameManager gameManager;
    public List<Button> buttonsToDisable = new List<Button>() ;
    private bool hasAlreadyBeenSaid = false;
    private Player player;
    private int optionalDialoguesCounter = 0;
    public AudioSource audioSource;
    [Header("Events")]
    public UnityEvent startEvent;
    public UnityEvent endEvent;
    [Header("Optional text window")]
    public GameObject textWindow;
    private DialogueManager dialogueManager;
    [Header("Item Conditional Triggers"), Tooltip("Dialogue that will trigger if the player has the required item in his inventory")]
    [SerializeField] private ItemSO itemRequired;
    [SerializeField] private DialogueStringSO itemRequiredDialogues;
    public bool isRepeatableItemInteraction;
    public UnityEvent startItemEvent;
    public UnityEvent endItemEvent;
    [HideInInspector] public bool isItemCondActive = false;
    


    public void OnButtonPress()
    {
        if (itemRequired != null && DoesPlayerHabThis(itemRequired))
        {
            StartItemSpecificDialogue();
        }
        else if (!hasAlreadyBeenSaid || canBeTriggeredMultipleTimes)
        {
            StartTheDialogue(dialogueStringsSO.dialogueStringsList);
        }
        else if (optionalDialoguesSO != null)
        {
            OptionalDialogues();
        }
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
        dialogueManager = playerGameObject.GetComponent<DialogueManager>();
        player = playerGameObject.GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        if(isTriggeredOnStart)
        {
            StartTheDialogue(dialogueStringsSO.dialogueStringsList);
        }
    }
    private void StartTheDialogue(List<DialogueString> dialogueString)
    {
                gameObject.SetActive(true);
                dialogueManager.DialogueStart(dialogueString, buttonsToDisable, gameObject);
                hasAlreadyBeenSaid = true;
    }
    public void CanBeTriggeredAgain()
    {
        hasAlreadyBeenSaid = true;
    }
    public void StoryProgress()
    {
        player.ProgressStory();
    }
    private void StartDialoguePage(int page){
        if(!hasAlreadyBeenSaid)
            {
                dialogueManager.DialogueStart(gameManager.ChangeDialogueStringSO(page).dialogueStringsList, buttonsToDisable, gameObject);
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
    private void StartItemSpecificDialogue()
    {
        isItemCondActive = true;
        StartTheDialogue(itemRequiredDialogues.dialogueStringsList);
    }
    private void OptionalDialogues()
    {
        StartTheDialogue(optionalDialoguesSO[optionalDialoguesCounter].dialogueStringsList);
            optionalDialoguesCounter++;
            if (optionalDialoguesCounter >= optionalDialoguesSO.Count)
            {
                optionalDialoguesCounter = 0;
                if (lockOnLastOptionalDialogue && optionalDialoguesSO.Count > 0)
                {
                    optionalDialoguesCounter = optionalDialoguesSO.Count - 1;
                }
            }
    }
    private bool DoesPlayerHabThis(ItemSO item)
    {
        InventoryManager playerInventory = playerGameObject.GetComponent<InventoryManager>();
        return playerInventory.inventory.Contains(item);
    }
}