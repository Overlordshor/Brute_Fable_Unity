using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class MoveAnimation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", GetSpeed());
        _animator.SetBool("runBack", IsRunBack());
    }

    private float GetSpeed()
    {
        float speed = 0f;

        if (!_rigidbody.isKinematic)
        {
            speed = _rigidbody.velocity.magnitude;
        }
        else if (_navMeshAgent.enabled)
        {
            speed = _navMeshAgent.velocity.magnitude;
        }
        else
        {
            Debug.LogError("������ ��������� �������� ��� ���������");
        }

        return speed;
    }

    private bool IsRunBack()
    {
        bool isRunBack = false;

        if (!_rigidbody.isKinematic)
        {
            isRunBack = Input.GetAxis("Vertical") < 0;
        }
        else if (_navMeshAgent.enabled)
        {
            // ������� ���������� isRunBack ��� _navMeshAgent
        }
        else
        {
            Debug.LogError("������ ��������� ����������� ���� ��� ���������");
        }

        return isRunBack;
    }
}