using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
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
            Debug.Log("1");
        }
    }
}

