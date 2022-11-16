using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{ 
    private Checkpoint checkpointPos;
    private TrailRenderer playerTrail;
    private int totalDeaths = 0;

    private void Start(){
        checkpointPos = GetComponent<Checkpoint>();
        playerTrail = GetComponent<TrailRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //spikes and deathbox
        if (other.CompareTag("Environmental Hazard")){
            transform.position = checkpointPos.getLastCheckPointPos();
            playerTrail.Clear();
            totalDeaths++;
        }
    }
    //we need to display the deathCount as text and we also need that text to properly be on screen
    
}
