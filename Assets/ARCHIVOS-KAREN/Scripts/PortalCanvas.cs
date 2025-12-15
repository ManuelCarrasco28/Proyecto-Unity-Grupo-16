using UnityEngine;

public class PortalCanvas : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject canvasUI;   // Canvas que se mostrará

    private void Start()
    {
        // Asegura que el canvas esté oculto al iniciar
        if (canvasUI != null)
            canvasUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canvasUI != null)
                canvasUI.SetActive(true);
        }
    }
}
