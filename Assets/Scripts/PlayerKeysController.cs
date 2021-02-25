using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerKeysController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Rigidbody _rigidbody;

    private float _vectical;
    private Vector3 _moveVector;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _vectical = Input.GetAxis("Vertical");

        _moveVector = (transform.forward * _vectical) * _speed / Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_moveVector);
    }
}