using System.Collections;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10.0f;
    [SerializeField] private float _pushForce = 10f;
    [SerializeField] private Rigidbody _body;

    private float _currentSpeed = 0f;
    private bool _hasPushed = false;

    private void Start()
    {
        GetComponent<ObstacleCollisionDetector>().HasCollided += PushBackward;
    }

    private void PushBackward()
    {
        StartCoroutine(SmoothPushBackward());
    }
    
    private IEnumerator SmoothPushBackward()
    {
        _hasPushed = true;
        _currentSpeed = 0f;

        _body.AddForce(-transform.forward * _pushForce, ForceMode.Impulse);

        float counter = 0f;
        while (counter < 1f)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        _hasPushed = false;
    }    

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_hasPushed)
        {
            return;
        }

        if (_currentSpeed < _startSpeed)
        {
            _currentSpeed += _startSpeed * Time.deltaTime;
        }

        _body.velocity = _currentSpeed * transform.forward;
    }
}