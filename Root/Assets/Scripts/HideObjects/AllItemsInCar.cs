using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class AllItemsInCar : MonoBehaviour
{
    
    private List<ItenmsInCar> _AllItems = new List<ItenmsInCar>();

    [SerializeField]
    private TextMeshProUGUI ItemBox;

    void Start()
    {
        //ItemBox.text = "";
        _AllItems.AddRange(GameObject.FindObjectsOfType<ItenmsInCar>());
        RefreshText();
    }

    public void DeleteText(ItenmsInCar selected_item)
    {
        if (_AllItems.Contains(selected_item))
        {
            _AllItems.Remove(selected_item);
            RefreshText();
        }
    }

    private void RefreshText()
    {
        ItemBox.text = "";
        foreach (var item in _AllItems)
        {
            ItemBox.text += $"{item.name.ToString()}\n";
        }
    }
    void Update()
    {
        
    }
}
