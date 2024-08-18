using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class TranparencyDetection : MonoBehaviour
{
    [Range(0, 1)]
    [Tooltip("The transparency amount of the object when player on the object")]
    [SerializeField] float transparencyAmount = 0.5f;
    [Tooltip("The fade time of the transparency")]
    [SerializeField] float fadeTime = 0.4f;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null && sr != null)
        {
            StartCoroutine(FadeRoutine(sr, fadeTime, sr.color.a, transparencyAmount));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null && sr != null)
        {
            StartCoroutine(FadeRoutine(sr, fadeTime, sr.color.a, 1f));
        }
    }

    IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startValue, float targetTransparent)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparent, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            yield return null;
        }
    }
}
