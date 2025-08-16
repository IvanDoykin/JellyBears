using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private SelectFormPanel _selectFormPanel;

    public void EnableSelectFormPanel(char[] variants)
    {
        _selectFormPanel.Enable(variants);
    }

    public void DisableSelectFormPanel()
    {
        _selectFormPanel.Disable();
    }
}
