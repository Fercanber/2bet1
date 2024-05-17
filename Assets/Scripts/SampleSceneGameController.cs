using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SampleSceneGameController : MonoBehaviourPunCallbacks
{
    public List<GameObject> buttonsListYellow = new List<GameObject>();
    public List<GameObject> buttonsListBlue =   new List<GameObject>();

    private GameObject player1, player2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null) Debug.Log("Jugador 1 localizado");

        player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player2 != null) Debug.Log("Jugador 2 localizado");
    }

    void Update()
    {
        for(int i = 0; i <  buttonsListYellow.Count; i++) {
            if(objetoJugadorColision(i, true) != null && objetoJugadorColision(i, false) != null)
            {
                Destroy(buttonsListYellow[i]);
                Destroy(buttonsListBlue[i]);
            }
        }
    }

    public String objetoJugadorColision(int index, Boolean isYelloItems)
    {
        List<GameObject> items;
        String tag = null;
        if (isYelloItems) items = buttonsListYellow;
        else items = buttonsListBlue;
        
        ItemController script = items[index].GetComponent<ItemController>();
        if (script != null)
        {
             tag = script.myTag;
         }
       
        return tag;
    }

}
