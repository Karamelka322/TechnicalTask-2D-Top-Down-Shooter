using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction ShootGun;
    public event UnityAction ReplaceGun;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            ShootGun?.Invoke();

        if (Input.GetKeyDown(KeyCode.Q))
            ReplaceGun?.Invoke();
    }

    public Vector3 GetNextPosition(float speed)
    {
        float X = Input.GetAxis("Horizontal") * speed;
        float Y = Input.GetAxis("Vertical") * speed;

        if (CheckFrame(transform.position.x, Map.Width))
            return Vector3.back;        
        
        if (CheckFrame(transform.position.y, Map.Height))
            return Vector3.back;

        return new Vector3(transform.position.x + X, transform.position.y + Y, transform.position.z);
    }

    private bool CheckFrame(float posValue, float frameValue)
    {
        if (posValue > frameValue)
            return true;
        else if (posValue < -frameValue)
            return true;

        return false;
    }
}
