using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMaceta : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Vector3 posicionInicial;

    bool listaParaVolver = false;

    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject fantasmaTarget;

    int indexGrow = 0;

    [SerializeField] sManejadorErilda manejadorErilda;
    void Start()
    {
        posicionInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (fantasmaTarget)
        {
            transform.position = fantasmaTarget.transform.position + new Vector3(0,0.5f);
        }

    }

    public void Grow()
    {
        indexGrow++;
        if (indexGrow < 10)
        {
            spriteRenderer.sprite = sprites[indexGrow];
        }
        else
        {
            manejadorErilda.Ganar();
        }
    }

    public void Reiniciar()
    {
        indexGrow = 0;
        posicionInicial = transform.position;
        listaParaVolver = false;
        spriteRenderer.sprite = sprites[indexGrow];
    }

    public void SeguirFantasma(GameObject fantasma)
    {
        fantasmaTarget = fantasma;
    }

    public void Soltar()
    {
        listaParaVolver = true;
        transform.position = fantasmaTarget.transform.position;
        fantasmaTarget = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (listaParaVolver && collision.gameObject.tag == "mascaraErilda")
        {
            transform.position = posicionInicial;
        }
    }
}
