using UnityEngine;

public class PlayerTransformer : MonoBehaviour
{
    [SerializeField] private AudioSource _sfx;
    [SerializeField] private GameObject _defaultView;
    [SerializeField] private Transform _place;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private TransformInfo[] _transformInfo;

    private GameObject _transformedView;
    private bool _isTransformed = false;

    public void TransformTo(char letter)
    {
        if (_isTransformed)
        {
            Destroy(_transformedView);
        }
        for (int i = 0; i < _transformInfo.Length; i++)
        {
            if (_transformInfo[i].Letter == letter)
            {
                _defaultView.SetActive(false);
                _transformedView = Instantiate(_transformInfo[i].TransformedObject, _place);
                _isTransformed = true;
                for (int j = 0; j < _transformInfo.Length; j++)
                {
                    _particles[j].Play();
                }
                _sfx.Play();
            }
        }
    }

    public void TransformToDefault()
    {
        if (!_isTransformed)
        {
            Debug.LogError("Transform to default error.");
            return;
        }

        _defaultView.SetActive(true);
        Destroy(_transformedView);
        _isTransformed = false;
        for (int j = 0; j < _transformInfo.Length; j++)
        {
            _particles[j].Play();
        }
        _sfx.Play();
    }
}