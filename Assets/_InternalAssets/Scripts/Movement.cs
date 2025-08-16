using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected abstract void Move();
}
