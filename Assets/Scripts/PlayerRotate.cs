using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform _positionTarget;
    [SerializeField] private float _speedRotate;
    private Vector3 _direction;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _direction = _positionTarget.position - transform.position;
        _direction.y = 0;
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        _positionTarget.position = ray.GetPoint(15);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), _speedRotate);
    }
}