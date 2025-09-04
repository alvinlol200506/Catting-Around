using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 2f;

    [SerializeField] AudioClip audioClip;
    [SerializeField]AudioSource AS;

    public void Start()
    { 
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float time = 0f;
        canvasGroup.alpha = 0;
        if (audioClip != null)
        {
            AS.PlayOneShot(audioClip);
        }
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}

