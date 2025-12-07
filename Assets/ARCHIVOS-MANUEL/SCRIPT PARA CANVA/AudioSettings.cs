using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider sliderMusica;

    void Start()
    {
        // SI existe un volumen guardado, úsalo
        // SI NO existe, asigna valor por defecto = 0.5
        float volumen = PlayerPrefs.GetFloat("volumen", 0.5f);

        sliderMusica.value = volumen;

        AudioListener.volume = volumen;

        sliderMusica.onValueChanged.AddListener(CambiarVolumen);
    }

    public void CambiarVolumen(float v)
    {
        AudioListener.volume = v;
        PlayerPrefs.SetFloat("volumen", v);
    }
}
