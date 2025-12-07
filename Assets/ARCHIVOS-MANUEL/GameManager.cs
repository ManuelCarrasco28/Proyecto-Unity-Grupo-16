using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPausaPrefab;
    private GameObject menuPausaInstance;

    private static GameManager instance;

    void Awake()
    {
        // Singleton: evitar duplicados de GameManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Escuchar cambios de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ⛔ SI LA ESCENA ES MENU → DESTRUIR MENÚ PAUSA
        if (scene.name == "MENU")
        {
            if (menuPausaInstance != null)
            {
                Destroy(menuPausaInstance);
                menuPausaInstance = null;
            }
            return;
        }

        // ✔ CREAR MENÚ PAUSA SOLO UNA VEZ
        if (menuPausaInstance == null)
        {
            menuPausaInstance = Instantiate(menuPausaPrefab);
            DontDestroyOnLoad(menuPausaInstance);
        }
    }
}
