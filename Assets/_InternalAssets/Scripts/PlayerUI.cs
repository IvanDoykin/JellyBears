using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Action HasRightSelection;

    [SerializeField] private FinishUI _finishUI;
    [SerializeField] private SelectFormPanel _selectFormPanel;
    private PlayerTransformer _trnasformer;

    private void Start()
    {
        _trnasformer = GetComponentInParent<PlayerTransformer>();
        _selectFormPanel.VariantHasSelected += OnVariantSelected;
    }

    private void OnVariantSelected(char variant, bool isRight)
    {
        _trnasformer.TransformTo(variant);

        if (isRight)
        {
            HasRightSelection?.Invoke();
            DisableSelectFormPanel();
        }
    }

    public void Finish(bool isWin)
    {
        _finishUI.Finish(isWin);
    }

    public void EnableSelectFormPanel(char[] variants, char rightVariant)
    {
        _selectFormPanel.Enable(variants, rightVariant);
    }

    public void DisableSelectFormPanel()
    {
        _selectFormPanel.Disable();
    }
}
