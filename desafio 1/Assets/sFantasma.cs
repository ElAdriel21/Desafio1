using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sFantasma : MonoBehaviour
{
    [SerializeField] GameObject plant;

    Vector2 direccion;

    public float velocidadHorizontal;

    [SerializeField] SpriteRenderer spriteRenderer;
    public float duracionDesaparacion = 1f;

    [SerializeField] CircleCollider2D circleCollider;

    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject alma;

    public sLimpiador limpiador;
    [SerializeField] sJugador Erilda;

    Color original; //color original

    public UnityEvent sumarStats; //SUMA estadisticas de fantasma desterrado

    public void Inicializar()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = clip;
    }

    public void Reiniciar()
    {
        //audioSource.Play();
        //animator.SetBool("inDestruction", true);
        StartCoroutine(Esfumar());
    }

    IEnumerator Esfumar()
    {
        float elapsedTime = 0f;
        Color spriteColor = spriteRenderer.color;
        original = spriteColor;

        while (elapsedTime < duracionDesaparacion)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duracionDesaparacion);
            spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            yield return null; 
        }

        spriteRenderer.color = original;

        if (alma)
        {
            GameObject fuego = Instantiate(alma, transform.position, Quaternion.identity);
            fuego.GetComponent<sFuegoAzul>().limpiador = limpiador;
            fuego.GetComponent<sFuegoAzul>().plant = plant;
            fuego.GetComponent<sFuegoAzul>().Erilda = Erilda;
            limpiador.AgregarElemento(fuego);
        }

        gameObject.SetActive(false);
    }

    public void SetSprite(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    public Vector2 GetDirection()
    {
        return direccion;
    }

    public void SetDirection(Vector2 v2)
    {
        direccion = v2;
    }
}