using UnityEngine;
using System.Collections;
using UnityEngine.UI;
     
public class FadeIn : MonoBehaviour {
    private Image _image;
    private float _fadeDuration = 0.5f;
    public GameObject thisScene;
    public GameObject nextScene;
     
     
    private void Awake()
    {
        _image = GameObject.Find("Fade").GetComponent<Image>();
    }
     
    private IEnumerator FadeAlpha(float from, float to, float duration) {
        var fromColor = new Color(_image.color.r, _image.color.g, _image.color.b, from);
        var toColor = new Color(_image.color.r, _image.color.g, _image.color.b, to);
     
        var elaspedTime = 0f;
        while (elaspedTime <= duration) {
            elaspedTime += Time.deltaTime;
            _image.color = Color.Lerp(fromColor, toColor, elaspedTime / duration);
            yield return null;
        }
        _image.color = toColor;
        if (!nextScene.activeSelf)
        {
            nextScene.SetActive(true);
            DialogueManager.EnableAllButtons();
            _image.gameObject.GetComponent<FadeOut>().OutFade();
            DialogueManager.DisableAllButtons();
            thisScene.SetActive(false);
        }
    }
    
    public void Fade() {
        StartCoroutine(FadeAlpha(0f, 1f, _fadeDuration));
        DialogueManager.DisableAllButtons();
    }
}