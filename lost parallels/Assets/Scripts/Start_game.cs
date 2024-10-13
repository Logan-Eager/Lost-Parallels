using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game : MonoBehaviour
{
    public string level_name;

    public void load_level()
    {
        Invoke("load_scene", 1);
        
    }
    
    public void load_scene()
    {
        SceneManager.LoadScene(level_name);
    }
}
