using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDirection : MonoBehaviour
{

    public CardinalDirections direction;
    public enum CardinalDirections
    {
        north = 1,
        east = 2,
        south = 3,
        west = 4
    }

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

    private int _curentDirectiont = 1;
    public void Start()
    {
        if ((int)direction == _curentDirectiont)
        {
            foreach (Transform g in transform.GetComponentsInChildren<Transform>())
            {
                if (g.name != transform.name)
                {
                    g.gameObject.SetActive(false);
                }
            }
        }
    }
    public void Update()
    {
    
    }

}
