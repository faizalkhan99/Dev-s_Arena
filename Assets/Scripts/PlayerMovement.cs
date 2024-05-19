using UnityEngine.UI;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    [SerializeField] private float _flyingForce;
    [SerializeField] private float _moveSpeed;
    private Rigidbody _rigidbody;
    private Vector3 _upForce = new(0, 1, 0);

    [SerializeField] private float _maxFuel;
    [SerializeField] private float _fuelUsageMultiplier = 1f;

    [SerializeField] private float _currentFuel;
    [SerializeField] private Image fuelImage;

    private void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        _currentFuel = _maxFuel;
    }

    private void Update()
    {
        fuelImage.fillAmount = _currentFuel / _maxFuel;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleFlying();
    }

    private void HandleFlying()
    {
        if (Input.GetKey(KeyCode.Space) && _currentFuel > 0)
        {
            _rigidbody.AddForce((1000 * _flyingForce) * Time.fixedDeltaTime * _upForce, ForceMode.Acceleration);
            _currentFuel -= Time.deltaTime * _fuelUsageMultiplier;
        }
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector3 currentVelocity = _rigidbody.velocity;
        Vector3 newVelocity = new(xInput * _moveSpeed, currentVelocity.y, currentVelocity.z);
        _rigidbody.velocity = newVelocity;
    }

    public void FillFuel(float fillMultiplier)
    {
        _currentFuel += Time.deltaTime * fillMultiplier;
    }
}