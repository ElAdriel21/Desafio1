using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMascaraProyectiles : MonoBehaviour
{
    [SerializeField] sJugador jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fantasma")
        {
            Destroy(collision.gameObject);
            jugador.RestarVida();
        }
    }
}
