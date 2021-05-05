using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource Source;
    public List<Transform> SpawnPoint;

    private Camera _camera;
    private int _counterSpawnPoint;

    public Vector3 GetSpawnPoint
    {
        get
        {
            Vector3 position = SpawnPoint[_counterSpawnPoint].position;
            UpdatedCounter();
            return position;
        }
    }

    public Vector3 GetDirecion
    {
        get
        {
            var direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            return new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void UpdatedCounter()
    {
        _counterSpawnPoint++;

        if (_counterSpawnPoint == SpawnPoint.Count)
            _counterSpawnPoint = 0;
    }
}
