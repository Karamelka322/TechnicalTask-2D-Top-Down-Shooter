using System.Collections.Generic;
using UnityEngine;

public class UIHealthPlayer : MonoBehaviour
{
    [SerializeField] private HealthContainer _player;
    [SerializeField] private CellHealthSegment _cellSegment;
    [SerializeField] private TransitionScene _transitionScene;
    [Space]
    [SerializeField] private AudioSource _source;

    private List<CellHealthSegment> _cells;

    private void Awake()
    {
        _cells = new List<CellHealthSegment>();

        GenerateCells(_player.Health);
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;        
        _player.Died -= OnDied;
    }

    private void GenerateCells(int number)
    {
        for (int i = 0; i < number; i++)
        {
            _cells.Add(Instantiate(_cellSegment, transform));
        }
    }

    private void OnHealthChanged(int health)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            if (i < health)
                _cells[i].ActivCell(true);
            else
            {
                _cells[i].ActivCell(false);
                _source.PlayOneShot(_source.clip);
            }
        }
    }

    private void OnDied()
    {
        _transitionScene.Closes();
        LoadingScenes.Instance.LoadScene("Game", 0.8f);
    }
}
