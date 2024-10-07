using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranpaF2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Recorrido;
    public LayerMask capaJugador;
    public bool Subiendo = false;
    public float VelocidadSubida;
    void Update()
    {
        RaycastHit2D infoJugador = Physics2D.Raycast(transform.position, Vector3.down, Recorrido, capaJugador);
        if (infoJugador && !Subiendo)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        if (Subiendo) 
        {
            transform.Translate(Time.deltaTime * VelocidadSubida * Vector3.up);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().AcionMuerto();

            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeSceneIndex);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (Subiendo)
            {
                Subiendo = false;
            }
            else
            {
                Subiendo = true;
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * Recorrido);
    }

    
  }
 

