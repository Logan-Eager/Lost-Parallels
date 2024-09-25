using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_behaviour : MonoBehaviour
{
    public string destination;
    public bool IsUnlocked = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
            if(other.CompareTag("Player"))
        {
            if (IsUnlocked)
            {
                SceneManager.LoadScene(destination);
            }
            else 
            {
                
            }
        }
    }
    
}
