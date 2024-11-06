using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sMaceta : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] sprites;

    int indexGrow = -1;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Grow()
    {
        indexGrow++;
        if (indexGrow < 9)
        {
            spriteRenderer.sprite = sprites[indexGrow];
        }
    }
}
