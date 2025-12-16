using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    [Header("Panels del menú")]
    public GameObject mainMenu;      // MainMenu
    public GameObject optionsMenu;   // MainOpciones
    public GameObject manualMenu;    // MainManual

    [Header("Botón Manual")]
    public GameObject btnManual;     // Btn-Manual

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        manualMenu.SetActive(false);

        if (btnManual != null)
            btnManual.SetActive(false);   // oculto al inicio
    }

    // =========================
    // MENÚ PRINCIPAL
    // =========================
    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        manualMenu.SetActive(false);

        if (btnManual != null)
            btnManual.SetActive(false);
    }

    // =========================
    // OPCIONES
    // =========================
    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        manualMenu.SetActive(false);

        if (btnManual != null)
            btnManual.SetActive(false);
    }

    // =========================
    // MANUAL
    // =========================
    public void OpenManualPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        manualMenu.SetActive(true);

        if (btnManual != null)
            btnManual.SetActive(true);   // 👈 solo aquí aparece
    }

    // =========================
    // JUGAR
    // =========================
    public void PlayGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene("L1-NILSON");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
