using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDeathToggle : MonoBehaviour
{
    public void changeToggle() {
        if (DeathToggle.toggle == 1){
            DeathToggle.toggle = 0;
        } else{
            DeathToggle.toggle = 1;
        }
    }
    void Update() {
        Debug.Log(DeathToggle.toggle);
    }
}
