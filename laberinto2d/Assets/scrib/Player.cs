using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Correr = 2 ;
    public float Velocidad_Salto = 3;
    public Rigidbody2D player;
    public bool SaltoMejorado = false;// alias betterJump
    public float Caida = 0.5f;//FALLMultiplier
    public float MultiplicarSalto = 1f;//alias lowJumpMulipler
    public SpriteRenderer spriteRenderer;
    public Animator ani;
    public TMPro.TextMeshProUGUI contador;
  


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

   
    void Update()
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
        if (Input.GetKey("space") && Pata.suelo)
        {
            player.velocity = new Vector2(player.velocity.x,Velocidad_Salto);
        }
        if (Pata.suelo==false)//condicion para saltar
        {
            ani.SetBool("Saltar", true);
            ani.SetBool("Rum", false);
        }
        if(Pata.suelo == true)
            {
            ani.SetBool("Saltar", false);
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

   
}
