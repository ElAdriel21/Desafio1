using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class sBruja : sFantasma
{
    bool disparando = false;
    Animator animator;
    [SerializeField] GameObject proyectil;

    [SerializeField] Transform transformErilda;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(transform.position.y > 3.5)
        {
            transform.Translate(Vector2.down * this.velocidadHorizontal * Time.deltaTime);
        }
        else
        {
            animator.Play("disparando");
            if (!disparando)
            {
                disparando = true;
                StartCoroutine("Disparar");
            }
        }
    }

    public void Invocar()
    {
        disparando = false;
        transform.position = new Vector3(0, 10, 0);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator Disparar()
    {
        yield return new WaitForSeconds(1);

        GameObject nuevoProyectil = Instantiate(proyectil, transform.position + new Vector3(-0.5f,0.5f,0),Quaternion.identity);
        nuevoProyectil.GetComponent<sProyectil>().target = transformErilda.transform.position;

        nuevoProyectil = Instantiate(proyectil, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
        nuevoProyectil.GetComponent<sProyectil>().target = transformErilda.transform.position;

        yield return new WaitForSeconds(1);

        animator.Play("volando");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        base.Reiniciar();
    }
}
