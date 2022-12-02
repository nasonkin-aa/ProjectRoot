using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State
    {
        normal, zoom, ChangedView, idle
    };

    public State CurrentState { get; set; }
}
