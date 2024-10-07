using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Legada : MonoBehaviour
{

    public GameObject transicion;

    private void Update()
    {
        Reecolecion();
    }



    public void Reecolecion() 
    {
        if (transform.childCount==0)
        {
            transicion.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }
}
