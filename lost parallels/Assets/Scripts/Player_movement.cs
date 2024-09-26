using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    public GameObject Interuptmenu;

    // Start is called before the first frame update
    void Start()
    {
        Interuptmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        transform.position += moveDirection * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
            {
            Interuptmenu.SetActive(!Interuptmenu.activeSelf);
        }
    }
}
