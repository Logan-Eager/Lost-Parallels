using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_script : MonoBehaviour
{
    public float jumpForce;

    public bool grounded;

    public Rigidbody2D playerBody;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = true;
            animator.SetBool(animator.IsFalling, false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = false;
            animator.SetBool(animator.IsFalling, true);
        }
    }
}
