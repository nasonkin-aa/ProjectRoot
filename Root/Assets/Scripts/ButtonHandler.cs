using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private DirectionController direction;

    void Start()
    {
        direction = GameObject.Find("DirectionController").GetComponent<DirectionController>();
    }

    public void OnRightClickArrow()
    {
        direction.CurentDirection += 1;
       // direction.
    }

    public void OnLeftClickArrow()
    {
        direction.CurentDirection -= 1;
    }

}
