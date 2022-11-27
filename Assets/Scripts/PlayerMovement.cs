using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    private SpriteRenderer rend;
    private Animator anim;

    private bool groundJump = true;
    private bool airJump = false;
    private int jumpCounter = 0;
    public bool canMove = true;
    private float coyoteTimeCounter;
    private float coyoteTimeFirst = 0.12f;
    private float airSpamTime = 0.3f;

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
        collider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            float dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * 6f, rb.velocity.y);  //speed
            Vector2 jumpHeight = new Vector2(rb.velocity.x, 12f);  //jump

            Vector2 leftSideSensor = new Vector2(rb.position.x - collider.bounds.extents.x + 0.2f, rb.position.y);
            Vector2 rightSideSensor = new Vector2(rb.position.x + collider.bounds.extents.x - 0.2f, rb.position.y);
            float rayDistance = collider.bounds.extents.y + 0.05f;
            RaycastHit2D leftSideHit = Physics2D.Raycast(leftSideSensor, Vector2.down, rayDistance);
            RaycastHit2D rightSideHit = Physics2D.Raycast(rightSideSensor, Vector2.down, rayDistance);
            
            Color rayColor = Color.red;
            //if touching ground
            if (
                (leftSideHit.collider && leftSideHit.collider.gameObject.tag == "Ground"
                || rightSideHit.collider && rightSideHit.collider.gameObject.tag == "Ground")
                && rb.velocity.y <= 0
            ) {
                rayColor = Color.green;
                groundJump = true;
                coyoteTimeCounter = coyoteTimeFirst;
                jumpCounter = 0;
                anim.SetBool("Grounded", true);                
            }
            //if not touching ground
            else {
                if (groundJump){
                    coyoteTimeCounter -= Time.deltaTime;
                }
                if (coyoteTimeCounter <= 0f){
                    groundJump = false;
                }
                if (airJump){
                    coyoteTimeCounter += Time.deltaTime;
                }
            }
            Debug.DrawRay(leftSideSensor, new Vector2(0, -rayDistance), rayColor, 1f); 
            Debug.DrawRay(rightSideSensor, new Vector2(0, -rayDistance), rayColor, 1f);


            // jump
            bool jumpConditions = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            //ground jump
            if (jumpConditions && groundJump) {
                rb.velocity = jumpHeight;
                groundJump = false;
                airJump = true;
                jumpCounter++;
                anim.SetTrigger("Jump");
                anim.SetBool("Grounded", false);
            }
            //second jump
            else if (jumpConditions && ((airJump && coyoteTimeCounter >= airSpamTime) || jumpCounter == 0)) {
                rb.velocity = jumpHeight;
                airJump = false;
                jumpCounter++;
                anim.SetTrigger("Jump");
                anim.SetBool("Grounded", false);

            }

            //animations            
            if (rb.velocity.x > 0.001f && rend.flipX == true) {
                rend.flipX = false;
            }
            else if (rb.velocity.x < -0.001f && rend.flipX == false) {
                rend.flipX = true;
            }
            //animation parameters
            anim.SetBool("Run", dirX != 0);

        }
    }

    public void prohibitMovement() {
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        canMove = false;
        anim.enabled = false;
    }

    public void enableMovement() {
        rb.gravityScale = 3f;
        canMove = true;
        anim.enabled = true;
    }

}
