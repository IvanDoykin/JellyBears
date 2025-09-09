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

    public void PlayEffect()
    {
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }
    }

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
                PlayEffect();
                _sfx.Play();
            }
        }
    }

    public void TransformToDefault()
    {
        if (!_isTransformed)
        {
            return;
        }

        _defaultView.SetActive(true);
        PlayEffect();
        Destroy(_transformedView);
        _isTransformed = false;
        _sfx.Play();
    }
}