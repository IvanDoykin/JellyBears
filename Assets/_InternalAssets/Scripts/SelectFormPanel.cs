using System;
using UnityEngine;

public class SelectFormPanel : MonoBehaviour
{
    public event Action<char, bool> VariantHasSelected;
    [SerializeField] private FormVariant[] _formVariants;

    private void Start()
    {
        for (int i = 0; i < _formVariants.Length; i++)
        {
            _formVariants[i].HasSelected += OnVariantSelected;
        }
    }

    private void OnVariantSelected(char letter, bool isRight)
    {
        Debug.Log(letter);
        VariantHasSelected?.Invoke(letter, isRight);
    }

    public void Enable(char[] variants, char rightVariant)
    {
        if (variants.Length > _formVariants.Length)
        {
            Debug.LogError("Error with variants.");
            return;
        }

        for (int i = 0; i < variants.Length; i++)
        {
            _formVariants[i].Enable(variants[i], variants[i] == rightVariant);
        }
    }

    public void Disable()
    {
        for (int i = 0; i < _formVariants.Length; i++)
        {
            _formVariants[i].Disable();
        }
    }
}
