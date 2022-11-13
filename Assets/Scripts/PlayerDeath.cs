using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{ 
    private Checkpoint checkpointPos;
    private TrailRenderer playerTrail;

    private void Start(){
        checkpointPos = GetComponent<Checkpoint>();
        playerTrail = GetComponent<TrailRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //spikes
        if (other.CompareTag("Environmental Hazard")){
            transform.position = checkpointPos.getLastCheckPointPos();
            playerTrail.Clear();
        }
    }
    
    
}
