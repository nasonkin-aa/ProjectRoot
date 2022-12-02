using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject itemDisplayer { get; private set; }

    void Start()
    {
        InitializeInventory();
    }

    void Update()
    {
        //SelectSlot();
        //HideDisplay();
    }

    void InitializeInventory()
    {
        slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/empty_item");
            slot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
            slot.GetComponent<Slot>().AssignProperty(-1, "empty_item", "");
        }
        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
    }

    public void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(.10f, .10f, .10f, 1);
            }
            else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
            if (currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                currentSelectedSlot = previousSelectedSlot;
                previousSelectedSlot = currentSelectedSlot;
            }
        }
    }

}

