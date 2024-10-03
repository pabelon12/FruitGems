using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float VIDA;


    public void HacerDa�o(float Da�o) 
    {
        VIDA -= Da�o;
        if (VIDA <= 0)
        {
            Muerte();
        }

    }

    private void Muerte() 
    {
        Destroy(gameObject);
    }
}
