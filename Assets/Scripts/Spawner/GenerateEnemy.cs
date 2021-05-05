using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemySegment;
    [Space]
    [SerializeField] private List<Transform> _spawnpPoints;

    private float _interval = 2f;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        while (true)
        {
            Instantiate(_enemySegment, _spawnpPoints[Random.Range(0, _spawnpPoints.Count)].position, Quaternion.identity);

            yield return new WaitForSeconds(_interval);

            if (_interval > 0.5f)
                _interval -= 0.01f;
        }
    }
}
