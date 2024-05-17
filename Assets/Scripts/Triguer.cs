using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triguer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Triguer!!!!");
    }

    private void DestroyOnColision2D(Collider2D collider){
        Destroy(collider.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collider){
        Debug.Log("Estoy dentro de la colision");
    }
}
