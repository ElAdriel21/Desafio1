using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sNarizon : sFantasma
{
    void Start()
    {
        base.Inicializar();
    }

    void Update()
    {
        if (base.GetDirection() != Vector2.zero)
        {
            transform.Translate(base.GetDirection() * this.velocidadHorizontal * Time.deltaTime);
        }
    }

    public void Invocar()
    {
        int posicionInicial = Random.Range(0, 2);

        switch (posicionInicial)
        {
            case 0:
                base.SetSprite(false);
                transform.position = new Vector3(-10, -2.2f, 10);
                base.SetDirection(Vector2.right);
                break;

            case 1:
                base.SetSprite(true);
                transform.position = new Vector3(10, -2.2f, 10);
                base.SetDirection(Vector2.left);
                break;
        }
    }
}
