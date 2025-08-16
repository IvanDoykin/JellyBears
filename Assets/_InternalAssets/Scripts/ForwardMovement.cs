using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Rigidbody _body;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _body.velocity = _speed * transform.forward;
    }
}