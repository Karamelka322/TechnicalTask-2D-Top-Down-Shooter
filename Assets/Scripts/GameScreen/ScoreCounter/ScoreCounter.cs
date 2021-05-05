using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;

    [SerializeField] private Text _text;

    private int _counter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _text.text = $"Score: {_counter}";
    }

    public void UpdatedCounter()
    {
        _counter++;
        _text.text = $"Score: {_counter}";
    }
}
