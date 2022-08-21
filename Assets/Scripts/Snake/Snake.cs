using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Direção que a cobra vai se movimentar
    Vector2 dir = Vector2.right;
    
    // A snake comeu algo
    bool ate = false;

    // Tail prefab
    public GameObject tailPrefab;

    // Tail
    List<Transform> tail = new List<Transform>();

    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //Controles do jogo
        if(Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if(Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if(Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if(Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
    }

    void Move()
    {   // Salvando a coordenada atual;
        Vector2 v = transform.position;
        // Movimentar a cabeça da cobra
        transform.Translate(dir);
        // Cauda (Tail)
        if (ate)
        {   // Criar a cauda
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            // Definir o elemento como o início da cauda
            tail.Insert(0, g.transform);
            // Food comida
            ate = false;
        }
        else if(tail.Count>0)
        {   // Muda a coordenada de tela do elemento
            tail[tail.Count - 1].position = v;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) 
    {
        // Verifica se é food
        if (coll.name.StartsWith("Food"))
        {   // Comeu a food
            ate = true;
            // Destroi a food
            Destroy(coll.gameObject);
        }
        else
        {   //Fim de jogo
            Debug.Log("Morreu!!!");
        }
    }
}
