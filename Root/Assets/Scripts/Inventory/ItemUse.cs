using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour, IInteractable
{
    public string UnlockItem;

    private GameObject inventory;
    public GameObject endScene;
    public GameObject key_yellow;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    public void end()
    {
        endScene.SetActive(true);
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.GetComponent<Slot>().ClearSlot();
            Destroy(gameObject);
            Debug.Log("Use " + UnlockItem);
            if (UnlockItem == "key_yellow")
            {
                end();
            }
            if (UnlockItem == "key_green")
            {
                key_yellow.SetActive(true);
            }
        }
    }
}
