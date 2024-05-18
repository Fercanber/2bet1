using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{   
    private void Start()
    {
        
    }

    // Los unicos elementos que pueden colisionar con algun gameObject del mapa son los player.
    /*private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            ecollision();
        }
    }*/

}
