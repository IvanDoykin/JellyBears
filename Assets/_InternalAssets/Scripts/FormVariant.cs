using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormVariant : MonoBehaviour
{
    public event Action<char, bool> HasSelected;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    private bool _isRight = false;

    private void Start()
    {
        _button.onClick.AddListener(() => HasSelected?.Invoke(char.Parse(_text.text), _isRight));
    }

    public void Enable(char letter, bool isRight)
    {
        _isRight = isRight;
        gameObject.SetActive(true);
        _text.text = letter.ToString();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
