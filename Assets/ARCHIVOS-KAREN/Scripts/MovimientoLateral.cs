using UnityEngine;

public class MovimientoLateral : MonoBehaviour
{
    [Header("Configuración de movimiento")]
    [Tooltip("Distancia máxima hacia cada lado desde el punto inicial.")]
    public float distancia = 5f;

    [Tooltip("Velocidad de movimiento.")]
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private int direccion = 1; 

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, posicionInicial) >= distancia)
        {
            direccion *= -1;
        }
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
