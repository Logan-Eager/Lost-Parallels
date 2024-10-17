using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_script : MonoBehaviour
{
    public float jumpForce;

    public bool grounded;

    public Rigidbody2D playerBody;

    public Animator animator;

    AudioSource jump_sound;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jump_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump_sound.pitch = Random.Range(0.8f,1.0f);
            jump_sound.Play();
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = true;
            animator.SetBool("IsFalling", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = false;
            animator.SetBool("IsFalling", true);
        }
    }
}
