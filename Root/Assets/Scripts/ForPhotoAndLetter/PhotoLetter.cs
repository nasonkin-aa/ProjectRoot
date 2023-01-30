using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoLetter : MonoBehaviour
{
    public GameObject Photo;
    private void OnMouseDown()
    {
        Photo.SetActive(true);
        GameEvents.current.DialogEventTrigger(3);
    }
}
