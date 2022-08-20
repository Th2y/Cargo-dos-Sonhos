using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    // Definir os limites das bordas para criar a comida
    public Transform borderTop;
    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderBottom;

    //Prefab da comida
    public GameObject foodPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() // Define a area de limite e escolhe um local para o objeto
    {
        int x = (int)Random.Range(borderLeft.position.x,borderRight.position.x);
        int y = (int)Random.Range(borderTop.position.y,borderBottom.position.y);
        // Cria a comida
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
