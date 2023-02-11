using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
