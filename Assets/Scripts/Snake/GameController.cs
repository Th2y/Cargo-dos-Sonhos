using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{   
    //Head prefab
    public GameObject headPrefab;
    public GameObject pnMenuGameOver;
    public SpawnFood spawnFood;

    private bool gamePlay = false;

    //termina o jogo 
    public void GameOver()
    {
        Destroy(headPrefab.gameObject);
        pnMenuGameOver.SetActive(true);
    } 
}
