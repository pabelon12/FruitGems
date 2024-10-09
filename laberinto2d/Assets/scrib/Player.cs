using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Correr = 2 ;
    public float Velocidad_Salto = 3;
    public float DobleSalto = 2.5f;
    private bool SegundoSalto;
    public Rigidbody2D player;
    public bool SaltoMejorado = false;// alias betterJump
    public float Caida = 0.5f;//FALLMultiplier
    public float MultiplicarSalto = 1f;//alias lowJumpMulipler
    public SpriteRenderer spriteRenderer;
    public Animator ani;
  


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space") )
        {
            if (Pata.suelo)
            {
                SegundoSalto = true;
                player.velocity = new Vector2(player.velocity.x, Velocidad_Salto);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (SegundoSalto)
                    {
                        ani.SetBool("DobleSalto", true);
                        player.velocity = new Vector2(player.velocity.x, DobleSalto);
                        SegundoSalto = false;
                    }

                }
            }
        }



        if (Pata.suelo == false)//condicion para saltar
        {
            ani.SetBool("Saltar", true);
            ani.SetBool("Rum", false);
        }
        if (Pata.suelo == true)
        {
            ani.SetBool("Saltar", false);
            ani.SetBool("Caer", false);
            ani.SetBool("DobleSalto", false);
        }
         if (player.velocity.y<0)
        {
            ani.SetBool("Caer", true);
        }
        else if (player.velocity.y > 0)
        {
            ani.SetBool("Caer", false);
        }


    }


    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.velocity = new Vector2(Velocidad_Salto, player.velocity.y);
            spriteRenderer.flipX = false;//para mirar a la derecha
            ani.SetBool("Rum", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            player.velocity = new Vector2(-Velocidad_Salto, player.velocity.y);
            spriteRenderer.flipX = true;//para mirar a la Isquierda
            ani.SetBool("Rum", true);
        }
        else 
        {
            player.velocity = new Vector2(0, player.velocity.y);
            ani.SetBool("Rum", false);
        }

        if (SaltoMejorado)
        {

            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (Caida) * Time.deltaTime;
            }

            if (player.velocity.y > 0 && !Input.GetKey("space"))
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (MultiplicarSalto) * Time.deltaTime;
            }



        }




    }


    public void AcionMuerto()
    {
        ani.Play("Hurt");
    }
}
