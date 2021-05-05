using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Space]
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        var newPos = _target.transform.position;
        newPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, newPos, Time.fixedDeltaTime * _speed);
    }
}
