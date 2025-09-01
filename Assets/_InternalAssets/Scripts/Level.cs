using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _finishPoint;

    [SerializeField] private Transform[] _players;
    [SerializeField] private ProgressPanel _progressPanel;

    private bool _isWin = true;
    private bool _isFinish = false;

    private void Awake()
    {
        StartSession();
    }

    public void StartSession()
    {
        Time.timeScale = 1f;
    }

    public void StopSession()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (!_isFinish)
        {
            float[] progress = new float[_players.Length];
            for (int i = 0; i < _players.Length; i++)
            {
                progress[i] = Mathf.Abs(_players[i].position.z - _startPoint.position.z) / Mathf.Abs(_finishPoint.position.z - _startPoint.position.z);
                if (progress[i] > 0.99f)
                {
                    PlayerUI ui = _players[i].GetComponentInChildren<PlayerUI>();
                    if (ui != null)
                    {
                        ui.Finish(_isWin);
                        _isFinish = true;
                        StopSession();
                    }
                    else
                    {
                        _isWin = false;
                    }
                }
            }

            _progressPanel.SetPoints(progress);
        }
    }
}