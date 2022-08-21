using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource clickMouse;
    [SerializeField]
    private AudioSource collecting;
    [SerializeField]
    private AudioSource lose;
    [SerializeField]
    private AudioSource menuBackground;
    [SerializeField]
    private AudioSource terrorMusic;
    [SerializeField]
    private AudioSource win;

    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            PlayTerrorMusic();
        }
        else
        {
            PlayMenuBackground();
        }
    }

    public void PlayClickMouse()
    {
        clickMouse.Play();
    }

    public void PlayCollecting()
    {
        collecting.Play();
    }

    public void PlayLose()
    {
        lose.Play();
    }

    public void PlayMenuBackground()
    {
        menuBackground.Play();
    }

    public void PlayTerrorMusic()
    {
        terrorMusic.Play();
    }

    public void PlayWin()
    {
        win.Play();
    }

    /* Linhas para copiar onde quiser tocar algum dos sons:
     * private SoundController soundController;
     * 
     * No Start:
     * soundController = FindObjectOfType<SoundController>();
     * 
     * Para tocar qualquer uma, basta chamar o método PlayNomeDaMusicaOuEfeito
     */
}
