using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    
    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
    }

   
}
