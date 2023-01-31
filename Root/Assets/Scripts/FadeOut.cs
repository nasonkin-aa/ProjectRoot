using UnityEngine;
using System.Collections;
using UnityEngine.UI;
     
public class FadeOut : MonoBehaviour {
    private Image _image;
    private float _fadeDuration = 0.5f;
    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
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
        DialogueManager.EnableAllButtons();
    }
    public void OutFade() {
        StartCoroutine(FadeAlpha(1f, 0f, _fadeDuration));
    }
}