using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBody : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBody playerBody))
        {
            playerBody.GetComponentInParent<Player>().ApplyDemage(1);
            GetComponentInParent<StateDiedEnemy>().OnDied();
        }
    }

    public void Move(Vector3 nextPosition)
    {
        _rigidbody.MovePosition(nextPosition);
    }
}
