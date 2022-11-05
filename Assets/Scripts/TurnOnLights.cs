using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOnLights : MonoBehaviour
{
    [SerializeField] GameObject globalLight;
    private UnityEngine.Rendering.Universal.Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        light = globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        light.intensity = 1.0f;
    }
}
