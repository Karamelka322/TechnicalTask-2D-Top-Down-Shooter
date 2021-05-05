using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TransitionScene _transition;
    [SerializeField] private Button _btnStartGame;

    private readonly float _delayStartGame = 0.8f;

    private void Start()
    {
        _btnStartGame.onClick.AddListener(LoadStartGame);
    }

    public void LoadStartGame()
    {
        _transition.Closes();
        LoadingScenes.Instance.LoadScene("Game", _delayStartGame);
    }
}
