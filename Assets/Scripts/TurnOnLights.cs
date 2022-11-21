using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOnLights : MonoBehaviour
{
    [SerializeField] GameObject globalLight;
    private UnityEngine.Rendering.Universal.Light2D light;
    private bool isTimerRunning = false;
    private float timeRemaining = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        light = globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        light.intensity = 1.0f;
        //start the timer when you hit the switch
        isTimerRunning = true;
        timeRemaining = 10.0f;
    }

    void Update(){
        if(isTimerRunning){
            timeRemaining -= Time.deltaTime;

            if(timeRemaining < 0.0f){
                isTimerRunning = false;
                light.intensity = 0.2f;
            }
        }
    }
}
