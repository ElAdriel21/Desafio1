using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sChistoso : sFantasma
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (base.GetDirection() != Vector2.zero)
        {
            transform.Translate((base.GetDirection() + Vector2.up) * this.velocidadHorizontal * Time.deltaTime);
        }
    }

    public void Invocar()
    {
        int posicionInicial = Random.Range(-15, 16);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

        transform.position = new Vector3(posicionInicial, -9, -1);
        if (posicionInicial >= 0)
        {
            base.SetSprite(true);
            base.SetDirection(Vector2.left);
        }
        else
        {
            base.SetSprite(false);
            base.SetDirection(Vector2.right);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Erilda")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            base.sumarStats.Invoke();
            base.Reiniciar();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mascaraErilda")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            base.sumarStats.Invoke();
            base.Reiniciar();
        }
    }
}
