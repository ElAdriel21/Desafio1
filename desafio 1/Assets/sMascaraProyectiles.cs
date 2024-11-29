using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMascaraProyectiles : MonoBehaviour
{
    public sJugador jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "fantasma") || (collision.gameObject.tag == "narizon"))
        {
            collision.gameObject.GetComponent<sFantasma>().Reiniciar();
            jugador.RestarVida();
        }
    }
}
