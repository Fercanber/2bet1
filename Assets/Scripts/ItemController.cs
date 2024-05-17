using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public delegate void Pulsado();
    public event Pulsado BotonPulsado;

    public string myTag;

    private void OnTriggerStay2D(Collider2D collider)
    {
        myTag = collider.gameObject.tag;
        Debug.Log(myTag + "TRIGUER stay");
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        myTag = null;
        Debug.Log(myTag + "HA SALIDO DEL TRIGUER");
    }
}
