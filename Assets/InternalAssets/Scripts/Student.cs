using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] private bool _isReady;

    private void Start()
    {
        int sessionId = Random.Range(0, 100);
        Debug.LogWarning("Session " + sessionId + " has started.");

        if (_isReady == true)
        {
            Debug.Log("Student is ready to Unity course.");
        }
        else
        {
            Debug.LogError("Student is not ready to Unity course");
        }

        float halfCounter = 0f;
        for (int i = 0; i < sessionId; i++)
        {
            halfCounter += i;
        }
        halfCounter /= 2f;

        PrintHalfCounter(halfCounter);
    }

    private void PrintHalfCounter(float halfCounter)
    {
        Debug.Log(halfCounter);
    }
}