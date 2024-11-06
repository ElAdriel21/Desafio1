using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sManejadorErilda : MonoBehaviour
{
    [SerializeField] GameObject myErilda, prefabErilda;
    [SerializeField] sGeneradorEnemigos generadorEnemigos;
    [SerializeField] GameObject canvasMenu;

    [SerializeField] sLimpiador limpiador;

    [SerializeField] sMaceta maceta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstanciarErilda()
    {
        if (myErilda != null)
        {
            myErilda.GetComponent<sJugador>().Autodestruccion();
        }
        myErilda = Instantiate(prefabErilda, new Vector3(0, -2, 0), Quaternion.identity);
        myErilda.GetComponent<sJugador>().manejadorErilda = this;
        myErilda.GetComponent<sJugador>().generadorEnemigos = generadorEnemigos;
        myErilda.GetComponent<sJugador>().actionGrow.AddListener(() => ListenerMaceta());
    }

    void ListenerMaceta()
    {
        maceta.Grow();
    }

    public void SetDerrota()
    {
        canvasMenu.SetActive(true);
        generadorEnemigos.DetenerGeneracion();
        limpiador.BorrarElementos();
    }
}
