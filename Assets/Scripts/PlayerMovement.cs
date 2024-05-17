using UnityEngine;
public class PlayerMovemnt : MonoBehaviour
{
    [SerializeField] private float _flyingForce;
    [SerializeField] private float _moveSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _upForce = new(0, 1, 0);
    private void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
    void FixedUpdate()
    {
        HandleMovement();
        HandleFlying();
    }
    private void HandleFlying()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce((1000 * _flyingForce) * Time.fixedDeltaTime * _upForce, ForceMode.Acceleration);
        }
    }
    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector3 currentVelocity = _rigidbody.velocity;
        Vector3 newVelocity = new(xInput * _moveSpeed, currentVelocity.y, currentVelocity.z);
        _rigidbody.velocity = newVelocity;
    }
}