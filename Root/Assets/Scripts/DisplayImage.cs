using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{


    public int ValueCurentWallHorizontal = 5;
    public int ValueCurentWallVertical = 3;

    public enum State
    {
        normal, zoom, ChangedView, idle
    };

    public State CurrentState { get; set; }
    public int CurentWallHorizontal
    {
        get { return currentWallHorizontal; }
        set
        {
            if (value == ValueCurentWallHorizontal)
                CurentWallHorizontal = 1;
            else if (value == 0)
                currentWallHorizontal = 4;
            else
                currentWallHorizontal = value;
        }
    }
    public int CurentWallVertical
    {
        get { return currentWallVertical; }
        set
        {
            currentWallVertical = value;

        }
    }

    private int currentWallHorizontal;
    private int currentWallVertical;

    private int previousWallHorizontal;
    private int previousWallVertical;

    void Start()
    {
        previousWallHorizontal = 0;
        currentWallVertical = 1;
        currentWallHorizontal = 1;

    }

    void Update()
    {
        if (currentWallHorizontal != previousWallHorizontal)
        {
            /* if (currentWallVertical != previousWallHorizontal)
             {*/
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWallVertical.ToString() + currentWallHorizontal.ToString());
            Debug.Log("Sprites/wall" + currentWallHorizontal.ToString() + currentWallVertical.ToString());
            // }

        }
        if (currentWallVertical != previousWallVertical)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWallVertical.ToString() + currentWallHorizontal.ToString());
            Debug.Log("Sprites/wall" + currentWallHorizontal.ToString() + currentWallVertical.ToString());
        }
        previousWallHorizontal = currentWallHorizontal;
        previousWallVertical = currentWallVertical;

    }
}
