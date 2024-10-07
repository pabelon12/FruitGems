using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pata : MonoBehaviour
{
    public static bool suelo;//alias chek ground

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelazo"))
        {
            suelo = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelazo"))
        {
            suelo = false;
        }
    }

}
