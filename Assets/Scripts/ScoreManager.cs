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
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
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

    // =========================
    // CUANDO CARGA UNA ESCENA
    // =========================
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 🔁 Reiniciar solo cuando volvemos al menú
        if (scene.name == "MENU")
        {
            ResetScore();
        }

        BuscarTextoUI();
        ActualizarUI();
    }

    // =========================
    // BUSCAR TEXTO UI
    // =========================
    void BuscarTextoUI()
    {
        scoreText = null;

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

    // =========================
    // ACTUALIZAR UI
    // =========================
    void ActualizarUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score + " Fragmentos";
        }
    }

    // =========================
    // SUMAR FRAGMENTO
    // =========================
    public void AddPoint()
    {
        score++;
        ActualizarUI();
    }

    // =========================
    // 🔴 REINICIAR FRAGMENTOS
    // =========================
    public void ResetScore()
    {
        score = 0;
        ActualizarUI();
    }

    public int GetScore()
    {
        return score;
    }
}
