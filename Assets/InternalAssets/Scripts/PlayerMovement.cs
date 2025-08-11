using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 10f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += _speed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _speed * Vector3.right * Time.deltaTime;
        }

        transform.position += _speed * transform.forward * Time.deltaTime;
    }
}
