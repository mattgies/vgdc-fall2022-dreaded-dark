using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleLights : MonoBehaviour
{
    [SerializeField] GameObject globalLight;
    [SerializeField] KeyCode toggleKey;
    private UnityEngine.Rendering.Universal.Light2D lightSource;
    private bool _canToggleLights;
    private PlayerMovement playerMovement;
    private AudioSwitch audioSwitch;

    void Start()
    {
        lightSource= globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        _canToggleLights = false;
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        audioSwitch = GameObject.FindWithTag("Audio").GetComponent<AudioSwitch>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        _canToggleLights = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        _canToggleLights = false;
    }

    void Update(){
        if (_canToggleLights && Input.GetKeyDown(toggleKey)) {
            if (lightSource.intensity == 0.0f) {
                lightSource.intensity = 2.0f;
                playerMovement.prohibitMovement();
                _canToggleLights = true;
            }
            else {
                lightSource.intensity = 0.0f;
                playerMovement.enableMovement();
            }
            audioSwitch.toggleAudioLightDark();
        }
    }
}
