using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWindow : MonoBehaviour
{
    [SerializeField] public TMP_Text textHolder;
    // add more buttons options
    [SerializeField] public Button optionButton1;
    [SerializeField] public Button optionButton2;
    [SerializeField] public GameObject buttonHolder;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
    }
}
