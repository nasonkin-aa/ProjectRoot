using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public GameObject Chest;
    private void Awake()
    {
        current = this;                
    }

    public event Action<int> onDialogEventTrigger;
    public void DialogEventTrigger(int id)
    {
        if (onDialogEventTrigger != null)
        {
            onDialogEventTrigger(id);
           
        }
        if (id == 2)
        {
            Debug.Log("id2");
            Chest.SetActive(true);
        }
    }
}

