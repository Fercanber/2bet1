using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject player1, player2;
    private string tagCollision1 = null, tagCollision2 = null;


    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null)
        {
            Debug.Log("Hemos encontrado a Player1");
            player1.GetComponent<PlayerController>().eNotificarColision += playerIsCollision1;
        }

        player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null)
        {
            Debug.Log("Hemos encontrado a Player2");
            player2.GetComponent<PlayerController>().eNotificarColision += playerIsCollision2;
        }
    }

    void Update()
    {
       if(tagCollision1 != null && tagCollision2 != null)
        {
            if(tagCollision1 == tagCollision2)
            {
                Debug.Log("Destruyendo items");
                GameObject[] objs = GameObject.FindGameObjectsWithTag(tagCollision1);
                for(int i =0; i < objs.Length; i++) { 
                    Destroy(objs[i]); 
                }
            }
        }
    }

    void playerIsCollision1(string t)
    {
        tagCollision1 = t;
        Debug.Log("Hola soy el GameController y se que el player 1 esta colisionando con: " + t);
    }

    void playerIsCollision2(string t)
    {
        tagCollision2 = t;
        Debug.Log("Hola soy el GameController y se que el player 2 esta colisionando con: " + t);
    }
}
