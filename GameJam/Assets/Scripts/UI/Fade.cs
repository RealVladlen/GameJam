using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public static Fade Instance { get; private set; }

    public bool _state;

    private CanvasGroup _fadeCanvas;

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;

        _fadeCanvas = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _fadeCanvas.alpha = 1;

        Invoke(nameof(ShowFade), 1);
    }

    public void ShowFade()
    {
        _fadeCanvas.DOFade(0, 1f).SetUpdate(UpdateType.Normal, true);
        _state = false;
    }

    public void HideFade()
    {
        _fadeCanvas.DOFade(1, 1f).SetUpdate(UpdateType.Normal, true);
        _state = true;
    }

    public void ShowFadeNextLevel()
    {
        Tween tween = _fadeCanvas.DOFade(1, 1f).SetUpdate(UpdateType.Normal, true);
        _state = false;

        tween.onComplete += () => 
        {
            LevelsManager.Instance.NextLevel();
        };
    }

    public void ShowFadeEndGame()
    {
        Tween tween = _fadeCanvas.DOFade(1, 1f).SetUpdate(UpdateType.Normal, true);
        _state = false;

        tween.onComplete += () =>
        {
            LevelsManager.Instance.MainMenu();
        };
    }

    public void StartGame()
    {
        Tween tween = _fadeCanvas.DOFade(1, 1f);
        tween.onComplete += () =>
        {
            LevelsManager.Instance.StartGame();
        };
    }
}
