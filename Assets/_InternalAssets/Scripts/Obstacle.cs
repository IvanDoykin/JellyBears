using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private char[] _variants;

    private void OnTriggerEnter(Collider other)
    {
        PlayerUI player = other.GetComponentInChildren<PlayerUI>();
        if (player != null)
        {
            player.HasRightSelection += DisableCollision;
            player.EnableSelectFormPanel(_variants, char.Parse(transform.parent.name));
        }

        AISelector ai = other.GetComponentInChildren<AISelector>();
        if (ai != null)
        {
            ai.HasRightSelection += DisableCollision;
            ai.Enable(_variants, char.Parse(transform.parent.name));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerTransformer playerTransformer = other.GetComponent<PlayerTransformer>();
        if (playerTransformer != null)
        {
            playerTransformer.TransformToDefault();
        }
    }

    private void DisableCollision()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].isTrigger)
            {
                colliders[i].enabled = false;
            }
        }
    }
}