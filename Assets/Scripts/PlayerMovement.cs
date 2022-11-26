using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    private SpriteRenderer rend;
    private Animator anim;

    private int jumpNumber = 1;
    public bool canMove = true;
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
        collider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            float dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * 6f, rb.velocity.y);

            Vector2 leftSideSensor = new Vector2(rb.position.x - collider.bounds.extents.x + 0.1f, rb.position.y);
            Vector2 rightSideSensor = new Vector2(rb.position.x + collider.bounds.extents.x - 0.1f, rb.position.y);

            RaycastHit2D leftSideHit = Physics2D.Raycast(leftSideSensor, Vector2.down, GetComponent<CapsuleCollider2D>().size.y / 2 + 0.03f);
            RaycastHit2D rightSideHit = Physics2D.Raycast(rightSideSensor, Vector2.down, GetComponent<CapsuleCollider2D>().size.y / 2 + 0.03f);
            
            Color rayColor = Color.red;

            if (
                (leftSideHit.collider && leftSideHit.collider.gameObject.tag == "Ground"
                || rightSideHit.collider && rightSideHit.collider.gameObject.tag == "Ground")
                && rb.velocity.y <= 0
            ) {
                jumpNumber = 1;
                coyoteTimeCounter = coyoteTimeFirst;

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

            anim.speed = Mathf.Min(rb.velocity.magnitude / 10, 1);
            
            if (rb.velocity.x > 0 && rend.flipX == true) {
                rend.flipX = false;
            }
            else if (rb.velocity.x < 0 && rend.flipX == false) {
                rend.flipX = true;
            }
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

    public void resetJump() {
        jumpNumber = 1;
        coyoteTimeCounter = coyoteTimeFirst;
    }
}
