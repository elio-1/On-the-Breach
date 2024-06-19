using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SetStuffsActiveNextButtonEnjoyer : MonoBehaviour
{
    [SerializeField] private List<GameObject> disableStuffs = new List<GameObject>();
    // Start is called before the first frame update
    public void OnClinkDisableStuffs(){
        for (int i = 0; i < disableStuffs.Count; i++)
        {
            disableStuffs[i].SetActive(false);
        }
    }
}
