using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    private int actualIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CanvasController(int index)
    {
        panels[actualIndex].SetActive(false);
        actualIndex = index;
        panels[actualIndex].SetActive(true);
    }

    public void InitGame()
    {
        SceneManager.LoadScene("Game");
        panels[actualIndex].SetActive(false);
    }

    public void ReinitGame()
    {
        SceneManager.LoadScene("Game");
        panels[actualIndex].SetActive(false);
    }
}
