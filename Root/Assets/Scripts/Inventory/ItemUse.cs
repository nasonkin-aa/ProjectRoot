using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Visitor;


public class ItemUse : MonoBehaviour, IInteractable, IVisitor
{
    public GameObject UnlockItem;
    private GameObject inventory;
    private string UnlockItemString;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        UnlockItemString = UnlockItem.GetComponent<SpriteRenderer>().sprite.name;
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot != null && inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite.name == UnlockItemString)
        {
            inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.GetComponent<Slot>().ClearSlot();

            IVisitor visitor = gameObject.AddComponent<ItemUse>();
            
            visitor.Visit(this);
            
            Destroy(gameObject);
        }
    }

}
