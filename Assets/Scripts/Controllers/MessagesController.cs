using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField]
    private string[] messages;

    [Header("Objects")]
    [SerializeField]
    private GameObject messageBackground;
    [SerializeField]
    private TextMeshProUGUI messageText;

    [Header("Variables")]
    [SerializeField]
    private float timeToShow = 3f;

    public void ShowMessage()
    {
        int i = Random.Range(0, messages.Length);
        messageText.text = messages[i];
        messageBackground.SetActive(true);
        StartCoroutine(CountToShowMessage());
    }

    public void ShowSpecifcMessage(int i)
    {
        messageText.text = messages[i];
        messageBackground.SetActive(true);
        StartCoroutine(CountToShowMessage());
    }

    private IEnumerator CountToShowMessage()
    {
        yield return new WaitForSeconds(timeToShow);
        messageBackground.SetActive(false);
    }

    public void ShowSpecifcMessageWithTime(int i, float time)
    {
        messageText.text = messages[i];
        messageBackground.SetActive(true);
        StartCoroutine(CountToShowMessageWithTime(time));
    }

    private IEnumerator CountToShowMessageWithTime(float time)
    {
        yield return new WaitForSeconds(time);
        messageBackground.SetActive(false);
    }

    /* Linhas para copiar onde a pontuação estiver sendo calculada:
     * Na lista de objetos:
     * private MessagesController menuController;
     * 
     * No Start:
     * menuController = FindObjectOfType<MessagesController>();
     * 
     * Para chamar uma mensagem aleatória usando o tempo pré definido:
     * menuController.ShowMessage();
     * Para chamar uma mensagem específica usando o tempo pré definido:
     * menuController.ShowSpecifcMessage(0);
     * Para chamar uma mensagem aleatória usando um tempo diferente:
     * menuController.ShowMessageWithTime(2f);
     * Para chamar uma mensagem específica usando um tempo diferente:
     * menuController.ShowSpecifcMessageWithTime(0, 2f);
     */
}
