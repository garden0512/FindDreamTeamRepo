using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_Button : MonoBehaviour
{
    [SerializeField] private FadeController _fadeController;
    public void GoSchool()
    {
        _fadeController.RegisterCallback((() =>
        {
            SceneManager.LoadScene("CutScene_before_School");
        }));
        _fadeController.FadeOutOnly();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
