using System;
using System.Collections.Generic;
using UnityEngine;

public class ManyObjectsMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _manyObjects = new List<GameObject>();
    [SerializeField] private GameObject[] _manyObjectsArray;

    public event Action HasSpacePressed;

    private void Start()
    {
        _manyObjectsArray = new GameObject[_manyObjects.Count];
        for (int i = 0; i < _manyObjects.Count; i++)
        {
            _manyObjectsArray[i] = _manyObjects[i];
        }

        GameObject empty = new GameObject("Empty");
        _manyObjects.Add(empty);
        _manyObjects.Remove(empty);
        _manyObjects.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HasSpacePressed?.Invoke();
        }
    }
}