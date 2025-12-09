using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Codigo_Pausa : MonoBehaviour
{
    [Header("Menus")]
    public GameObject ObjetoMenuPausa;
    public GameObject PanelPrincipal;
    public GameObject PanelOpciones;
    public GameObject PanelSalir;

    [Header("Sensibilidad")]
    public Slider SliderSensibilidad;
    public static float sensibilidad = 1f;

    private bool Pausa = false;
    private AudioSource[] todosLosAudios;

    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void Start()
    {
        RefrescarAudios();
        CerrarMenus();
        Pausa = false;

        if (SliderSensibilidad != null)
            SliderSensibilidad.value = sensibilidad;

        Time.timeScale = 1;
        BloquearCursor();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefrescarAudios();
        Pausa = false;
        Time.timeScale = 1;
        CerrarMenus();
        BloquearCursor();

        if (SliderSensibilidad != null)
            SliderSensibilidad.value = sensibilidad;
    }

    void Update()
    {
        // 🔥 FIX DEFINITIVO: Unity activa el cursor al presionar ESC aunque no quieras
        if (!Pausa && Cursor.lockState != CursorLockMode.Locked)
        {
            BloquearCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
                AbrirPausa();
            else
                Resumir();
        }

        if (SliderSensibilidad != null)
            sensibilidad = SliderSensibilidad.value;
    }

    void RefrescarAudios() => todosLosAudios = FindObjectsOfType<AudioSource>();

    void CerrarMenus()
    {
        ObjetoMenuPausa.SetActive(false);
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);
    }

    // ============================
    //       ABRIR PAUSA
    // ============================

    void AbrirPausa()
    {
        Pausa = true;
        RefrescarAudios();

        ObjetoMenuPausa.SetActive(true);
        PanelPrincipal.SetActive(true);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);

        Time.timeScale = 0;
        MostrarCursor();

        foreach (AudioSource s in todosLosAudios)
            if (s != null) s.Pause();
    }

    // ============================
    //         RESUMIR
    // ============================

    public void Resumir()
    {
        Pausa = false;
        RefrescarAudios();

        ObjetoMenuPausa.SetActive(false);
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);

        Time.timeScale = 1;
        BloquearCursor();

        foreach (AudioSource s in todosLosAudios)
            if (s != null) s.UnPause();
    }

    // ============================
    //   MANEJO DEL CURSOR
    // ============================

    private void MostrarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void BloquearCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ----------------------------

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

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
