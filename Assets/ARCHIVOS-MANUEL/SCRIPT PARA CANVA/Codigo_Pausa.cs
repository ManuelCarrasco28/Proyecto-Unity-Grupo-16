using UnityEngine;
using UnityEngine.SceneManagement;

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public GameObject PanelPrincipal;
    public GameObject PanelOpciones;
    public GameObject PanelSalir;

    private bool Pausa = false;
    private AudioSource[] todosLosAudios;

    void Start()
    {
        // Guardar todos los audios de la escena
        todosLosAudios = FindObjectsOfType<AudioSource>();

        // Estado inicial
        ObjetoMenuPausa.SetActive(false);
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
                AbrirPausa();
            else
                Resumir();
        }
    }

    // ========== PAUSAR ==========
    void AbrirPausa()
    {
        if (Pausa) return; // ⛔ Previene doble apertura

        Pausa = true;

        ObjetoMenuPausa.SetActive(true);
        PanelPrincipal.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        foreach (AudioSource s in todosLosAudios)
            s.Pause();
    }

    // ========== OPCIONES ==========
    public void AbrirOpciones()
    {
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(true);
        PanelSalir.SetActive(false);
    }

    public void VolverDesdeOpciones()
    {
        PanelPrincipal.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);
    }

    // ========== REANUDAR ==========
    public void Resumir()
    {
        if (!Pausa) return; // ⛔ Previene cerrar dos veces

        Pausa = false;

        ObjetoMenuPausa.SetActive(false);
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (AudioSource s in todosLosAudios)
            s.UnPause();
    }

    // ========== IR AL MENÚ ==========
    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu);
    }

    // ========== SALIR ==========
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
