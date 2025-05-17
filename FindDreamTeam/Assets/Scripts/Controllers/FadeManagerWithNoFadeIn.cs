using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManagerWithNoFadeIn : MonoBehaviour
{
    public GameObject _panel;
    public float _fadeTime = 1f;
    public bool _isFadeIn = false;

    private CanvasRenderer _renderer;

    private void Awake()
    {
        _renderer = _panel.GetComponent<CanvasRenderer>();
    }

    public void StartFadeIn()
    {
        if (_isFadeIn)
        {
            _panel.SetActive(true);
            StartCoroutine(FadeIn());
        }
        else
        {
            _panel.SetActive(false);
        }
    }

    public void FadeOutToScene(string sceneName)
    {
        _panel.SetActive(true);
        StartCoroutine(FadeOutCoroutine(sceneName));
    }

    private IEnumerator FadeOutCoroutine(string sceneName)
    {
        float elapsedTime = 0f;
        while (elapsedTime <= _fadeTime)
        {
            _renderer.SetAlpha(Mathf.Lerp(0f, 1f, elapsedTime / _fadeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _renderer.SetAlpha(1f);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime <= _fadeTime)
        {
            _renderer.SetAlpha(Mathf.Lerp(1f, 0f, elapsedTime / _fadeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _renderer.SetAlpha(0f);
        _panel.SetActive(false);
    }
}
