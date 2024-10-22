using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sLimpiador : MonoBehaviour
{
    public List<GameObject> elementosParaBorrar;
    int indice;

    public void AgregarElemento(GameObject newElemento)
    {
        elementosParaBorrar.Add(newElemento);
    }

    public void BorrarElementos()
    {
        foreach (var item in elementosParaBorrar)
        {
            if (item)
            {
                Destroy(item);
            }
        }
        elementosParaBorrar.Clear();
    }
}
