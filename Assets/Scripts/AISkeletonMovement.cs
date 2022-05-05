using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkeletonMovement : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    Transform player; // posicion del personaje 

    [SerializeField]
    float rangoAgro; // a que distancia ve el enemigo al jugador 
    public float velocidadMov;
    private bool miraDerecha;

    Rigidbody2D rgb2d;

    // Start is called before the first frame update
    void Start()
    {
        miraDerecha = true;
        rgb2d = GetComponent<Rigidbody2D>(); // con esto se guarda el componente en la variable
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distancia hasta el jugador 
        float distJugador = Vector2.Distance(transform.position, player.position); // el primer parametro es la pos del enemigo y la segunda es la pos del jugador 
        Debug.Log("Distancia del jugador"+distJugador);


        // cuando la distancia del jugador sea menor al rango agro persigalo
        // solamente lo va persegui cuando este a uno de distancia 
        if (distJugador < rangoAgro && Mathf.Abs(distJugador) > 1)
        {
            Perseguir();
            anim.SetFloat("velocidad", 1); // Dispara animacion de moverse 
            anim.SetBool("atacar", false);
        }
        // si la distancia es menor a 1 atacamos 
        else if (Mathf.Abs(distJugador) < 1)
        {
            anim.SetBool("atacar", true);
        }
        else
        {
            NoPerseguir();
            // estamos quietos
            anim.SetFloat("velocidad", 0);
        }
    }

    private void NoPerseguir()
    {

    }

    private void Perseguir()
    {
        // si estamos a la izquierda del jugador entonces movemos al enemigo a la derecha y no miro a la derecha
        if (transform.position.x < player.position.x && !miraDerecha)
        {
            rgb2d.velocity = new Vector2(velocidadMov, 0f);
            Flip();
        }// Si estamos a la derecha del jugador movemos el enemigo a la izquierda
        else if (transform.position.x > player.position.x && miraDerecha)
        {
            rgb2d.velocity = new Vector2(-velocidadMov, 0f);
            Flip();
        }
        // si ya esta mirando a la drecha entonces avanza 
        else if (!miraDerecha)
        { 
            rgb2d.velocity = new Vector2(-velocidadMov,0f);
        }
        else if (miraDerecha)
        {
            rgb2d.velocity = new Vector2(velocidadMov, 0f);
        }
    }

    private void Flip()
    {
        // defino hacia donde esta mirando el jugador 
        // Guardando lo opuesto de mira a la derecha 
        miraDerecha = !miraDerecha;
        //Multiplicar la escala en x del personaje por -1
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;

    }
}
