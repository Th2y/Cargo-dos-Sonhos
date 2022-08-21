using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Direção que a cobra vai se movimentar
    Vector2 dir = Vector2.right;
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        transform.Translate(dir);
    }
}
