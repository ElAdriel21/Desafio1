using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sTipoFantasma : MonoBehaviour
{
    [SerializeField] sPersistenceManager persistenceManager;

    [SerializeField] TextMeshProUGUI textTipo, textDificultad, textAlmas, textDestierros;
    [SerializeField] sDataFantasmas dataFantasmas;
    void Start()
    {
        textTipo.text = "Tipo: " + dataFantasmas.tipo;
        textDificultad.text = "Dificultad: " + dataFantasmas.dificultad;
        textAlmas.text = "Cantidad de almas: " + dataFantasmas.almas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarDestierros()
    {
        textDestierros.text = "Destierros realizados: " + persistenceManager.GetValue(dataFantasmas.tipo).ToString();
    }
}
