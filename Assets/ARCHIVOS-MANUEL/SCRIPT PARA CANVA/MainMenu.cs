using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    [Header("Panels del menú")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    void Start()
    {
        // Asegura que, al volver desde pausa u otra escena, todo funcione bien
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Activar el panel principal al entrar al menú
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Abre las opciones
    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Vuelve al menú principal
    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Cargar el juego
    public void PlayGame()
    {
        Time.timeScale = 1;                 // Asegurar que el juego no esté pausado
        Cursor.visible = false;             // Cursor oculto para gameplay
        Cursor.lockState = CursorLockMode.Locked;

        SceneManager.LoadScene("L1-NILSON");  // Cambia por el nombre exacto de tu escena
    }

    // Salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
}
    