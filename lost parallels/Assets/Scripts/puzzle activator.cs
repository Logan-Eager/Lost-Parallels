using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PuzzleActivator : MonoBehaviour
{
    public GameObject puzzleThing;
    public GameObject m_camera;
    private portal_behaviour portalBehaviour;
    private GameManager gameManager;


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

         if (gameManager.puzzle_solved == true)
        {
            puzzleThing.SetActive(false);
            m_camera.SetActive(true);
            portalBehaviour.IsUnlocked = true;
        }
    }
    
}
