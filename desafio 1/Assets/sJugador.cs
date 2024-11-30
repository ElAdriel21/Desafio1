using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sJugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velHorizontal = 5f;
    [SerializeField] bool enSalto = false;
    [SerializeField] bool enPiso = true;
    [SerializeField] Vector3 startPosition, endPosition;
    [SerializeField] int vidas = 3;

    [SerializeField] float fuerzaSalto;

    [SerializeField] sCorazon corazones;

    public int almas = 0;

    public Animator animator;
    private Rigidbody2D miRigidbody2D;
    private SpriteRenderer spriteRenderer;

    public sManejadorErilda manejadorErilda;

    public UnityEvent actionGrow;

    public List<GameObject> almasRojas;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        startPosition = transform.position;
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

    public void AgregarAlmaRoja(GameObject nuevaAlma)
    {
        almasRojas.Add(nuevaAlma);
    }

    public void Reiniciar()
    {
        enSalto = false;
        enPiso = true;
        almas = 0;
        vidas = 3;
        transform.position = startPosition;
        spriteRenderer.color = Color.white;
        miRigidbody2D.simulated = true;
        spriteRenderer.enabled = true;
        corazones.SetFullVida();

        animator.Play("Erilda_quieta");
        animator.SetBool("isMoving", false);
        animator.SetBool("isDead", false);
        animator.SetBool("chasquido", false);
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
        else if ((collision.gameObject.tag == "fantasma") || (collision.gameObject.tag == "narizon"))
        {
            Salto();
        }

        if (collision.gameObject.tag == "maceta")
        {
            print("XD");
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
            manejadorErilda.SetDerrota();
        }
    }

    IEnumerator MostrarCorazones()
    {
        if (!corazones.gameObject)
        {
            yield return new WaitForSeconds(1);
        }
        corazones.RestarVida();
        corazones.Prender();
        yield return new WaitForSeconds(2);
        corazones.Apagar();
    }

    public void SumarAlma()
    {
        almas++;
        if (almas == 1)
        {
            almas = 0;
            actionGrow.Invoke();

            foreach (var item in almasRojas)
            {
                item.gameObject.GetComponent<sFuegoRojo>().ToPlant();
            }
            almasRojas.Clear();
        }
    }

    public void Autodestruccion()
    {
        Destroy(gameObject);
    }
}

