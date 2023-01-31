using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScriptStart : MonoBehaviour
{
    [SerializeField]
    public GameObject[] gameobjects;
    
    [SerializeField]
    public int id;
    
    public void ScriptPhoto()
    {
        foreach (var gameobject in gameobjects)
        {
            if (gameobject is not null)
                gameobject.SetActive(true);
        }
        
        GameEvents.current.DialogEventTrigger(id);
    }
}
