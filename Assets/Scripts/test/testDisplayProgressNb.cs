using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testDisplayProgressNb : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] TMP_Text text;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // text = gameObject.GetComponent<TMP_Text>();
    }
    void Update()
    {
        text.text = player.storyProgress.ToString();
    }


}
