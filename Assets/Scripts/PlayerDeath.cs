using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDeath : MonoBehaviour
{ 
    [SerializeField] GameObject globalLight;
    private Checkpoint checkpointPos;
    private Rigidbody2D rb;
    private TrailRenderer playerTrail;
    private int totalDeaths = 0;
    private PlayerMovement playerMovement;
    private UnityEngine.Rendering.Universal.Light2D lightSource;
    private AudioSwitch audioSwitch;

    private void Start(){
        checkpointPos = GetComponent<Checkpoint>();
        playerTrail = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>(); 
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        lightSource= globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        audioSwitch = GameObject.FindWithTag("Audio").GetComponent<AudioSwitch>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //spikes and deathbox
        if (other.CompareTag("Environmental Hazard")){
            transform.position = checkpointPos.getLastCheckPointPos();
           // FindObjectOfType<AudioManager>().Play("respawn"); // Audio addition for death sound
            playerTrail.Clear();
            rb.velocity = new Vector2(0, 0);
            totalDeaths++;
            lightSource.intensity = 2.0f;
            playerMovement.prohibitMovement();
            audioSwitch.toggleAudioLightDark();
        }
    }

    public void ResetLevel(){
        transform.position = checkpointPos.getFirstCheckPointPos();
        playerTrail.Clear();
        FindObjectOfType<AudioManager>().Play("respawn"); // Audio addition for death sound
        rb.velocity = new Vector2(0, 0);
        lightSource.intensity = 0.0f;
        playerMovement.enableMovement();
        audioSwitch.onResetAudioSwitch();
        checkpointPos.resetCheckPoint();
        totalDeaths = 0;
    }
    //we need to display the deathCount as text and we also need that text to properly be on screen
    
    public int getDeathCount()
    {
        return totalDeaths;
    }
}
