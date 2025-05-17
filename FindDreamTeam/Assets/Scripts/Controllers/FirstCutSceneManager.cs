using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstCutSceneManager : MonoBehaviour
{
    [SerializeField] private List<Image> _cutSceneImages;
    [SerializeField] private float imageOnDisplayTime = 3f;
    [SerializeField] private FadeController _fadeController;

    private void Start()
    {
        _fadeController.RegisterCallback(() =>
        {
            StartCoroutine(PlayCutScene());
        });

        _fadeController.isFadeIn = true;
        _fadeController.StartFadeIn();
    }

    private IEnumerator PlayCutScene()
    {
        foreach (var img in _cutSceneImages)
            img.gameObject.SetActive(false);

        for (int i = 0; i < _cutSceneImages.Count; i++)
        {
            _cutSceneImages[i].gameObject.SetActive(true);
            if (i < _cutSceneImages.Count - 1)
            {
                yield return new WaitForSeconds(imageOnDisplayTime);
                _cutSceneImages[i].gameObject.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(imageOnDisplayTime);

                _fadeController.RegisterCallback(() =>
                {
                    SceneManager.LoadScene("beforeSchool");
                });
                _fadeController.FadeOutOnly();
            }
        }
    }
}