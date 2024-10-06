using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTerrestre : MonoBehaviour
{
    public float Radiobuscar;
    public LayerMask capaPlayer;
    public Transform transformplayer;
    public EstadoMoviento estadoactual;
    public float velocidadMoviento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirando;
    public Rigidbody2D rb2d;
    public Animator animar;

    public enum EstadoMoviento
    {
        Esperando,
        Siguiendo,
        Volviendo,
    }

    private void Start()
    {
        puntoInicial = transform.position;
    }

    void Update()
    {

        switch (estadoactual)
        {
            case EstadoMoviento.Esperando:
                EstadoEsperando();
                break;
            case EstadoMoviento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadoMoviento.Volviendo:
                EstadoVolviendo();
                break;
        }


    }
    private void EstadoEsperando()
    {
        Collider2D colicionPlayer = Physics2D.OverlapCircle(transform.position, Radiobuscar, capaPlayer);
        if (colicionPlayer)
        {
            transformplayer = colicionPlayer.transform;
            estadoactual = EstadoMoviento.Siguiendo;
        }

    }



    private void EstadoSiguiendo()
    {

        animar.SetBool("correr",true);
        if (transformplayer == null)
        {
            estadoactual = EstadoMoviento.Volviendo;
            return;
        }

        if (transform.position.x < transformplayer.position.x)
        {
            rb2d.velocity = new Vector2(velocidadMoviento, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-velocidadMoviento, rb2d.velocity.y);
        }
        GirarObjetivo(transformplayer.position);
        if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
            Vector2.Distance(transform.position, transform.position) > distanciaMaxima)
        {
            //para cambiar de estado

            estadoactual = EstadoMoviento.Volviendo;
            transformplayer = null;
        }
    }


    private void EstadoVolviendo()
    {
        if (transform.position.x < puntoInicial.x)
        {
            rb2d.velocity = new Vector2(velocidadMoviento, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-velocidadMoviento, rb2d.velocity.y);
        }
        GirarObjetivo(puntoInicial);

        if (Vector2.Distance(transform.position, puntoInicial) < 0.1f)
        {
            rb2d.velocity = Vector2.zero;
            animar.SetBool("correr", false);
            estadoactual = EstadoMoviento.Esperando;


        }

    }


    private void GirarObjetivo(Vector3 objeto)
    {
        if (objeto.x > transform.position.x && !mirando)
        {
            Girar();
        }
        else if (objeto.x < transform.position.x && mirando)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirando = !mirando;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radiobuscar);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }
}
