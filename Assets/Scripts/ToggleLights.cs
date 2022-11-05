using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOnLights : MonoBehaviour
{
    [SerializeField] GameObject globalLight;
    private UnityEngine.Rendering.Universal.Light2D light;
    private bool _canToggleLights = false;

    void Start()
    {
        light = globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        _canToggleLights = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        _canToggleLights = false;
    }

    void Update(){
        if (_canToggleLights && Input.GetKeyDown(KeyCode.F)) {
            light.intensity = light.intensity == 0.0f ? 1.0f : 0.0f;
        }
    }
}
