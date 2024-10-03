using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float Velo_bala;
    [SerializeField] private float da�o;
         

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Velo_bala * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo")) 
        {
            other.GetComponent<Enemigo>().HacerDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
