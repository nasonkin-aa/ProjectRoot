using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource click;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           click.Play(); 
        }
    }
}
