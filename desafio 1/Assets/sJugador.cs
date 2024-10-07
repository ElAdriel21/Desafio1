using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sJugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velHorizontal = 5f;
    [SerializeField] float velVertical = 2f;
    [SerializeField] float alturaMaxima = 2f;
    [SerializeField] bool enSalto = false;
    [SerializeField] bool enPiso = true;
    [SerializeField] Vector3 startPosition, endPosition;
    [SerializeField] int vidas = 3;

    [SerializeField] float fuerzaSalto;

    [SerializeField] sCorazon corazones;

    int almas = 0;
    bool almascosechadas = false;
    [SerializeField] sGeneradorEnemigos generadorEnemigos;

    private Animator animator;
    private Rigidbody2D miRigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("MostrarCorazones");
    }

    void Update()
    {
        if ((spriteRenderer.color != Color.grey) && (almas != 10))
        {
            float moveDirection = Input.GetAxis("Horizontal");


            transform.position += new Vector3(moveDirection * velHorizontal * Time.deltaTime, 0, 0);

            if (moveDirection != 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (moveDirection < 0)
            {
                spriteRenderer.flipX = true; 
            }
            else if (moveDirection > 0)
            {
                spriteRenderer.flipX = false; 
            }

            if (Input.GetKey(KeyCode.W) && !enSalto && enPiso)
            {
                Salto();
            }
        }
    }

    void Salto()
    {
        miRigidbody2D.AddForce(new Vector2(0, 1) * fuerzaSalto, ForceMode2D.Impulse);
        enSalto = true;
        enPiso = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            enSalto = false;
            enPiso = true;
        }
        else if (collision.gameObject.tag == "fantasma")
        {
            Salto();
        }
    }

    public void RestarVida()
    {
        vidas--;
        StartCoroutine("MostrarCorazones");
        if (vidas == 0)
        {
            animator.SetBool("isDead", true);
            spriteRenderer.color = Color.grey;
        }
    }

    IEnumerator MostrarCorazones()
    {
        corazones.RestarVida();
        corazones.Prender();
        yield return new WaitForSeconds(2);
        corazones.Apagar();
    }

    public void SumarAlma()
    {
        almas++;
        if (almas == 10)
        {
            almascosechadas = true;
            generadorEnemigos.almascosechadas = almascosechadas;
            animator.SetBool("chasquido", true);
        }
    }
}

