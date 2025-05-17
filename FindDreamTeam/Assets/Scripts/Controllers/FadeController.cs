using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] public bool isFadeIn = true;

    private CanvasRenderer _renderer;
    private Action _onFadeComplete;

    private void Awake()
    {
        _renderer = panel.GetComponent<CanvasRenderer>();
    }

    public void StartFadeIn()
    {
        if (isFadeIn)
        {
            panel.SetActive(true);
            StartCoroutine(FadeIn());
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void RegisterCallback(Action callback)
    {
        _onFadeComplete = callback;
    }

    public void FadeOutOnly()
    {
        panel.SetActive(true);
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        Time.timeScale = 0f;
        while (elapsedTime <= fadeTime)
        {
            _renderer.SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / fadeTime));
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _renderer.SetAlpha(1f);
        Time.timeScale = 1f;
        _onFadeComplete?.Invoke();
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Time.timeScale = 0f;
        while (elapsedTime <= fadeTime)
        {
            _renderer.SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / fadeTime));
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        _renderer.SetAlpha(0f);
        panel.SetActive(false);
        Time.timeScale = 1f;
        _onFadeComplete?.Invoke();
    }
}