using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateDiedEnemy : MonoBehaviour
{
    [SerializeField] private HealthContainer _healthContainer;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _healthContainer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnDied;
    }

    public void OnDied()
    {
        _animator.Play("DiedEnemy");
        ScoreCounter.Instance.UpdatedCounter();
        Destroy(_healthContainer.gameObject, 0.2f);
    }
}
