using UnityEngine.UI;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    [SerializeField] private float _flyingForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private ParticleSystem[] jetParticle;
    [SerializeField] private Transform gfx;

    [Space(8f)]
    [SerializeField] private Transform _playerUI;

    [SerializeField] private Vector3 _offset;

    private Rigidbody _rigidbody;
    private Vector3 _upForce = new(0, 1, 0);

    [SerializeField] private float _maxFuel;
    [SerializeField] private float _fuelUsageMultiplier = 1f;

    [SerializeField] private float _currentFuel;
    [SerializeField] private Image fuelImage;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        _currentFuel = _maxFuel;
        _audioSource = GetComponent<AudioSource>();
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
            foreach (var particle in jetParticle)
            {
                if (!particle.isPlaying)
                {
                    particle.Play();
                    _animator.SetBool("isFlying", true);
                    if (!_audioSource.isPlaying)
                    {
                        _audioSource.Play();
                    }
                }
            }

            _rigidbody.AddForce((1000 * _flyingForce) * Time.fixedDeltaTime * _upForce, ForceMode.Acceleration);
            _currentFuel -= Time.deltaTime * _fuelUsageMultiplier;
        }
        else
        {
            foreach (var particle in jetParticle)
            {
                particle.Stop();
                _animator.SetBool("isFlying", false);
                _audioSource.Stop();
            }
        }
    }

    private void LateUpdate()
    {
        gfx.localPosition = Vector3.zero;
        gfx.localRotation = Quaternion.Euler(0, 180, 0);
        _playerUI.position = transform.position + _offset;
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        Vector3 currentVelocity = _rigidbody.velocity;
        Vector3 newVelocity = new(xInput * _moveSpeed, currentVelocity.y, currentVelocity.z);
        _rigidbody.velocity = newVelocity;
        _animator.SetBool("IsWalking", Mathf.Abs(xInput) > 0);
        Quaternion targetRotation = Quaternion.LookRotation(new(-xInput, 0, 0));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotSpeed * 100 * Time.deltaTime);
    }

    public void FillFuel(float fillMultiplier)
    {
        if (_currentFuel <= _maxFuel)
        {
            _currentFuel += Time.deltaTime * fillMultiplier;
        }
        else
        {
            _currentFuel = _maxFuel;
        }
    }
}