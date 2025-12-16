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

    // ============================
    //      CICLO DE VIDA
    // ============================

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

        // ⚠️ SOLO bloquear cursor si es gameplay
        if (EsEscenaGameplay())
            BloquearCursor();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefrescarAudios();
        Pausa = false;
        Time.timeScale = 1;
        CerrarMenus();

        if (SliderSensibilidad != null)
            SliderSensibilidad.value = sensibilidad;

        // ❌ NO bloquear cursor en MENU ni END
        if (EsEscenaGameplay())
            BloquearCursor();
        else
            MostrarCursor();
    }

    // ============================
    //         UPDATE
    // ============================

    void Update()
    {
        // ❌ No forzar cursor fuera del gameplay
        if (!EsEscenaGameplay())
            return;

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

    // ============================
    //      MÉTODOS AUX
    // ============================

    bool EsEscenaGameplay()
    {
        string escena = SceneManager.GetActiveScene().name;
        return escena != "MENU" && escena != "END";
    }

    void RefrescarAudios()
    {
        todosLosAudios = FindObjectsOfType<AudioSource>();
    }

    void CerrarMenus()
    {
        ObjetoMenuPausa.SetActive(false);
        PanelPrincipal.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelSalir.SetActive(false);
    }

    // ============================
    //       PAUSA
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

    public void Resumir()
    {
        Pausa = false;
        RefrescarAudios();

        CerrarMenus();

        Time.timeScale = 1;
        BloquearCursor();

        foreach (AudioSource s in todosLosAudios)
            if (s != null) s.UnPause();
    }

    // ============================
    //      CURSOR
    // ============================

    void MostrarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void BloquearCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ============================
    //      BOTONES
    // ============================

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
