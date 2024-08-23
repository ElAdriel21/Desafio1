using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sCorazon : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PonerGris()
    {
        spriteRenderer.color = Color.grey;
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
