using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _demage;
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private TypeAttacking _attacking;
    [Space]
    [SerializeField] private ParticleSystem _diedEffect;

    private enum TypeAttacking { Player, Enemy }
    private readonly float _lifeTime = 2f;
    private Rigidbody2D _rigedbody;

    public Vector3 Direction
    { 
        set { transform.eulerAngles = value; }
    }

    private void Start()
    {
        _rigedbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        Instantiate(_diedEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_attacking == TypeAttacking.Player)
        {
            if (collision.transform.TryGetComponent(out EnemyBody enemyBody))
            {
                enemyBody.GetComponentInParent<Enemy>().ApplyDemage(_demage);
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        _rigedbody.MovePosition(transform.position + transform.right * _speed);
    }
}
