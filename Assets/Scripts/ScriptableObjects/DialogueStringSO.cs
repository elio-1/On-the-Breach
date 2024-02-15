using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues", order = 51)]
public class DialogueStringSO : ScriptableObject
{
    public int pageNumber;
    public List<DialogueString> dialogueStringsList = new List<DialogueString>();
}