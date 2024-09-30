using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    private float horizontal;
    private float speed = 200f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;

    public GameObject Interuptmenu;

    // Start is called before the first frame update
    void Start()
    {
        Interuptmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Interuptmenu.SetActive(!Interuptmenu.activeSelf);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        rb.AddForce(rb.velocity);
    }

    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight= !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;  
        }
    }
}
