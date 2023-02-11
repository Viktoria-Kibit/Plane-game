using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _torqueForce;

    private float _horizontaInput;
    private float _verticalInput;

    private void Update()
    {
        _rigidbody.velocity = transform.forward * _speed * Time.deltaTime;

        _horizontaInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeTorque(-_verticalInput * _torqueForce, 0f, -_horizontaInput * _torqueForce);
    }
}
