using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string displayImage;
    public string combinationItem { get; private set; }

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name != "empty_item")
        {
            inventory.GetComponent<Inventory>().previousSelectedSlot =
                inventory.GetComponent<Inventory>().currentSelectedSlot;
            inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
            Combine();
            //if (ItemProperty == Slot.property.displayable) DisplayItem();
            inventory.GetComponent<Inventory>().SelectSlot();
        }
    }

    public void AssignProperty(int orderNumber, string combinationItem)
    {
        ItemProperty = (property)orderNumber;
        this.combinationItem = combinationItem;
    }

    public void DisplayItem()
    {
        if (!inventory.GetComponent<Inventory>().itemDisplayer.activeSelf)
        {
            inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
            inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Inventory Items/" + displayImage);
        }
        else
        {
            inventory.GetComponent<Inventory>().itemDisplayer.SetActive(false);
        }
        
    }

    void Combine()
    {
        if (inventory.GetComponent<Inventory>().previousSelectedSlot != null && inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().combinationItem
            == this.gameObject.GetComponent<Slot>().combinationItem && this.gameObject.GetComponent<Slot>().combinationItem != "")
        {
            Debug.Log("combine");
            GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + combinationItem));
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();

            inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().ClearSlot();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        ItemProperty = Slot.property.empty;
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory Items/empty_item");
        inventory.GetComponent<Inventory>().SelectSlot();
        inventory.GetComponent<Inventory>().currentSelectedSlot = null;
        inventory.GetComponent<Inventory>().previousSelectedSlot = null;
    }
}
