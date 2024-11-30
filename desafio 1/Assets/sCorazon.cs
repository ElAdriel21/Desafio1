using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sCorazon : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int vida;
    [SerializeField] Sprite corazones_1, corazones_2, corazones_3, corazones_0;
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFullVida()
    {
        vida = 3;
        spriteRenderer.sprite = corazones_3;
    }

    public void RestarVida()
    {
        vida--;
        switch(vida)
        {
            case 2:
                spriteRenderer.sprite = corazones_2;
            break;

            case 1:
                spriteRenderer.sprite = corazones_1;
            break;

            case 0:
                spriteRenderer.sprite = corazones_0;
            break;
        }
    }
    void Update()
    {
        
    }

    public void Apagar()
    {
        spriteRenderer.enabled = false;
    }

    public void Prender()
    {
        spriteRenderer.enabled = true;
    }
}
