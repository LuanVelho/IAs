using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inimigo : MonoBehaviour 
{
    private Transform posicaoDoJogador;

    public float velocidadeDoInimigo;
    private bool seguir = false;

    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seguir = true;
        }
    }

    void Update()
    {
        if (seguir == true)
        {
            SeguirJogador();
        }
    }

    private void SeguirJogador()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeDoInimigo * Time.deltaTime);

    }
}
