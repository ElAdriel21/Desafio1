using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sProyectil : MonoBehaviour
{
    [SerializeField] float velocidad = 5f; // Velocidad
    [SerializeField] Vector2 direccion;
    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Destruir el proyectil cuando salga de la pantalla
        Destroy(gameObject);
    }
}
