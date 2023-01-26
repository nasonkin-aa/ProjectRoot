using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public int CurentDirection
    {
        get { return _curentDirectiont; }
        set
        {
            if (value == 5)
                _curentDirectiont = 1;
            else if (value == 0)
                _curentDirectiont = 4;
            else
                _curentDirectiont = value;
        }
    }

    private int _curentDirectiont = 2;
}
