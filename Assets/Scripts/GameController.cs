using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameController : MonoBehaviourPunCallbacks
{
    private GameObject player1, player2;
    
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null)
        {
            Debug.Log("Hemos encontrado a Player1");
            player1.GetComponent<PlayerController>().eNotificarColision += playerIsCollision;
        }

        player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null)
        {
            Debug.Log("Hemos encontrado a Player2");
            player2.GetComponent<PlayerController>().eNotificarColision += playerIsCollision;
        }
    }

    void Update()
    {
       
    }

    void playerIsCollision(string t)
    {
        Debug.Log("Hola soy el gameController se que el player esta colisionando con el objeto: " + t);
    }
}
