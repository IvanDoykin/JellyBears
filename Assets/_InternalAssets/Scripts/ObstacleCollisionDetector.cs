using System;
using UnityEngine;

public class ObstacleCollisionDetector : MonoBehaviour
{
    public event Action HasCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponentInParent<Obstacle>() != null)
        {
            HasCollided?.Invoke();
        }
    }
}