using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerNavMeshController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Rigidbody _rigidbody;
    private Camera _mainCamera;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                _rigidbody.isKinematic = true;
                _navMeshAgent.enabled = true;
                _navMeshAgent.SetDestination(hit.point);
            }
        }
        else if (_navMeshAgent.velocity == Vector3.zero)
        {
            _navMeshAgent.enabled = false;
            _rigidbody.isKinematic = false;
        }
    }
}