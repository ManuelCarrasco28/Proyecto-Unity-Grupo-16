using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoToEndScene : MonoBehaviour
{
    [Header("Canvas del video (en L5)")]
    public GameObject videoCanvas;

    [Header("Video")]
    public VideoPlayer videoPlayer;

    [Header("Música del nivel 5")]
    public AudioSource levelMusic;

    [Header("Omitir")]
    public Button skipButton;
    public float skipDelay = 2f;

    [Header("Escena final")]
    public string endSceneName = "END";

    private bool canSkip = false;
    private bool finished = false;

    void Start()
    {
        Time.timeScale = 1f;

        // Apaga música del nivel 5
        if (levelMusic != null)
            levelMusic.Stop();

        if (videoCanvas != null)
            videoCanvas.SetActive(true);

        // Durante el video, cursor oculto (opcional)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        videoPlayer.loopPointReached += OnVideoEnd;

        if (skipButton != null)
        {
            skipButton.gameObject.SetActive(false);
            skipButton.onClick.AddListener(SkipVideo);
        }

        videoPlayer.Play();
        Invoke(nameof(EnableSkip), skipDelay);
    }

    void Update()
    {
        if (!canSkip || finished) return;

        if (Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0))
        {
            SkipVideo();
        }
    }

    void EnableSkip()
    {
        canSkip = true;
        if (skipButton != null)
            skipButton.gameObject.SetActive(true);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        GoToEndScene();
    }

    public void SkipVideo()
    {
        if (finished) return;

        videoPlayer.Stop();
        GoToEndScene();
    }

    void GoToEndScene()
    {
        if (finished) return;
        finished = true;

        if (videoCanvas != null)
            videoCanvas.SetActive(false);

        // IMPORTANTE: antes de cambiar escena, suelta el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 1f;

        SceneManager.LoadScene(endSceneName);
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
