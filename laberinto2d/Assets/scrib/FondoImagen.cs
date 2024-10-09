using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoImagen : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMoviento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerrb;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
     
    }

    private void Update()
    {
        offset = (playerrb.velocity.x * 0.1f) *velocidadMoviento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
