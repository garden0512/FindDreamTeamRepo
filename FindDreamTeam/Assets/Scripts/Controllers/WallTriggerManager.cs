using UnityEngine;
using UnityEngine.SceneManagement;

public class WallTriggerManager : MonoBehaviour
{
    [SerializeField] private FadeController _fadeController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoToSchool1"))
        {
            Debug.Log("Go to School 1");
            _fadeController.RegisterCallback((() =>
            {
                Debug.Log("씬 로드 실행");
                SceneManager.LoadScene("School1");
            }));
            _fadeController.FadeOutOnly();
        }
        
        else if (other.CompareTag("GoToSchool2"))
        {
            _fadeController.RegisterCallback((() =>
            {
                SceneManager.LoadScene("School2");
            }));
            _fadeController.FadeOutOnly();
        }
        
        else if (other.CompareTag("GoToSchool3"))
        {
            _fadeController.RegisterCallback((() =>
            {
                SceneManager.LoadScene("School3");
            }));
            _fadeController.FadeOutOnly();
        }
        
        else if (other.CompareTag("GoToSchool4"))
        {
            _fadeController.RegisterCallback((() =>
            {
                SceneManager.LoadScene("School4");
            }));
            _fadeController.FadeOutOnly();
        }
    }
}
