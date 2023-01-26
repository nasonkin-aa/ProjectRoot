using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenmsInCar : MonoBehaviour
{
    // Start is called before the first frame update
    AllItemsInCar allItemsInCar;

    private void Start()
    {
        allItemsInCar = FindObjectOfType<AllItemsInCar>();
    }
    private void OnMouseDown()
    {
        allItemsInCar.DeleteText(gameObject.GetComponent<ItenmsInCar>());
        //Debug.Log(gameObject.name);
        Destroy(transform.gameObject);
    }
}
