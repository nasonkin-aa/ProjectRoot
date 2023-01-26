using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDirection : MonoBehaviour
{
    public DirectionController DirectionController;

    public CardinalDirections direction;
    public enum CardinalDirections
    {
       
        one = 1,
        two = 2,
        thri = 3,
        four = 4
    }
    public void Start()
    {
        DirectionController = GameObject.Find("DirectionController").GetComponent<DirectionController>();
    }
    private void Update()
    {
        if ((int)direction == DirectionController.CurentDirection)
        {
            FindAllChildren(true);
        }
        else if ((int)direction != DirectionController.CurentDirection)
        {
            FindAllChildren(false);
        }
    }
    public void FindAllChildren(bool value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
           transform.GetChild(i).gameObject.SetActive(value); ;
        }
    }

}
