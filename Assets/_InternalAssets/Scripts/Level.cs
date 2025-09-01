using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _finishPoint;

    [SerializeField] private Transform[] _players;
    [SerializeField] private ProgressPanel _progressPanel;

    private void Awake()
    {
        Time.timeScale = 0f;
        StartSession();
    }

    public void StartSession()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        float[] progress = new float[_players.Length];
        for (int i = 0; i <  _players.Length; i++)
        {
            progress[i] = Mathf.Abs(_players[i].position.z - _startPoint.position.z) / Mathf.Abs(_finishPoint.position.z - _startPoint.position.z);
        }

        _progressPanel.SetPoints(progress);
    }
}