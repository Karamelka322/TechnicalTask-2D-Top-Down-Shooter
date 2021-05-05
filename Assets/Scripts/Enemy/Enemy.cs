using UnityEngine;

[RequireComponent(typeof(HealthContainer))]
public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private EnemyBody _body;

    private HealthContainer _healthContainer;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        _healthContainer = GetComponent<HealthContainer>();
    }

    private void LateUpdate()
    {
        Move(player.transform.position);
    }

    private void Move(Vector3 target)
    {
        transform.eulerAngles = GetDirection(target);
        transform.position = transform.position + transform.right * _speed;
        _body.Move(transform.position);
    }
    
    private Vector3 GetDirection(Vector3 targetPosition)
    {
        var direction = targetPosition - transform.position;
        return new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    public void ApplyDemage(int demage)
    {
        _healthContainer.TakeDamage(demage);
    }
}
