using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] List<Transform> checkPoints; // ← ahora es Transform, no GameObject

    Transform currentSpawnPoint;

    [SerializeField] float dead = 10f;

    void Start()
    {
        // Spawn inicial
        currentSpawnPoint = checkPoints[0];
    }

    void Update()
    {
        if (player.transform.position.y < -dead)
            RespawnPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("point"))
        {
            // Guardamos el checkpoint real
            currentSpawnPoint = other.transform;

            // Lo desactivamos para que no lo vuelva a tomar
            other.gameObject.SetActive(false);
        }
    }

    void RespawnPlayer()
    {
        player.transform.position = currentSpawnPoint.position;
    }
}
