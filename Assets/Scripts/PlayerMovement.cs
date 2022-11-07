using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private int jumps;
    private bool _canMove = true;

    // Code for dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

   // [SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }

        if (_canMove) {
            float dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * 4f, rb.velocity.y);

            bool jumpConditions = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            if (jumpConditions && jumps > 0) {
                rb.velocity = new Vector2(rb.velocity.x, 6f);
                jumps--;
            }
        } 
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Horizontal") != 0 && canDash)
        {
            StartCoroutine(Dash());
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

    public void prohibitDash()
    {
        canDash = false;
    }

    public void enableDash()
    {
        canDash = true;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if(Input.GetAxisRaw("Horizontal") < 0)
            rb.velocity = new Vector2(transform.localScale.x * dashingPower * -1, 0f);
        else
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        
        //tr.emitting = true;

        //Stops dashing
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false; 
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
