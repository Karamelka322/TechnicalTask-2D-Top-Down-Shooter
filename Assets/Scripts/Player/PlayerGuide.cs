using UnityEngine;

public class PlayerGuide : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        var direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }
}
