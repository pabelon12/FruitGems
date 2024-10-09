using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaAnimada : MonoBehaviour
{
    private PlatformEffector2D efecto;
    public float TienpoEspera; //Cuando querramos cambiar de nombre presionar control  + f
    private float Esperando; // Espera
    void Start()
    {
        efecto = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            Esperando = TienpoEspera;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (Esperando <= 0) 
            {
                efecto.rotationalOffset = 180f;
                Esperando -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            efecto.rotationalOffset = 0;
        }
    }
}
