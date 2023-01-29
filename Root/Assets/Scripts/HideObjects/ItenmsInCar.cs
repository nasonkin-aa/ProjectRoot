using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenmsInCar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float fadeDuration = 1f;
    private float currentTime = 0f;
    private float startAlpha;
    private float endAlpha = 0f;
    private Renderer rend;
    private bool isButtonPressed = false;

    AllItemsInCar allItemsInCar;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startAlpha = rend.material.color.a;
        allItemsInCar = FindObjectOfType<AllItemsInCar>();
    }
    private void OnMouseDown()
    {
        Debug.Log(isButtonPressed);
        allItemsInCar.DeleteText(gameObject.GetComponent<ItenmsInCar>());
        isButtonPressed = true;
    }
    private void Update()
    {
        if (isButtonPressed)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, currentTime / fadeDuration);
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
            if (currentTime >= fadeDuration)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StartFade()
    {
        currentTime = 0f;
    }

}
