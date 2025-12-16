using UnityEngine;

public class MovimientoVertical_Fluido : MonoBehaviour
{
    [Header("Configuración de movimiento vertical")]
    [Tooltip("Altura máxima desde la posición inicial (eje Y).")]
    public float distancia = 3f;

    [Tooltip("Velocidad del movimiento vertical.")]
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private float tiempo;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Movimiento suave arriba y abajo
        tiempo += Time.deltaTime * velocidad;

        float desplazamientoY = Mathf.PingPong(tiempo, distancia * 2) - distancia;

        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y + desplazamientoY,
            posicionInicial.z
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
