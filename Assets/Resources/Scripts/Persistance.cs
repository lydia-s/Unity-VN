using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
