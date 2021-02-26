using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerKeysController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpHeight;

    private CharacterController _characterController;

    private float _gravityValue = -9.81f;
    private Vector3 _playerVelocity, _moveDirection;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController.enabled)
        {
            var groundedPlayer = _characterController.isGrounded;

            if (groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            MovePlayer();

            JumpPlayer(groundedPlayer);

            ActGravity();
        }
    }

    private void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        RotatePlayer(move);

        _characterController.Move(move * Time.deltaTime * _playerSpeed);
        _characterController.Move(_playerVelocity * _playerSpeed * Time.deltaTime);
    }

    private void RotatePlayer(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }

    private void ActGravity()
    {
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    private void JumpPlayer(bool groundedPlayer)
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }
    }
}