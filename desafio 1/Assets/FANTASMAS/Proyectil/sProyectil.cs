using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sProyectil : MonoBehaviour
{
    Vector3 direccion;
    public Vector3 target;
    bool mover = false;
    [SerializeField] float velocidad;
    void Start()
    {
        StartCoroutine("Dirigir");
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            // Mover el proyectil continuamente en la dirección calculada
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        }
    }

    IEnumerator Dirigir()
    {
        yield return new WaitForSeconds(1); // Espera antes de empezar a moverse

        // Calcular la dirección inicial hacia el objetivo
        direccion = (target - transform.position).normalized;

        // Activar el movimiento
        mover = true;
    }
}
