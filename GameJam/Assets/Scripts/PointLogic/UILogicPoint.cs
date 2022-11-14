using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UILogicPoint : MonoBehaviour
{
    public static UILogicPoint Instance;

    [SerializeField] Transform _windowTransform;
    [SerializeField] Transform _windowTextTransform;
    [SerializeField] Button _skip;
    [SerializeField] Transform _showPointFace, _showPointText, _hidePointFace, _hidePointText;
    [SerializeField] float _speedUI;
    [SerializeField] TextMeshProUGUI _textUI;
    [SerializeField] Image _image;

    private GameObject _thisPoint;
    private bool _windowState;
    public bool WindowState => _windowState;

    public bool _endLevelState;
    public bool _endGameState;

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void ChoiseFace(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    private void OnEnable()
    {
        _skip.onClick.AddListener(HideText);
    }

    public void ShowText(string textPoint, GameObject thisPoint, Sprite face)
    {
        _thisPoint = thisPoint;
        _windowState = true;
        _image.sprite = face;

        HiderUI(_showPointFace, _showPointText);

        _textUI.text = textPoint;

        DOTween.To(value => Time.timeScale = value, 1f, 0.001f, 1f).OnUpdate(() => { if (Time.timeScale < 0.001f) Time.timeScale = 0.001f; }).SetEase(Ease.InCubic).SetUpdate(UpdateType.Normal, true);
    }

    public void ShowText(string textPoint)
    {
        _windowState = true;

        HiderUI(_showPointFace, _showPointText);

        _textUI.text = textPoint;

        DOTween.To(value => Time.timeScale = value, 1f, 0.001f, 1f).OnUpdate(() => { if (Time.timeScale < 0.001f) Time.timeScale = 0.001f; }).SetEase(Ease.InCubic).SetUpdate(UpdateType.Normal, true);
    }

    public void HideText()
    {
        _windowState = false;

        HiderUI(_hidePointFace, _hidePointText);

        Destroy(_thisPoint);

        DOTween.To(value => Time.timeScale = value, 0.001f, 1f, 1f).OnUpdate(() => { if (Time.timeScale > 1f) Time.timeScale = 1f; }).SetEase(Ease.InCubic).SetUpdate(UpdateType.Normal, true);

        if (Fade.Instance._state == true)
            Fade.Instance.ShowFade();
    }

    private void HiderUI(Transform face, Transform text)
    {
        Tween tween = _windowTransform.DOMoveX(face.position.x, _speedUI).SetUpdate(UpdateType.Normal, true);

        _windowTextTransform.DOMoveX(text.position.x, _speedUI).SetUpdate(UpdateType.Normal, true);

        tween.onComplete += () =>
        {
            if (_endLevelState && !_windowState)
                Fade.Instance.ShowFadeNextLevel();

            if (_endGameState && !_windowState)
                Fade.Instance.ShowFadeEndGame();
        };
    }
}
