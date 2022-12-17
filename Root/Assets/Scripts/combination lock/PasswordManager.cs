using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    
    public NumbersForUnLock[] _numbersInPassword;
    private string _password = "1234";

    private void Start()
    {
        _numbersInPassword = GameObject.FindObjectsOfType<NumbersForUnLock>();
    }
    protected void ChecedPasswored()
    {
        Debug.Log(_numbersInPassword.Length + "dasdadas");
        string current = "";
        foreach (var number in _numbersInPassword)
        {
            Debug.Log(number);
            current += number.NumberInCell.ToString();
            Debug.Log(current);
        }
        
        if (current == _password)
        {
            Debug.Log("unlock");
        }
    }

}
