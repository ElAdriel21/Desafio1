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

    [SerializeField] sCorazon corazones;

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
        if (spriteRenderer.color != Color.grey)
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
                StartCoroutine(Jump());
            }
        }
    }

    private IEnumerator Jump()
    {
        enSalto = true;
        enPiso = false;

        //animator.SetBool("isJumping", true);

        float elapsedTime = 0f;
        float jumpDuration = 1f / velVertical;

        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + alturaMaxima, transform.position.z);

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;

            float height = 4 * alturaMaxima * (t - t * t);
            transform.position = new Vector3(transform.position.x, startPosition.y + height, transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);

        enSalto = false;
        enPiso = true;

        //animator.SetBool("isJumping", false);
    }

    void MoverIzquierda()
    {
        transform.position += Vector3.left * velHorizontal * Time.deltaTime;
    }

    void MoverDerecha()
    {
        transform.position += Vector3.right * velHorizontal * Time.deltaTime;
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
            StartCoroutine(Jump());
        }
    }

    public void RestarVida()
    {
        vidas--;
        StartCoroutine("MostrarCorazones");
    }

    IEnumerator MostrarCorazones()
    {
        corazones.RestarVida();
        corazones.Prender();
        yield return new WaitForSeconds(2);
        corazones.Apagar();
    }
}

