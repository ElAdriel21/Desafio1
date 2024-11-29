using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFantasma : MonoBehaviour
{
    Vector2 direccion;

    public float velocidadHorizontal;

    [SerializeField] SpriteRenderer spriteRenderer;
    public float duracionDesaparacion = 1f;

    [SerializeField] CircleCollider2D circleCollider;

    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject alma;

    public sLimpiador limpiador;

    Color original; //color original

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