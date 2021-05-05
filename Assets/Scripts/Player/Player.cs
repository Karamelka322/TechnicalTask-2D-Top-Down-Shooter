using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(HealthContainer))]
public class Player : MonoBehaviour, IDamageble
{
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private PlayerBody _body;

    private PlayerInput _playerInput;
    private HealthContainer _healthContainer;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _healthContainer = GetComponent<HealthContainer>();
    }

    private void FixedUpdate()
    {
        Move(_playerInput.GetNextPosition(_speed));
    }

    private void Move(Vector3 nextPosition)
    {
        transform.position = nextPosition;
        _body.Move(nextPosition);
    }

    public void ApplyDemage(int demage)
    {
        _healthContainer.TakeDamage(demage);
    }
}
