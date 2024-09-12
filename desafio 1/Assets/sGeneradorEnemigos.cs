using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGeneradorEnemigos : MonoBehaviour
{
    [SerializeField] GameObject proyectilSup, proyectilDer, proyectilIzq;
    private int tipoAtaque, posicionAtaque;
    void Start()
    {
        StartCoroutine("GenerarEnemigo");
    }

    // Update is called once per frame
    void Update()
    {
        
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
                        Instantiate(proyectilSup, new Vector3(-6, 6), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(proyectilSup, new Vector3(-5, 6), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(proyectilSup, new Vector3(-4, 6), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(proyectilSup, new Vector3(-3, 6), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(proyectilSup, new Vector3(-2, 6), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(proyectilSup, new Vector3(-0, 6), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(proyectilSup, new Vector3(0, 6), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(proyectilSup, new Vector3(1, 6), Quaternion.identity);
                        break;
                    case 8:
                        Instantiate(proyectilSup, new Vector3(2, 6), Quaternion.identity);
                        break;
                    case 9:
                        Instantiate(proyectilSup, new Vector3(3, 6), Quaternion.identity);
                        break;
                    case 10:
                        Instantiate(proyectilSup, new Vector3(4, 6), Quaternion.identity);
                        break;
                    case 11:
                        Instantiate(proyectilSup, new Vector3(5, 6), Quaternion.identity);
                        break;
                    case 12:
                        Instantiate(proyectilSup, new Vector3(6, 6), Quaternion.identity);
                        break;
                }
                break;
            case 1:
                posicionAtaque = Random.Range(0, 6);
                switch (posicionAtaque)
                {
                    case 0:
                        Instantiate(proyectilIzq, new Vector3(-11, -3), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(proyectilIzq, new Vector3(-11, -2), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(proyectilIzq, new Vector3(-11, -1), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(proyectilIzq, new Vector3(-11, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(proyectilIzq, new Vector3(-11, 1), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(proyectilIzq, new Vector3(-11, 2), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(proyectilIzq, new Vector3(-11, 3), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(proyectilIzq, new Vector3(-11, 6), Quaternion.identity);
                        break;
                }
                break;
            case 2:
                posicionAtaque = Random.Range(0, 6);
                switch (posicionAtaque)
                {
                    case 0:
                        Instantiate(proyectilDer, new Vector3(11, -3), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(proyectilDer, new Vector3(11, -2), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(proyectilDer, new Vector3(11, -1), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(proyectilDer, new Vector3(11, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(proyectilDer, new Vector3(11, 1), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(proyectilDer, new Vector3(11, 2), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(proyectilDer, new Vector3(11, 3), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(proyectilDer, new Vector3(11, 6), Quaternion.identity);
                        break;
                }
                break; 
        }
        StartCoroutine("GenerarEnemigo");
    }
}
