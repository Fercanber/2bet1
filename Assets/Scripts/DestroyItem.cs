using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        Destroy(gameObject);
    }
}
