using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TransitionScene : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Closes()
    {
        _animator.Play("Closes");
    }

    public void Open()
    {
        _animator.Play("Open");
    }
}
