using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D collider;

    private int jumpNumber = 1;
    private bool canMove = true;
    private float coyoteTimeCounter;
    private float coyoteTimeFirst = 0.15f;
    private float coyoteTimeSecond = 0.3f;

    // private bool canDash = true;
    // private bool isDashing = false;
    // private float dashingPower = 24f;
    // private float dashingTime = 0.2f;
    // private float dashingCooldown = 0.5f;

   // [SerializeField] private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        /*
        if (isDashing) {
            if (canMove) {
                rb.velocity = new Vector2(rb.velocity.x + dirX * 0.05f, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else*/ if (canMove) {
            rb.velocity = new Vector2(dirX * 6f, rb.velocity.y);

            /*
            // dash
            else if (Input.GetKeyDown(KeyCode.LeftShift)
                && Input.GetAxis("Horizontal") != 0
                && canDash) {
                StartCoroutine(Dash());    
            }
            */
            Vector2 leftSideSensor = new Vector2(rb.position.x - collider.bounds.extents.x + 0.1f, rb.position.y);
            Vector2 rightSideSensor = new Vector2(rb.position.x + collider.bounds.extents.x - 0.1f, rb.position.y);

            RaycastHit2D leftSideHit = Physics2D.Raycast(leftSideSensor, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.03f);
            RaycastHit2D rightSideHit = Physics2D.Raycast(rightSideSensor, Vector2.down, GetComponent<BoxCollider2D>().size.y / 2 + 0.03f);
            
            Color rayColor = Color.red;

            if (
                (leftSideHit.collider && leftSideHit.collider.gameObject.tag == "Ground"
                || rightSideHit.collider && rightSideHit.collider.gameObject.tag == "Ground")
                && rb.velocity.y <= 0
            ) {
                jumpNumber = 1;
                coyoteTimeCounter = coyoteTimeFirst;

                Debug.Log("collider hit");
                rayColor = Color.green;
            }
            else {
                if (jumpNumber == 1){
                    coyoteTimeCounter -= Time.deltaTime;
                }
                else if (jumpNumber == 2){ 
                    coyoteTimeCounter += Time.deltaTime;
                }
            }
            Debug.DrawRay(leftSideSensor, Vector2.down, rayColor, 1);
            Debug.DrawRay(rightSideSensor, Vector2.down, rayColor, 1);

            // jump
            bool jumpConditions = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            //first jump
            if (jumpConditions && jumpNumber == 1 && coyoteTimeCounter > 0f) {
                rb.velocity = new Vector2(rb.velocity.x, 12f);
                jumpNumber++;
                coyoteTimeCounter = 0f;
            }
            //second jump
            else if (jumpConditions && jumpNumber == 2 && coyoteTimeCounter > coyoteTimeSecond) {
                rb.velocity = new Vector2(rb.velocity.x, 12f);
                jumpNumber++;
            }
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void prohibitMovement() {
        canMove = false;
        // canDash = false;
    }

    public void enableMovement() {
        canMove = true;
        // canDash = true;
    }

    /*
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
    */
}
