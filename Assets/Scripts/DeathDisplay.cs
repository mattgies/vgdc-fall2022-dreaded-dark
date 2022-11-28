using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathDisplay : MonoBehaviour
{
    public TMP_Text deathCount;
    public int numDeaths; 
    public PlayerDeath pDead;

    // Start is called before the first frame update
    void Start()
    {
        numDeaths = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        numDeaths = pDead.getDeathCount();
        deathCount.text = "Deaths: " + numDeaths;
    }
}
