using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private int jumps;
    private bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove) {
            float dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);

            bool jumpConditions = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            if (jumpConditions && jumps > 0) {
                rb.velocity = new Vector2(rb.velocity.x, 6f);
                jumps--;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground")
            jumps = 2;
    }

    public void prohibitMovement() {
        _canMove = false;
    }

    public void enableMovement() {
        _canMove = true;
    }
}
