using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

// handle the dialogues 
public class DialogueManager : MonoBehaviour
{
     [Header("Text Holder")]
    [SerializeField] private GameObject textPoppa;
    private TextWindow textWindow;
    private TMP_Text textHolder;
    private Button optionButton1;
    private Button optionButton2;
    private GameObject buttonHolder;
     [Header("Text defilement")]
    [SerializeField] private float textDisplaySpeed = 0.09f;
    [SerializeField] private float spamClickTimer = 0.1f;
    [Header("Audio")]
    [SerializeField] List<AudioClip> sylableAudioList = new List<AudioClip>();
    [SerializeField] AudioSource audioSource;
    [SerializeField] private bool areAudioSylablesRndom = true;
    [SerializeField] private int howmanyLettersAudio = 1;
    private bool doesThatLineContainAudio = false;

    private DialogueTrigger currentDialogueGameobject;

    private List<DialogueString> dialogueList;
    private List<Button> interactibleObjectList;

    private int currentDialogueIndex = 0 ;

    private bool optionSelected = false;
    private bool instantTextDisplay = false;
    private bool instantTextDisplayCD = false;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        // display the text instaniously if input from player
        
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (instantTextDisplayCD)
            { 
                instantTextDisplay = !instantTextDisplay;
            }
        }
    }

    // this function is called by DialogueTrigger which is attach to a gameobject in the scene and a trigger
    public void DialogueStart(List<DialogueString> dialogueString, List<Button> buttonList, GameObject gameObject)
    {
        interactibleObjectList = buttonList;
        currentDialogueGameobject = gameObject.GetComponent<DialogueTrigger>();
        // change the textPoppa if the Dialogue trigger has a special one for cool effects
        if(currentDialogueGameobject.textWindow != null)
        {
            textPoppa = currentDialogueGameobject.textWindow;
        }
        // Set the text box and variables
        textWindow = textPoppa.GetComponent<TextWindow>();  
        SetTextHolderVar(textWindow);
        textPoppa.SetActive(true);

        if(currentDialogueGameobject.isItemCondActive)
        {
            currentDialogueGameobject.startItemEvent?.Invoke();
        }
        else
        {
            currentDialogueGameobject.startEvent?.Invoke();
        }

        // check if the SO is for an object or a dialogue
        currentDialogueIndex = 0;
        dialogueList = dialogueString;

        IsButtonListClickable(false, interactibleObjectList);
        DisplayAnswerButtons(false);
        StartCoroutine(DisplayDialogue());
    }
#region DisplayDialogue
    private IEnumerator DisplayDialogue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            DialogueString line = dialogueList[currentDialogueIndex];

            instantTextDisplayCD = false;
            StartCoroutine(SpamClickTimer());

            // check if this line contain audio, if it does, play it instead of the sylable audio
            doesThatLineContainAudio = false;
            if (line.audioClip != null){
                currentDialogueGameobject.PlayAudioClip(line.audioClip);
                doesThatLineContainAudio = true; 
            }   

            if (line.isQuestion)
            {
                yield return StartCoroutine(TypeText(line.text));

                DisplayAnswerButtons(true);

                optionButton1.GetComponentInChildren<TMP_Text>().text = line.answerOption1;
                optionButton2.GetComponentInChildren<TMP_Text>().text = line.answerOption2;

                optionButton1.onClick.AddListener(() => HandleOptionSelected(line.option1IsSelectedJumpToIndex));
                optionButton2.onClick.AddListener(() => HandleOptionSelected(line.option2IsSelectedJumpToIndex));

                yield return new WaitUntil(() => optionSelected);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));
            }
            // line.endEvent?.Invoke();
            optionSelected = false;
        }
    
        DialogueStop();
    }
    private void DisplayAnswerButtons(bool isActive)
    {
        buttonHolder.SetActive(isActive);
        // Show buttons but not interactible
        // optionButton1.interactable(isActive);
        // optionButton2.interactable(isActive);
    }

    // type each char in the current line in the dialogue
    private IEnumerator TypeText(string lineText)
    {
        int indexAudioSylable = 0;
        int letterCounter = 0;
        textHolder.text = "";
        foreach (char letter in lineText.ToCharArray())
        {
            letterCounter += 1;
            if (instantTextDisplay)
            {
                textHolder.text += letter;
            }
            else
            {
                // Audio : dont play audio if SAM is talking
                if (!doesThatLineContainAudio)
                {
                    // Audio : play a sound each char if howmanyLettersAudio is set to 1
                    if (letterCounter == howmanyLettersAudio)
                    {
                        audioSource.clip = sylableAudioList[indexAudioSylable];
                        audioSource.Play();
                        // if 
                        indexAudioSylable = areAudioSylablesRndom ? Random.Range(0, sylableAudioList.Count - 1) : indexAudioSylable++ ;
                        if (indexAudioSylable > sylableAudioList.Count -1)
                        {
                            indexAudioSylable = 0;
                        }
                        letterCounter = 0;
                    }
                }
                textHolder.text += letter;
                yield return new WaitForSeconds(textDisplaySpeed);
            }
        } 
        
        if (!dialogueList[currentDialogueIndex].isQuestion)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"));
        }

        if (dialogueList[currentDialogueIndex].isEndOfDialogue)
        {
            DialogueStop();
        }

        currentDialogueIndex++;
    } 
#endregion
    // Navigate in the current dialogue to the right dialogue line 
    private void HandleOptionSelected(int jumpIndex)
    {
        optionSelected = true;
        DisplayAnswerButtons(false);
        currentDialogueIndex = jumpIndex;
    }

    private void DialogueStop()
    {
        StopAllCoroutines();
        textHolder.text = "";
        textPoppa.SetActive(false);
        IsButtonListClickable(true, interactibleObjectList);
        
        currentDialogueGameobject.CanBeTriggeredAgain();

        if(currentDialogueGameobject.isItemCondActive)
        {
            currentDialogueGameobject.endItemEvent?.Invoke();
        }
        else
        {
            currentDialogueGameobject.endEvent?.Invoke();
        }
        currentDialogueGameobject = null;
    }
    private void IsButtonListClickable(bool isClickable, List<Button> buttonList)
    {
        foreach (Button button in buttonList)
        {
            button.interactable = isClickable;
        }
    }

    private IEnumerator SpamClickTimer()
    {
        instantTextDisplayCD = false;
        yield return new WaitForSeconds(spamClickTimer);
        instantTextDisplayCD = true;
    }
    private void SetTextHolderVar(TextWindow textWindow)
    {
    textHolder = textWindow.textHolder;
    optionButton1 = textWindow.optionButton1;
    optionButton2 = textWindow.optionButton2;
    buttonHolder = textWindow.buttonHolder;
    }
}
