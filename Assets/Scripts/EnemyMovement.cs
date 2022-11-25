using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float maxDeltaX = 1.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    private float minX, maxX;
    private bool movingRight;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRend;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        rb.velocity = new Vector2(moveSpeed, 0f);
        movingRight = true;

        spriteRend = GetComponent<SpriteRenderer>();

        minX = transform.position.x - maxDeltaX;
        maxX = transform.position.x + maxDeltaX;
        float startingX = Random.Range(minX, maxX);
        transform.position = new Vector2(startingX, transform.position.y);
    }

    void Update() {
        if (movingRight && transform.position.x > maxX) {
            movingRight = false;
            rb.velocity = new Vector2(-moveSpeed, 0f);
            spriteRend.flipX = true;
        }
        else if (!movingRight && transform.position.x < minX) {
            movingRight = true;
            rb.velocity = new Vector2(moveSpeed, 0f);
            spriteRend.flipX = false;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(transform.position.x - maxDeltaX, transform.position.y), new Vector3(transform.position.x + maxDeltaX, transform.position.y));
    }
}
