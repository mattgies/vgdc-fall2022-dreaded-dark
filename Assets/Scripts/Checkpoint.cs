using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector2 LastCheckPointPos;
    private Vector2 FirstCheckPointPos;
    private UnityEngine.Rendering.Universal.Light2D lightSource;
    private PlayerMovement playerMovement;
    
    void Start(){
        LastCheckPointPos = transform.position;
        FirstCheckPointPos = transform.position;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint")){
            LastCheckPointPos = other.gameObject.transform.position;
        }
    }

    public Vector2 getLastCheckPointPos(){
        return LastCheckPointPos;
    }

    public Vector2 getFirstCheckPointPos(){
        return FirstCheckPointPos;
    }
}
