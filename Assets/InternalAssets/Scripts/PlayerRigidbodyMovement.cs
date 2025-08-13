using UnityEngine;

public class PlayerRigidbodyMovement : Movement
{
    [SerializeField] private Rigidbody _body;
    [SerializeField] private GameObject _UI;

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
        if (_UI.activeSelf)
        {
            return;
        }
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name != "Plane")
        {
            _UI.SetActive(true);
        }
    }
}