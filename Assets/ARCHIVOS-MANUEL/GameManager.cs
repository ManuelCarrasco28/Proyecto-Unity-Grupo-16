using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Menú de Pausa")]
    public GameObject menuPausaPrefab;
    private GameObject menuPausaInstance;

    private static GameManager instance;

    void Awake()
    {
        // ============================
        //  SINGLETON
        // ============================
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Escuchar cambio de escenas
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Evitar errores al salir del juego
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    // ============================
    //  MANEJO DE ESCENAS
    // ============================
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ============================
        //  ESCENAS DE UI → CURSOR VISIBLE
        // ============================
        if (scene.name == "MENU" || scene.name == "END")
        {
            Time.timeScale = 1f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // ============================
            //  ESCENAS DE JUEGO → CURSOR OCULTO
            // ============================
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // ============================
        //  MENU PRINCIPAL
        // ============================
        if (scene.name == "MENU")
        {
            // Destruir menú pausa si existe
            if (menuPausaInstance != null)
            {
                Destroy(menuPausaInstance);
                menuPausaInstance = null;
            }
            return;
        }

        // ============================
        //  CREAR MENÚ PAUSA EN GAMEPLAY
        // ============================
        if (menuPausaInstance == null)
        {
            menuPausaInstance = Instantiate(menuPausaPrefab);
            DontDestroyOnLoad(menuPausaInstance);
        }
    }
}
