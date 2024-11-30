using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sManejadorErilda : MonoBehaviour
{
    [SerializeField] sJugador Erilda;
    [SerializeField] GameObject canvasMenu;

    [SerializeField] sLimpiador limpiador;

    [SerializeField] sMaceta maceta;
    [SerializeField] sManejadorEnemigos manejadorEnemigos;

    public void ListenerMaceta()
    {
        maceta.Grow();
    }

    public void ButtonJUGAR()
    {
        limpiador.BorrarElementos();
        Erilda.Reiniciar();
        manejadorEnemigos.ComenzarGeneracion();
        maceta.Reiniciar();
    }

    public void SetDerrota()
    {
        canvasMenu.SetActive(true);
        limpiador.BorrarElementos();
        manejadorEnemigos.DetenerGeneracion();
        maceta.Reiniciar();
    }

    public void Ganar()
    {
        Erilda.animator.SetBool("chasquido", true);
        Erilda.animator.Play("chasquido");
        Erilda.almas = 10;
        canvasMenu.SetActive(true);
        limpiador.BorrarElementos();
        manejadorEnemigos.DetenerGeneracion();
    }

}
