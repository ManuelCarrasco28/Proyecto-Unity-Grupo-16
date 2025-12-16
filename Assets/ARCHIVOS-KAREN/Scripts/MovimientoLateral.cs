using UnityEngine;

public class MovimientoObstaculoZ_Fluido : MonoBehaviour
{
    [Header("Movimiento del obstáculo")]
    [Tooltip("Distancia máxima en el eje Z desde la posición inicial.")]
    public float distancia = 5f;

    [Tooltip("Velocidad del movimiento.")]
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private float tiempo;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Movimiento suave ida y vuelta usando PingPong
        tiempo += Time.deltaTime * velocidad;

        float desplazamientoZ = Mathf.PingPong(tiempo, distancia * 2) - distancia;

        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y,
            posicionInicial.z + desplazamientoZ
        );
    }
}
