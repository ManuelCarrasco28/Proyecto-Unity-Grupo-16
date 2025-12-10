using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPantalla : MonoBehaviour
{
    public static WinPantalla inst;

    public TextMeshProUGUI TimeCounterGameplay;
    public TextMeshProUGUI TimeCounterWin;
    private float TimeSeconds;
    private int TimeMinutes;

    public Button Reintentar_btn;


    private bool Win;

    public GameObject WinScreen;

    void Awake()
    {
        inst = this;

        Reintentar_btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
        Win = true;
        TimeCounterWin.text = "Tiempo: " + TimeMinutes + ":" + Mathf.Ceil(TimeSeconds);
        TimeCounterGameplay.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
{
        if (!Win)
        {
            TimeSeconds += Time.deltaTime;

            if (TimeSeconds >= 59)
            {
                TimeMinutes++;
                TimeSeconds = 0;
            }

            TimeCounterGameplay.text = "Tiempo: " + TimeMinutes + ":" + Mathf.Ceil(TimeSeconds);
        }
    }
}
