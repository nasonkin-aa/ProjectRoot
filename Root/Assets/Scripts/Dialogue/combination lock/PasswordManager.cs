using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    public GameObject KeyCode;
    public List<NumbersForUnLock> _numbersInPassword = new List<NumbersForUnLock>();
    private string _password = "4213";

    private void Start()
    {
        _numbersInPassword.AddRange(GameObject.FindObjectsOfType<NumbersForUnLock>());
        _numbersInPassword = _numbersInPassword.OrderBy(x => x.name).ToList();
    }
    protected void ChecedPasswored()
    {
        string current = "";
        foreach (var number in _numbersInPassword)
        {
            Debug.Log(number);
            current += number.NumberInCell.ToString();
            Debug.Log(current);
        }
        
        if (current == _password)
        {
            KeyCode = GameObject.Find("KeyCode");
            GameEvents.current.DialogEventTrigger(2);
            
            KeyCode.SetActive(false);
        }
    }

}
