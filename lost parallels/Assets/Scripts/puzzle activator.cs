using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PuzzleActivator : MonoBehaviour
{
    public GameObject puzzleThing;
    public GameObject m_camera;
    public portal_behaviour portalBehaviour;
    public GameManager gameManager;
    private AudioSource correct_noise;
    private bool hasplayedsound = false;

    private void Start()
    {
        FindObjectOfType<GameManager>();
        FindObjectOfType<portal_behaviour>();
        correct_noise = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if (gameManager.puzzle_solved == true && hasplayedsound == false)
        {
            
            puzzleThing.SetActive(false);
            m_camera.SetActive(true);
            portalBehaviour.IsUnlocked = true;
            correct_noise.Play();
            hasplayedsound = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (puzzleThing != null)
            {
                m_camera.SetActive(false);
                puzzleThing.SetActive(true);
            }
        }   


         
    }
    
}
