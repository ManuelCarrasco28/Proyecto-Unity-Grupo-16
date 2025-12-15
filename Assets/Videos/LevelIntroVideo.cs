using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class LevelIntroVideo : MonoBehaviour
{
    [Header("Video")]
    public VideoPlayer videoPlayer;
    public GameObject videoCanvas;

    [Header("Jugador")]
    public GameObject player;

    [Header("Música del nivel")]
    public AudioSource levelMusic; // Música del nivel

    [Header("Omitir")]
    public Button skipButton;
    public float skipDelay = 2f;

    private bool canSkip = false;

    void Start()
    {
        // Apagar música del nivel al inicio
        if (levelMusic != null)
            levelMusic.Stop();

        // Desactivar jugador
        if (player != null)
            player.SetActive(false);

        // Configurar botón Omitir
        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(false);
            skipButton.onClick.AddListener(SkipIntro);
        }

        // Evento cuando termina el video
        videoPlayer.loopPointReached += OnVideoFinished;

        // Reproducir video
        videoPlayer.Play();

        // Activar omitir después de X segundos
        Invoke(nameof(EnableSkip), skipDelay);
    }

    void Update()
    {
        if (!canSkip) return;

        if (Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0))
        {
            SkipIntro();
        }
    }

    void EnableSkip()
    {
        canSkip = true;

        if (skipButton != null)
            skipButton.gameObject.SetActive(true);
    }

    void SkipIntro()
    {
        EndIntro();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        EndIntro();
    }

    void EndIntro()
    {
        // Ocultar canvas del video
        if (videoCanvas != null)
            videoCanvas.SetActive(false);

        // Activar jugador
        if (player != null)
            player.SetActive(true);

        // Iniciar música del nivel
        if (levelMusic != null)
            levelMusic.Play();
    }
}
