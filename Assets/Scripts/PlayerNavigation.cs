using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterController))]
public class PlayerNavigation : MonoBehaviour
{
    [SerializeField] private bool _isOnlyNavigation;
    private NavMeshAgent _navMeshAgent;
    private CharacterController _characterController;
    private Camera _mainCamera;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.enabled = _isOnlyNavigation;

        _characterController = GetComponent<CharacterController>();
        _characterController.enabled = !_isOnlyNavigation;

        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (!_isOnlyNavigation)
                {
                    _characterController.enabled = false;
                    _navMeshAgent.enabled = true;
                }

                _navMeshAgent.SetDestination(hit.point);
            }
        }
        else if (_navMeshAgent.velocity == Vector3.zero)
        {
            if (!_isOnlyNavigation)
            {
                _navMeshAgent.enabled = false;
                _characterController.enabled = true;
            }
        }
    }
}