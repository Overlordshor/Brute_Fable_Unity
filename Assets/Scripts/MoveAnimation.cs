using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterController))]
public class MoveAnimation : MonoBehaviour
{
    private CharacterController _characterController;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", GetSpeed());

        if (Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("jump");
        }

        //_animator.SetBool("runBack", IsRunBack());
    }

    private float GetSpeed()
    {
        float speed = 0f;

        if (_characterController.enabled)
        {
            var horizontalVelocity = new Vector3(_characterController.velocity.x, 0, _characterController.velocity.z);
            speed = horizontalVelocity.magnitude;
        }
        else if (_navMeshAgent.enabled)
        {
            speed = _navMeshAgent.velocity.magnitude;
        }
        else
        {
            Debug.LogError("Ошибка установки скорости для аниматора");
        }

        return speed;
    }

    //private bool IsRunBack()
    //{
    //    bool isRunBack = false;

    //    if (_characterController.enabled)
    //    {
    //        isRunBack = Input.GetAxis("Vertical") < 0;
    //    }
    //    else if (_navMeshAgent.enabled)
    //    {
    //        // функция постановки isRunBack для _navMeshAgent
    //    }
    //    else
    //    {
    //        Debug.LogError("Ошибка установки направления бега для аниматора");
    //    }

    //    return isRunBack;
    //}
}