using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float VelMoviento;
    [SerializeField] private Transform[] PuntoMover;
    [SerializeField] private float DistanciaMin;
    private int SiguientePaso = 0;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PuntoMover[SiguientePaso].position, VelMoviento * Time.deltaTime);
        if (Vector2.Distance(transform.position, PuntoMover[SiguientePaso].position) < DistanciaMin) 
        {
            SiguientePaso += 1;
            if (SiguientePaso >= PuntoMover.Length)
            {
                SiguientePaso = 0;
            }
            Girar();
        }
        
    }

    private void Girar() 
    {
        if (transform.position.x < PuntoMover[SiguientePaso].position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
