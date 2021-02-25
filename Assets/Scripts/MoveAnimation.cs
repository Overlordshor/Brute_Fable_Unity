using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class MoveAnimation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        var speed = _rigidbody.velocity.magnitude;
        _animator.SetFloat("speed", speed);

        bool isRunBack = Input.GetAxis("Vertical") < 0;
        _animator.SetBool("runBack", isRunBack);
    }
}