using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject textPoppa;
    [SerializeField] private TMP_Text textHolder;
    // add more buttons options
    [SerializeField] private Button optionButton1;
    [SerializeField] private Button optionButton2;
    [SerializeField] private GameObject buttonHolder;
    [SerializeField] private float textDisplaySpeed = 0.09f;

    private List<DialogueString> dialogueList;

    private int currentDialogueIndex = 0 ;

    private bool optionSelected = false;

    private void Start()
    {
        textPoppa.SetActive(false);
    }

    public void DialogueStart(List<DialogueString> textToDisplay)
    {
        textPoppa.SetActive(true);
        dialogueList = textToDisplay;
        currentDialogueIndex = 0;
        DisplayAnswerButtons(false);
        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            DialogueString line = dialogueList[currentDialogueIndex];
            line.startEvent?.Invoke();
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
            line.endEvent?.Invoke();
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
    private IEnumerator TypeText(string lineText)
    {
        textHolder.text = "";
        foreach (char letter in lineText.ToCharArray())
        {
            textHolder.text += letter;
            yield return new WaitForSeconds(textDisplaySpeed);
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
    }
}
