using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{ 
    private Checkpoint checkpointPos;
    private void Start(){
        checkpointPos = GetComponent<Checkpoint>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Environmental Hazard")){
            transform.position = checkpointPos.getLastCheckPointPos();
        }
    }
    
    
}
