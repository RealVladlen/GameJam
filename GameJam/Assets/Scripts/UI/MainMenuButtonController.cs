using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] Button _startGame;

    private void OnEnable()
    {
        _startGame.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        Fade.Instance.StartGame();
    }
}
