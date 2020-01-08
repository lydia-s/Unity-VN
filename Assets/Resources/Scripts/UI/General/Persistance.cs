using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Persistance : MonoBehaviour
{
    /*
     * This class is to keep game objects when scenes change
     */
    public static Persistance instance;
    
    private void Awake()
    {

        
        if (instance == null)
        {
            instance = this;
        } else if (instance !=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }

    }
}
