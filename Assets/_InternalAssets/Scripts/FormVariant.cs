using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormVariant : MonoBehaviour
{
    public event Action<char> HasSelected;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(() => HasSelected?.Invoke(char.Parse(_text.text)));
    }

    public void Enable(char letter)
    {
        gameObject.SetActive(true);
        _text.text = letter.ToString();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
