using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sFantasma : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float duracionDesaparacion = 1f;
    Animator animator;
    CircleCollider2D circleCollider;

    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Erilda")
        {
            audioSource.Play();
            circleCollider.enabled = false;
            animator.SetBool("inDestruction", true);
            StartCoroutine(Destruction());
        }
    }

    IEnumerator Destruction()
    {
        float elapsedTime = 0f;
        Color spriteColor = spriteRenderer.color;

        while (elapsedTime < duracionDesaparacion)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duracionDesaparacion);
            spriteRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            yield return null; 
        }

        Destroy(gameObject);
    }
}