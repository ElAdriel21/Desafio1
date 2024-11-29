using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sNarizon : sFantasma
{
    [SerializeField] bool conMaceta = false;
    sMaceta maceta;
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
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

        switch (posicionInicial)
        {
            case 0:
                base.SetSprite(false);
                transform.position = new Vector3(-10, -5.2f, 10);
                base.SetDirection(Vector2.right);
                break;

            case 1:
                base.SetSprite(true);
                transform.position = new Vector3(10, -5.2f, 10);
                base.SetDirection(Vector2.left);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Erilda")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            base.Reiniciar();
            if (conMaceta)
            {
                maceta.Soltar();
                conMaceta = false;
                maceta = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "maceta")
        {
            conMaceta = true;
            maceta = collision.gameObject.GetComponent<sMaceta>();
            collision.gameObject.GetComponent<sMaceta>().SeguirFantasma(gameObject);
        }

        if (collision.gameObject.tag == "mascaraErilda")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            base.Reiniciar();
            if (conMaceta)
            {
                maceta.Soltar();
                conMaceta = false;
                maceta = null;
            }
        }
    }
}
