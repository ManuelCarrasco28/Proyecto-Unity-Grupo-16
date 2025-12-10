using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTrigger : MonoBehaviour
{
    [Tooltip("Tiempo (en segundos) que el jugador debe permanecer sobre el cubo.")]
    public float tiempoParaActivar = 5f;

    private bool jugadorDentro = false;
    private float tiempoDentro = 0f;
    private Collider col;
    private bool triggerActivado = false;

    void Start()
    {
        col = GetComponent<Collider>();

        col.isTrigger = false;
    }

    void Update()
    {
        if (jugadorDentro && !triggerActivado)
        {
            tiempoDentro += Time.deltaTime;

            if (tiempoDentro >= tiempoParaActivar)
            {
                col.isTrigger = true;
                triggerActivado = true;
                jugadorDentro = false;

                Debug.Log($" {gameObject.name} ahora es Trigger después de {tiempoParaActivar} segundos.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !triggerActivado)
        {
            jugadorDentro = true;
            tiempoDentro = 0f;
            Debug.Log("Jugador entró al cubo.");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorDentro = false;
            tiempoDentro = 0f;
            Debug.Log("Jugador salió del cubo, contador reiniciado.");
        }
    }

    public void ReiniciarCubo()
    {
        jugadorDentro = false;
        tiempoDentro = 0f;
        triggerActivado = false;

        if (col != null)
            col.isTrigger = false;

        Debug.Log($" {gameObject.name} fue reiniciado (IsTrigger = false).");
    }
}
