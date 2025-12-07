using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

    private int score = 0;

    void Awake()
    {
        // Singleton para evitar duplicados
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Escuchar cuando se carga una escena nueva
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Por seguridad, desuscribir
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void Start()
    {
        BuscarTextoUI();
        ActualizarUI();
    }

    // Se llama cada vez que se carga una escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si volvemos al menú, reiniciamos el score
        if (scene.name == "MENU")
        {
            score = 0;
        }

        // Volvemos a buscar el texto de UI en la nueva escena
        BuscarTextoUI();
        ActualizarUI();
    }

    void BuscarTextoUI()
    {
        // Si ya tiene referencia, no hace falta buscar
        if (scoreText != null) return;

        // Busca SOLO el texto cuyo GameObject se llame "score"
        Text[] textos = FindObjectsOfType<Text>();
        foreach (Text t in textos)
        {
            if (t.gameObject.name == "score")
            {
                scoreText = t;
                break;
            }
        }
    }

    void ActualizarUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score + " Coins";
        }
    }

    public void AddPoint()
    {
        score++;
        ActualizarUI();
    }

    public int GetScore()
    {
        return score;
    }
}
