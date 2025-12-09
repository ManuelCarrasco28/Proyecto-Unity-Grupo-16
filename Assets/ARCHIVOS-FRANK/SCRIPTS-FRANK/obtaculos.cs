using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    [Header("Respawn")]
    public Transform player;          // Transform del Player
    public Transform destination;     // Punto de respawn
    public GameObject playerg;        // El GameObject del Player (para desactivarlo y reactivarlo)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reinicia al jugador en el respawn
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);
        }
    }
}

