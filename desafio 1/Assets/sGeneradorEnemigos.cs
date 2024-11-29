using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGeneradorEnemigos : MonoBehaviour
{
    [SerializeField] GameObject proyectilSup, proyectilDer, proyectilIzq;
    private int tipoAtaque, posicionAtaque;

    public bool almascosechadas = false;

    [SerializeField] sLimpiador limpiador;

    GameObject newFantasma;
    void Start()
    {
    }

    void Update()
    {    
    }

    public void ComenzarGeneracion()
    {
        //StartCoroutine("GenerarEnemigo");
    }

    public void DetenerGeneracion()
    {
        StopAllCoroutines();
    }

    IEnumerator GenerarEnemigo()
    {
        yield return new WaitForSeconds(2);
        tipoAtaque = Random.Range(0, 3);
        switch(tipoAtaque)
        {
            case 0:
                posicionAtaque = Random.Range(0, 12);
                switch (posicionAtaque)
                {
                    case 0:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-6, 6), Quaternion.identity);
                        break;
                    case 1:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-5, 6), Quaternion.identity);
                        break;
                    case 2:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-4, 6), Quaternion.identity);
                        break;
                    case 3:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-3, 6), Quaternion.identity);
                        break;
                    case 4:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-2, 6), Quaternion.identity);
                        break;
                    case 5:
                        newFantasma = Instantiate(proyectilSup, new Vector3(-0, 6), Quaternion.identity);
                        break;
                    case 6:
                        newFantasma = Instantiate(proyectilSup, new Vector3(0, 6), Quaternion.identity);
                        break;
                    case 7:
                        newFantasma = Instantiate(proyectilSup, new Vector3(1, 6), Quaternion.identity);
                        break;
                    case 8:
                        newFantasma = Instantiate(proyectilSup, new Vector3(2, 6), Quaternion.identity);
                        break;
                    case 9:
                        newFantasma = Instantiate(proyectilSup, new Vector3(3, 6), Quaternion.identity);
                        break;
                    case 10:
                        newFantasma = Instantiate(proyectilSup, new Vector3(4, 6), Quaternion.identity);
                        break;
                    case 11:
                        newFantasma = Instantiate(proyectilSup, new Vector3(5, 6), Quaternion.identity);
                        break;
                    case 12:
                        newFantasma = Instantiate(proyectilSup, new Vector3(6, 6), Quaternion.identity);
                        break;
                }
                break;
            case 1:
                posicionAtaque = Random.Range(0, 6);
                switch (posicionAtaque)
                {
                    case 1:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, -2), Quaternion.identity);
                        break;
                    case 2:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, -1), Quaternion.identity);
                        break;
                    case 3:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, 0), Quaternion.identity);
                        break;
                    case 4:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, 1), Quaternion.identity);
                        break;
                    case 5:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, 2), Quaternion.identity);
                        break;
                    case 6:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, 3), Quaternion.identity);
                        break;
                    case 7:
                        newFantasma = Instantiate(proyectilIzq, new Vector3(-11, 6), Quaternion.identity);
                        break;
                }
                break;
            case 2:
                posicionAtaque = Random.Range(0, 6);
                switch (posicionAtaque)
                {
                    case 1:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, -2), Quaternion.identity);
                        break;
                    case 2:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, -1), Quaternion.identity);
                        break;
                    case 3:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, 0), Quaternion.identity);
                        break;
                    case 4:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, 1), Quaternion.identity);
                        break;
                    case 5:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, 2), Quaternion.identity);
                        break;
                    case 6:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, 3), Quaternion.identity);
                        break;
                    case 7:
                        newFantasma = Instantiate(proyectilDer, new Vector3(11, 6), Quaternion.identity);
                        break;
                }
                break; 
        }

        limpiador.elementosParaBorrar.Add(newFantasma);
        if (newFantasma.GetComponent<sFantasma>())
        {
            newFantasma.GetComponent<sFantasma>().limpiador = limpiador;
        }

        if (almascosechadas == false)
        {
            StartCoroutine("GenerarEnemigo");
        }
    }
}
