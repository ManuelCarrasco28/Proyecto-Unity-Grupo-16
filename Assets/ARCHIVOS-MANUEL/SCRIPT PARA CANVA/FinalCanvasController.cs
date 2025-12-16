using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCanvasController : MonoBehaviour
{
    private void OnEnable()
    {
        // Forzar estado correcto del juego
        Time.timeScale = 1f;

        // Mouse visible en pantalla final
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // =========================
    // BOTÓN: JUGAR DE NUEVO
    // =========================
    public void JugarDeNuevo()
    {
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // 🔴 REINICIAR FRAGMENTOS
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }

        SceneManager.LoadScene("L1-NILSON");
    }

    // =========================
    // BOTÓN: IR AL MENÚ
    // =========================
    public void IrAlMenu()
    {
        Time.timeScale = 1f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("MENU");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
