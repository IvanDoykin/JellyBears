using UnityEngine;

public class ProgressPanel : MonoBehaviour
{
    [SerializeField] private RectTransform _startPoint;
    [SerializeField] private RectTransform _finishPoint;

    [SerializeField] private RectTransform[] _playerPoints;

    public void SetPoints(float[] progress)
    {
        for (int i = 0; i < progress.Length; i++)
        {
            _playerPoints[i].position = Vector3.Lerp(_startPoint.position, _finishPoint.position, progress[i]);
        }
    }
}
