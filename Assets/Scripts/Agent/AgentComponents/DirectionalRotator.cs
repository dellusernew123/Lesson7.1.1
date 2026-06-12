using UnityEngine;

public class DirectionalRotator
{
    private Transform _transform;
    private Vector3 _currentDirection;
    private float _rotationSpeed;

    public DirectionalRotator(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public Quaternion CurrentRotation => _transform.rotation;

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
