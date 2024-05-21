using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParesBotones : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject[] botones; // Array de botones (sprites)

    private Dictionary<GameObject, bool> player1Touching;
    private Dictionary<GameObject, bool> player2Touching;

    void Start()
    {
        // Inicializa los diccionarios para rastrear las colisiones
        player1Touching = new Dictionary<GameObject, bool>();
        player2Touching = new Dictionary<GameObject, bool>();

        foreach (var boton in botones)
        {
            player1Touching[boton] = false;
            player2Touching[boton] = false;
        }
    }

    void Update()
    {
        // Verifica las colisiones para ambos jugadores
        foreach (var boton in botones)
        {
            if (player1Touching[boton] && player2Touching[boton])
            {
                Debug.Log("Ambos jugadores están tocando el botón: " + boton.name);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica las colisiones para el jugador 1
        if (collision.gameObject == player1)
        {
            foreach (var boton in botones)
            {
                if (boton.GetComponent<Collider2D>().IsTouching(player1.GetComponent<Collider2D>()))
                {
                    player1Touching[boton] = true;
                }
            }
        }

        // Verifica las colisiones para el jugador 2
        if (collision.gameObject == player2)
        {
            foreach (var boton in botones)
            {
                if (boton.GetComponent<Collider2D>().IsTouching(player2.GetComponent<Collider2D>()))
                {
                    player2Touching[boton] = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Verifica cuando el jugador 1 deja de tocar un botón
        if (collision.gameObject == player1)
        {
            foreach (var boton in botones)
            {
                if (!boton.GetComponent<Collider2D>().IsTouching(player1.GetComponent<Collider2D>()))
                {
                    player1Touching[boton] = false;
                }
            }
        }

        // Verifica cuando el jugador 2 deja de tocar un botón
        if (collision.gameObject == player2)
        {
            foreach (var boton in botones)
            {
                if (!boton.GetComponent<Collider2D>().IsTouching(player2.GetComponent<Collider2D>()))
                {
                    player2Touching[boton] = false;
                }
            }
        }
    }
}
