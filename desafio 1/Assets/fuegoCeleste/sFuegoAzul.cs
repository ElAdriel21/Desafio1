using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFuegoAzul : MonoBehaviour
{
    [SerializeField] sFuegoRojo fuegoRojo;
    public sLimpiador limpiador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Erilda") 
        {
            sFuegoRojo fuego = Instantiate(fuegoRojo, transform.position, Quaternion.identity);
            fuego.objetoCentral = collision.gameObject.transform;
            limpiador.AgregarElemento(fuego.gameObject);
            collision.gameObject.GetComponent<sJugador>().SumarAlma();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "mascaraErilda")
        {
            sFuegoRojo fuego = Instantiate(fuegoRojo, transform.position, Quaternion.identity);
            fuego.objetoCentral = collision.gameObject.transform;
            limpiador.AgregarElemento(fuego.gameObject);
            collision.gameObject.GetComponent<sMascaraProyectiles>().jugador.SumarAlma();
            Destroy(gameObject);
        }
    }
}
