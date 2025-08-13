using UnityEngine;

public class PlayerRigidbodyMovement : Movement
{
    [SerializeField] private Rigidbody _body;

    protected override void Move()
    {
        _body.velocity = _speed * transform.forward;

        if (Input.GetKey(KeyCode.A))
        {
            _body.velocity += _speed * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _body.velocity += _speed * Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On trigger");
    }
}