using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBody : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 nextPosition)
    {
        _rigidbody.MovePosition(nextPosition);
    }
}
