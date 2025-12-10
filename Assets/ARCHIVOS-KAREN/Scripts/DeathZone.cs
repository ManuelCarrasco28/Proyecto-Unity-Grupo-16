using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Punto de reaparición del jugador")]
    public Transform spawnPoint;

    [Header("Altura adicional para evitar atascos")]
    public float alturaExtra = 1f; // 🔼 Eleva un poco al jugador al reaparecer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 🔄 Resetea la posición del jugador ligeramente por encima del punto de spawn
            Vector3 nuevaPos = spawnPoint.position;
            nuevaPos.y += alturaExtra;
            other.transform.position = nuevaPos;

            // 🧹 Limpia fuerzas residuales del Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Debug.Log("☠️ Jugador cayó en la DeathZone y fue enviado al punto de inicio.");

            ReiniciarCubos();
        }
    }

    private void ReiniciarCubos()
    {
        ActivarTrigger[] cubos = FindObjectsOfType<ActivarTrigger>();

        foreach (ActivarTrigger cubo in cubos)
        {
            cubo.ReiniciarCubo();
        }

        Debug.Log("🔁 Todos los cubos fueron reiniciados a su estado original.");
    }
}
