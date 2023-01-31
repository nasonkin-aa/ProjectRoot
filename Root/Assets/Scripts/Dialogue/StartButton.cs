using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
  public void BtnStart()
    {
        GameEvents.current.DialogEventTrigger(1);
    }
}   
