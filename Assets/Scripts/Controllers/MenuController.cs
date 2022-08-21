using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;

    [SerializeField]
    private CanvasGroup[] canvasGroup;

    [SerializeField]
    private SoundController soundController;

    private int actualIndex = 0;

    [Header("Nina")]
    [SerializeField]
    private GameObject ninaObject;
    [SerializeField]
    private GameObject[] ninaFaces;
    [SerializeField]
    private TextMeshProUGUI ninaText;
    [SerializeField]
    private string[] ninaSpeak;
    [SerializeField]
    private string[] ninaWithChromera;
    [SerializeField]
    private string[] ninaWithBoarderX;
    [SerializeField]
    private string[] ninaWithTheRingOfLegends;
    [SerializeField]
    private string[] ninaWithTrash;

    [Header("Virus")]
    [SerializeField]
    private GameObject virusAlert;
    [SerializeField]
    private GameObject buttonPlay;
    [SerializeField]
    private GameObject popupToEnableButtonPlay;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CanvasController(int index)
    {
        soundController.PlayClickMouse();
        panels[actualIndex].SetActive(false);
        actualIndex = index;
        panels[actualIndex].SetActive(true);
    }

    public void InitGame()
    {
        soundController.PlayClickMouse();
        panels[actualIndex].SetActive(false);
        ChangeCanvasGroup(0, false);
        ChangeCanvasGroup(1, true);
    }

    private void ChangeCanvasGroup(int i, bool active, bool interactableChange = false)
    {
        canvasGroup[i].alpha = active ? 1 : 0;
        canvasGroup[i].blocksRaycasts = active;
        if (interactableChange)
        {
            canvasGroup[i].interactable = active;
        }
        else
        {
            StartCoroutine(ChangeCanvasGroupInteractable(i, active));
        }
    }

    private IEnumerator ChangeCanvasGroupInteractable(int i, bool active)
    {
        yield return new WaitForSeconds(2f);
        canvasGroup[i].interactable = active;
    }

    private void ChangeNinaFace(int index)
    {
        for(int i = 0; i < ninaFaces.Length; i++)
        {
            if(i == index)
            {
                ninaFaces[i].SetActive(true);
            }
            else
            {
                ninaFaces[i].SetActive(false);
            }
        }
    }

    public void InitNinaDesktop()
    {
        soundController.PlayClickMouse();
        ChangeCanvasGroup(1, false);
        canvasGroup[2].alpha = 1;
        canvasGroup[2].blocksRaycasts = true;
        ChangeNinaSpeak();
    }

    private void ChangeNinaSpeak()
    {
        ninaText.text = ninaSpeak[0];
        StartCoroutine(AwaitNinaSpeak(1, 8f));
    }

    private IEnumerator AwaitNinaSpeak(int i, float time)
    {
        yield return new WaitForSeconds(time);
        if(i == 1)
        {
            ninaObject.SetActive(false);
            StartCoroutine(AwaitNinaSpeak(2, 3f));
        }
        else if(i == 2)
        {
            virusAlert.SetActive(true);
            StartCoroutine(AwaitNinaSpeak(3, 6f));
        }
        else if(i == 3)
        {
            virusAlert.SetActive(false);
            ninaObject.SetActive(true);
            ninaText.text = ninaSpeak[1];
            StartCoroutine(AwaitNinaSpeak(4, 8f));
        }
        else if(i == 4)
        {
            ninaObject.SetActive(false);
            canvasGroup[2].interactable = true;
        }
    }

    public void OpenPopupToEnableButtonPlay()
    {
        soundController.PlayClickMouse();
        popupToEnableButtonPlay.SetActive(true);
    }

    public void EnableButtonPlay()
    {
        soundController.PlayClickMouse();
        popupToEnableButtonPlay.SetActive(false);
        buttonPlay.SetActive(true);
    }

    public void PlayGame()
    {
        soundController.PlayClickMouse();
        ChangeCanvasGroup(2, false);
        SceneManager.LoadScene("Game");
    }

    public void OnClickChromera()
    {
        soundController.PlayClickMouse();
        ninaObject.SetActive(true);
        ninaText.text = ninaWithChromera[0];
        canvasGroup[2].interactable = false;
        ChangeNinaFace(1);
        StartCoroutine(AwaitChromera(1, 5f));
    }

    private IEnumerator AwaitChromera(int i, float time)
    {
        yield return new WaitForSeconds(time);
        if(i == 1)
        {
            ninaText.text = ninaWithChromera[i];
            StartCoroutine(AwaitChromera(2, 5f));
        }
        else
        {
            ninaObject.SetActive(false);
            canvasGroup[2].interactable = true;
        }
    }

    public void OnClickBoarderX()
    {
        soundController.PlayClickMouse();
        ninaObject.SetActive(true);
        ninaText.text = ninaWithBoarderX[0];
        canvasGroup[2].interactable = false;
        ChangeNinaFace(1);
        StartCoroutine(AwaitBoarderX(1, 5f));
    }

    private IEnumerator AwaitBoarderX(int i, float time)
    {
        yield return new WaitForSeconds(time);
        if (i == 1)
        {
            ninaText.text = ninaWithBoarderX[i];
            StartCoroutine(AwaitBoarderX(2, 5f));
        }
        else
        {
            ninaObject.SetActive(false);
            canvasGroup[2].interactable = true;
        }
    }

    public void OnClickTheRingOfLegends()
    {
        soundController.PlayClickMouse();
        ninaObject.SetActive(true);
        ninaText.text = ninaWithTheRingOfLegends[0];
        canvasGroup[2].interactable = false;
        ChangeNinaFace(1);
        StartCoroutine(AwaitTheRingOfLegends(1, 5f));
    }

    private IEnumerator AwaitTheRingOfLegends(int i, float time)
    {
        yield return new WaitForSeconds(time);
        if (i == 1)
        {
            ninaText.text = ninaWithTheRingOfLegends[i];
            StartCoroutine(AwaitTheRingOfLegends(2, 5f));
        }
        else
        {
            ninaObject.SetActive(false);
            canvasGroup[2].interactable = true;
        }
    }

    public void OnClickTrash()
    {
        soundController.PlayClickMouse();
        ninaObject.SetActive(true);
        ninaText.text = ninaWithTrash[0];
        canvasGroup[2].interactable = false;
        ChangeNinaFace(1);
        StartCoroutine(AwaitTrash(1, 5f));
    }

    private IEnumerator AwaitTrash(int i, float time)
    {
        yield return new WaitForSeconds(time);
        if (i == 1)
        {
            ninaText.text = ninaWithTrash[i];
            StartCoroutine(AwaitTrash(2, 5f));
        }
        else if(i == 2)
        {
            ninaText.text = ninaWithTrash[i];
            StartCoroutine(AwaitTrash(3, 2f));
        }
        else if(i == 3)
        {
            ninaObject.SetActive(false);
            canvasGroup[2].interactable = true;
        }
    }

    public void ExitGame()
    {
        soundController.PlayClickMouse();
        panels[actualIndex].SetActive(false);
        ChangeCanvasGroup(0, false);
        ChangeCanvasGroup(3, true);
    }

    public void BackToCredits()
    {
        soundController.PlayClickMouse();
        ChangeCanvasGroup(3, false);
        ChangeCanvasGroup(0, true);
        actualIndex = 2;
        panels[actualIndex].SetActive(true);
    }

    private void OnLevelWasLoaded(int level)
    {
        soundController = FindObjectOfType<SoundController>();
    }
}
