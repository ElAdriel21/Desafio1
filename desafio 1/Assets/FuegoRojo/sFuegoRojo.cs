using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sFuegoRojo : MonoBehaviour
{
    public Transform objetoCentral;  // El objeto alrededor del cual orbitará
    public float velocidadOrbita = 5f;  // Velocidad de la órbita
    public float distanciaOrbita = 3f;  // Distancia desde el objeto central

    [SerializeField] bool isGoingToPlant = false;

    private float angulo = 0f;

    public sLimpiador limpiador;

    public GameObject plant;

    [SerializeField] float velocidad = 4;
    float distanciaDestruccion = 0.1f;
    void Update()
    {
        if ((objetoCentral != null) && (!isGoingToPlant))
        {
            // Aumenta el ángulo en función del tiempo y la velocidad
            angulo += velocidadOrbita * Time.deltaTime;

            // Calcula la nueva posición en base al ángulo
            float x = Mathf.Cos(angulo) * distanciaOrbita;
            float y = Mathf.Sin(angulo) * distanciaOrbita;

            transform.position = new Vector2(objetoCentral.position.x + x, objetoCentral.position.y + y);
        }

        if (isGoingToPlant)
        {
            Vector3 direccion = (plant.transform.position - transform.position).normalized;

            transform.position += direccion * velocidad * Time.deltaTime;

            float distancia = Vector3.Distance(transform.position, plant.transform.position);
            if (distancia <= distanciaDestruccion)
            {
                Destroy(gameObject);
            }
        }
    }

    public void IniciarOrbitacion(GameObject erilda)
    {
        objetoCentral = erilda.GetComponent<Transform>();
    }

    public void ToPlant()
    {
        print("XD");
        objetoCentral = null;
        isGoingToPlant = true;
    }
}
