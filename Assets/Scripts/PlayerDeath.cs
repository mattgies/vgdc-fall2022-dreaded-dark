using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{ 
    [SerializeField] GameObject globalLight;
    private Checkpoint checkpointPos;
    private Rigidbody2D rb;
    private TrailRenderer playerTrail;
    private int totalDeaths = 0;
    private PlayerMovement playerMovement;
    private UnityEngine.Rendering.Universal.Light2D lightSource;

    private void Start(){
        checkpointPos = GetComponent<Checkpoint>();
        playerTrail = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>(); 
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        lightSource= globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //spikes and deathbox
        if (other.CompareTag("Environmental Hazard")){
            transform.position = checkpointPos.getLastCheckPointPos();
            playerTrail.Clear();
            rb.velocity = new Vector2(0, 0);
            playerMovement.resetJump();
            totalDeaths++;
            lightSource.intensity = 1.0f;
            playerMovement.prohibitMovement();
        }
    }
    //we need to display the deathCount as text and we also need that text to properly be on screen
    
}
