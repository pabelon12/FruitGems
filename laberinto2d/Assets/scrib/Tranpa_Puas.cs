using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tranpa_Puas : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().AcionMuerto();
           
           
             int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
              SceneManager.LoadScene(activeSceneIndex);
            
        }
    }

   
}
