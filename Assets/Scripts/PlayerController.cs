using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ItemController;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public delegate void ENotificarColision(string tag);
    public event ENotificarColision eNotificarColision ;

    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
           movement.x = Input.GetAxis("Horizontal");
           movement.y = Input.GetAxis("Vertical");

           animator.SetFloat("Horizontal", movement.x);
           animator.SetFloat("Vertical", movement.y);
           animator.SetFloat("Speed", movement.sqrMagnitude);

           rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Vela" 
            || collider.gameObject.tag == "Pocion"
             || collider.gameObject.tag == "Pala"
              || collider.gameObject.tag == "Compas"
               || collider.gameObject.tag == "Vino"
                || collider.gameObject.tag == "Pluma"
                  || collider.gameObject.tag == "Cruz"
                    || collider.gameObject.tag == "PocionV"
                     || collider.gameObject.tag == "Pergamino"
                      || collider.gameObject.tag == "Puente")
        {
            Debug.Log("Player controller esta colisionando con: " + collider.gameObject.tag);
            eNotificarColision(collider.gameObject.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Vela"
           || collider.gameObject.tag == "Pocion"
            || collider.gameObject.tag == "Pala"
             || collider.gameObject.tag == "Compas"
              || collider.gameObject.tag == "Vino"
               || collider.gameObject.tag == "Pluma"
                 || collider.gameObject.tag == "Cruz"
                   || collider.gameObject.tag == "PocionV"
                    || collider.gameObject.tag == "Pergamino"
                     || collider.gameObject.tag == "Puente")
        {
            eNotificarColision(null);
        }
    }

}
