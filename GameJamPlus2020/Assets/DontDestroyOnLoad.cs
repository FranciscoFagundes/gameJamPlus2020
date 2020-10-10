using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad coincontrol;
    private static bool GameManagerExists;
    void Start ()
    {
        if (!GameManagerExists)
        {
            GameManagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }  

}
