using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class sWaton : sFantasma
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                transform.position = new Vector3(-10, -3.5f, 10);
                base.SetDirection(Vector2.right);
                break;

            case 1:
                base.SetSprite(true);
                transform.position = new Vector3(10, -3.5f, 10);
                base.SetDirection(Vector2.left);
                break;
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
