using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game : MonoBehaviour
{
    public string level_name;

    public void load_level()
    {
        SceneManager.LoadScene(level_name);
    }
 
}
