using System.Collections;
using UnityEngine;

public class gameEnd : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float duration;
    private bool hasTriggered = false; // flag to stop multiple triggers

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // lock it
            canvasGroup.gameObject.SetActive(true);
            StartCoroutine(FadeIn());
            
            // Example: disable movement/camera if needed
            // other.GetComponent<Movement>().enabled = false;
            // FindAnyObjectByType<Camera>().GetComponent<FPScamera>().enabled = false;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        canvasGroup.alpha = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
    }
}
