using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


public class ItemUse : MonoBehaviour, IInteractable
{
    public GameObject UnlockItem;
    private GameObject inventory;
    public GameObject SetActiveGameobject;
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
            UseItem(this);
        }
    }

    public void UseItem(ItemUse item)
    {
        switch (item.UnlockItemString)
        {
            case "key_green":
                break;
            case "baikal_spr_items_set_1": // Спички 
                GetComponent<FadeIn>().Fade();
                Invoke("EventTrigger", 1.1f);
                break;
            case "baikal_spr_items_set_0": // Картина
                Destroy(gameObject);
                SetActiveGameobject.SetActive(true);
                break;
            case "Лопата целая_0":
                GetComponent<FadeIn>().Fade();
                GameEvents.current.DialogEventTrigger(4);
                break;
            default: throw new Exception($"item don't use '{item}'");
        }
    }

    public void EventTrigger()
    {
        GameEvents.current.DialogEventTrigger(1);
    }
}
