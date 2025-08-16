using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private char[] _variants;
    [SerializeField] private Mesh[] _playerVariants;

    private void OnTriggerEnter(Collider other)
    {
        PlayerUI player = other.GetComponentInChildren<PlayerUI>();
        if (player != null)
        {
            player.EnableSelectFormPanel(_variants);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerUI playerUI = other.GetComponentInChildren<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.DisableSelectFormPanel();
        }
    }
}