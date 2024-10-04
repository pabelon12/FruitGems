using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Legada : MonoBehaviour
{

    private void Update()
    {
        Reecolecion();
    }



    public void Reecolecion() 
    {
        if (transform.childCount==0)
        {
            Debug.Log("Victoria");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }
}
