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

        switch (3)
        {
            case 0:
                if (!narizon.gameObject.activeSelf)
                {
                    narizon.gameObject.SetActive(true);
                    narizon.Invocar();
                }
                break;

            case 1:
                if (!waton.gameObject.activeSelf)
                {
                    waton.gameObject.SetActive(true);
                    waton.Invocar();
                }
                break;

            case 2:
                if (!chistoso.gameObject.activeSelf)
                {
                    chistoso.gameObject.SetActive(true);
                    chistoso.Invocar();
                }
                break;

            case 3:
                if (!bruja.gameObject.activeSelf)
                {
                    bruja.gameObject.SetActive(true);
                    bruja.Invocar();
                }
                break;
        }

        StartCoroutine("SeleccionarFantasma");
    }
}
