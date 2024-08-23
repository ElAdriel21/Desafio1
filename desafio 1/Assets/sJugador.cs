using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class sJugador : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;

    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    private float moverHorizontal;
    private Vector2 direccion;

    private int vidas = 3;

    //Corazones
    [SerializeField] sCorazon Corazon1, Corazon2, Corazon3;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;

    private SpriteRenderer spriteRenderer;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("MostrarCorazones");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (spriteRenderer.color != Color.grey)
        {
            moverHorizontal = Input.GetAxis("Horizontal");
            direccion = new Vector2(moverHorizontal, 0f);

            if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
            {
                puedoSaltar = false;
            }
        }
    }

    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);

        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            puedoSaltar = true;
            saltando = false;
        }
    }

    public void RestarVida()
    {
        vidas--;
        StartCoroutine("MostrarCorazones");
    }

    IEnumerator MostrarCorazones()
    {
        Corazon1.Prender();
        Corazon2.Prender();
        Corazon3.Prender();
        switch (vidas)
        {
            case 2:
                Corazon3.PonerGris();
                break;
            case 1:
                Corazon2.PonerGris();
                break;
            case 0:
                Corazon1.PonerGris();
                spriteRenderer.color = Color.grey;
                break;
        }
        yield return new WaitForSeconds(2);
        Corazon1.Apagar();
        Corazon2.Apagar();
        Corazon3.Apagar();
    }
}
