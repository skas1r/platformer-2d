using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class WinScreenManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        SetStartingParameters();
    }

    private void SetStartingParameters()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private IEnumerator FadeIn()
    {
        // Плавне проявлення екрана
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.fixedDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        // Плавне приховання екрана
        float time = 0f;
        float startAlpha = canvasGroup.alpha;
        while (time < fadeDuration)
        {
            time += Time.fixedDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0f;
    }

    public void ShowScreen()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        StartCoroutine(FadeIn());
    }

    public void HideScreen()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        StartCoroutine(FadeOut());
    }

    public void OnRestartButtonClicked()
    {
        HideScreen();
        FindFirstObjectByType<SceneTransitionManager>()?.TransitionToScene(0);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}