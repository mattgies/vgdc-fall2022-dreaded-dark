using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleLights : MonoBehaviour
{
    [SerializeField] GameObject globalLight;
    private UnityEngine.Rendering.Universal.Light2D light;
    private bool _canToggleLights;
    private PlayerMovement playerMovement;

    void Start()
    {
        light = globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        _canToggleLights = false;
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        _canToggleLights = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        _canToggleLights = false;
    }

    void Update(){
        if (_canToggleLights && Input.GetKeyDown(KeyCode.F)) {
            if (light.intensity == 0.0f) {
                light.intensity = 1.0f;
                playerMovement.prohibitMovement();
            }
            else {
                light.intensity = 0.0f;
                playerMovement.enableMovement();
            }
        }
    }
}
