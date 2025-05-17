using UnityEngine;

public class BeforeSchoolController : MonoBehaviour
{
    [SerializeField] private FadeController _fadeController;
    private void Start()
    {
        _fadeController.isFadeIn = true;
        _fadeController.StartFadeIn();
    }
}
