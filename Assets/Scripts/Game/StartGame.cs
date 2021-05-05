using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TransitionScene _transition;

    private void Start()
    {
        _transition.Open();
    }
}
