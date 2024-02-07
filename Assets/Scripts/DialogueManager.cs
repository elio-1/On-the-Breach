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
    [SerializeField] private float textDisplaySpeed = 0.09f;

    private List<DialogueString> dialogueList;

    private int currentDialogueIndex = 0 ;

    private void Start()
    {
        textPoppa.SetActive(false);
    }

    public void DialogueStart(List<DialogueString> dialogueList)
    {

    }
}
