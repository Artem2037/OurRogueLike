using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private Rigidbody2D _playerRigidbody;
    private Animator _playerAnimator;
    private Vector3 _playerMovement;
    private float _horizontalAxis, _verticalAxis, _offset;
    private void Start()
    {
        _offset = 0.6f;

        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _verticalAxis = Input.GetAxis("Vertical");
        _playerMovement = new Vector3(_horizontalAxis, _verticalAxis, 0)*_offset;
    }
    private void FixedUpdate()
    {
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        if (_playerMovement != Vector3.zero)
        {
            MoveCharacter(transform.position);

            _playerAnimator.SetFloat("moveX", _horizontalAxis);
            _playerAnimator.SetFloat("moveY", _verticalAxis);
            _playerAnimator.SetBool("moving", true);
        }
        else
        {
            _playerAnimator.SetBool("moving", false);
        }
    }
    public void MoveCharacter(Vector3 position)
    {
        _playerRigidbody.MovePosition(position + _playerMovement * _playerSpeed * Time.deltaTime);
    }
}
