using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private float volumeGeral = 1f;
    private float volumeEffects = 1f;
    private float volumeMusics = 1f;
    private string volumeGeralPref = "VolumeGeral";
    private string volumeEffectsPref = "VolumeEffects";
    private string volumeMusicsPref = "VolumeMusics";

    [SerializeField]
    private Slider sliderGeral, sliderEffects, sliderMusics;

    void Start()
    {
        volumeGeral = PlayerPrefs.GetFloat(volumeGeralPref, volumeGeral);
        sliderGeral.value = volumeGeral;

        volumeEffects = PlayerPrefs.GetFloat(volumeEffectsPref, volumeEffects);
        sliderEffects.value = volumeEffects;

        volumeMusics = PlayerPrefs.GetFloat(volumeMusicsPref, volumeMusics);
        sliderMusics.value = volumeMusics;
    }

    public void VolumeGeral(float volume)
    {
        volumeGeral = volume;
        AudioListener.volume = volumeGeral;

        PlayerPrefs.SetFloat(volumeGeralPref, volumeGeral);
    }

    public void VolumeEffects(float volume)
    {
        volumeEffects = volume;
        GameObject[] efeito = GameObject.FindGameObjectsWithTag("SoundEffect");
        if (efeito.Length > 0)
        {
            for (int i = 0; i < efeito.Length; i++)
            {
                efeito[i].GetComponent<AudioSource>().volume = volumeEffects;
            }
        }

        PlayerPrefs.SetFloat(volumeEffectsPref, volumeEffects);
    }

    public void VolumeMusics(float volume)
    {
        volumeMusics = volume;
        GameObject[] musica = GameObject.FindGameObjectsWithTag("Music");
        if (musica.Length > 0)
        {
            for (int i = 0; i < musica.Length; i++)
            {
                musica[i].GetComponent<AudioSource>().volume = volumeMusics;
            }
        }

        PlayerPrefs.SetFloat(volumeMusicsPref, volumeMusics);
    }
}
