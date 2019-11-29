using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Persistance : MonoBehaviour
{
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
            Debug.Log("Should destroy");
            Destroy(gameObject);
        }

    }
}
