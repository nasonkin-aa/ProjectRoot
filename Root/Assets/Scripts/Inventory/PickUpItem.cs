using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Visitor;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public enum property { usable, displayable };

    public string CombinationItem;

    public property itemProperty;

    private GameObject InventorySlots;

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }
    public void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");

        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    gameObject.GetComponent<SpriteRenderer>().sprite;
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, CombinationItem);
                Destroy(gameObject);
                break;
            }
        }
    }


}
