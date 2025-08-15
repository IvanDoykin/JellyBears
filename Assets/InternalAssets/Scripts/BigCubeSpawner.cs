using System.Collections;
using UnityEngine;

public class BigCubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bigCube;

    private void Start()
    {
        StartCoroutine(SpawnWithInterval(10, 1f));
    }

    private IEnumerator SpawnWithInterval(int ammount, float interval)
    {
        for (int i = 0; i < ammount; i++)
        {
            GameObject bigCube = Instantiate(_bigCube);
            bigCube.transform.position = transform.position;

            yield return new WaitForSeconds(interval);
        }
    }
}
