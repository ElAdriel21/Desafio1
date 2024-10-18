using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sTipoFantasma : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTipo, textDificultad, textAlmas;
    [SerializeField] sDataFantasmas dataFantasmas;
    void Start()
    {
        textTipo.text = dataFantasmas.tipo;
        textDificultad.text = dataFantasmas.dificultad;
        textAlmas.text = dataFantasmas.almas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
