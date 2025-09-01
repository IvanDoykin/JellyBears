using System;
using System.Collections;
using UnityEngine;

public class AISelector : MonoBehaviour
{
    public Action HasRightSelection;

    private PlayerTransformer _transformer;

    private char _lastSelection;
    private char[] _currentVariants;
    private char _currentRightVariant;

    private void Start()
    {
        _transformer = GetComponent<PlayerTransformer>();
    }

    public void Enable(char[] variants, char rightVariant)
    {
        _lastSelection = '\n';

        _currentRightVariant = rightVariant;
        _currentVariants = new char[variants.Length];
        variants.CopyTo(_currentVariants, 0);

        TakeRandomModel();
    }

    private void TakeRandomModel()
    {
        char variant = _currentVariants[UnityEngine.Random.Range(0, _currentVariants.Length)];

        if (_currentVariants.Length > 1)
        {
            while (variant == _lastSelection)
            {
                variant = _currentVariants[UnityEngine.Random.Range(0, _currentVariants.Length)];
            }
        }
        _lastSelection = variant;

        _transformer.TransformTo(variant);
        if (variant == _currentRightVariant)
        {
            HasRightSelection?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponentInParent<Obstacle>() != null)
        {
            StartCoroutine(TakeRandomModelWithDelay());
        }
    }

    private IEnumerator TakeRandomModelWithDelay()
    {
        yield return new WaitForSeconds(0.75f);
        TakeRandomModel();
    }
}
