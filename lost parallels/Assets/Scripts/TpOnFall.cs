using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpOnFall : MonoBehaviour
{
    public Transform teleportDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
        }



    }
}
