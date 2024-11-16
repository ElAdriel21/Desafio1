using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sManejadorEnemigos : MonoBehaviour
{
    [SerializeField] sNarizon narizon;
    [SerializeField] sWaton waton;
    [SerializeField] sChistoso chistoso;
    [SerializeField] sBruja bruja;
    void Start()
    {
        ComenzarGeneracion();
    }

    void Update()
    {
        
    }

    public void ComenzarGeneracion()
    {
        StartCoroutine("SeleccionarFantasma");
    }

    public void DetenerGeneracion()
    {
        StopAllCoroutines();
    }

    IEnumerator SeleccionarFantasma()
    {
        yield return new WaitForSeconds(5);
        int tipoFantasma = Random.Range(0, 4);

        switch (tipoFantasma)
        {
            case 0:
                narizon.gameObject.SetActive(true);
                narizon.Invocar();
                break;

            case 1:
                waton.gameObject.SetActive(true);
                waton.Invocar();
                break;

            case 2:
                chistoso.gameObject.SetActive(true);
                chistoso.Invocar();
                break;

            case 3:
                bruja.gameObject.SetActive(true);
                bruja.Invocar();
                break;
        }

        StartCoroutine("SeleccionarFantasma");
    }
}
