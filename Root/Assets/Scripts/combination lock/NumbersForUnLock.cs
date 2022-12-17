using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersForUnLock : PasswordManager
{
    public SpriteRenderer[] SpriteNumbers;
    public int NumberInCell
    {
        get { return _numberInCell; }
        set
        {
            if (value == 5)
                _numberInCell = 0;
            else
                _numberInCell = value;
        }
    }
    private int _numberInCell = 0;
 
    private void OnMouseDown()
    {
        NumberInCell++;
        GetComponent<Image>().sprite = SpriteNumbers[_numberInCell].sprite;
        ChecedPasswored();

    }
}
