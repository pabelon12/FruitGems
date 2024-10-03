using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float VIDA;


    public void HacerDaño(float Daño) 
    {
        VIDA -= Daño;
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
