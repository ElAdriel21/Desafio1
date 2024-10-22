using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFuegoRojo : MonoBehaviour
{
    public Transform objetoCentral;  // El objeto alrededor del cual orbitará
    public float velocidadOrbita = 5f;  // Velocidad de la órbita
    public float distanciaOrbita = 3f;  // Distancia desde el objeto central

    private float angulo = 0f;

    public sLimpiador limpiador;
    void Update()
    {
        if (objetoCentral != null)
        {
            // Aumenta el ángulo en función del tiempo y la velocidad
            angulo += velocidadOrbita * Time.deltaTime;

            // Calcula la nueva posición en base al ángulo
            float x = Mathf.Cos(angulo) * distanciaOrbita;
            float y = Mathf.Sin(angulo) * distanciaOrbita;

            transform.position = new Vector2(objetoCentral.position.x + x, objetoCentral.position.y + y);
        }
    }

    public void IniciarOrbitacion(GameObject erilda)
    {
        objetoCentral = erilda.GetComponent<Transform>();
    }
}
